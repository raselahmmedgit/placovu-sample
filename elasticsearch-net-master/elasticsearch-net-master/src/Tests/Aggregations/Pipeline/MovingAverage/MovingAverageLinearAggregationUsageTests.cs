﻿using System;
using System.Linq;
using FluentAssertions;
using Nest;
using Tests.Framework;
using Tests.Framework.Integration;
using Tests.Framework.ManagedElasticsearch.Clusters;
using Tests.Framework.MockData;

namespace Tests.Aggregations.Pipeline.MovingAverage
{
	[SkipVersion("5.0.0-alpha1", "https://github.com/elastic/elasticsearch/issues/17516")]
	public class MovingAverageLinearAggregationUsageTests : AggregationUsageTestBase
	{
		public MovingAverageLinearAggregationUsageTests(ReadOnlyCluster cluster, EndpointUsage usage) : base(cluster, usage) { }

		protected override object ExpectJson => new
		{
			size = 0,
			aggs = new
			{
				projects_started_per_month = new
				{
					date_histogram = new
					{
						field = "startedOn",
						interval = "month",
					},
					aggs = new
					{
						commits = new
						{
							sum = new
							{
								field = "numberOfCommits"
							}
						},
						commits_moving_avg = new
						{
							moving_avg = new
							{
								buckets_path = "commits",
								gap_policy = "insert_zeros",
								model = "linear",
								settings = new {}
							}
						}
					}
				}
			}
		};

		protected override Func<SearchDescriptor<Project>, ISearchRequest> Fluent => s => s
			.Size(0)
			.Aggregations(a => a
				.DateHistogram("projects_started_per_month", dh => dh
					.Field(p => p.StartedOn)
					.Interval(DateInterval.Month)
					.Aggregations(aa => aa
						.Sum("commits", sm => sm
							.Field(p => p.NumberOfCommits)
						)
						.MovingAverage("commits_moving_avg", mv => mv
							.BucketsPath("commits")
							.GapPolicy(GapPolicy.InsertZeros)
							.Model(m => m
								.Linear()
							)
						)
					)
				)
			);

		protected override SearchRequest<Project> Initializer => new SearchRequest<Project>()
		{
			Size = 0,
			Aggregations = new DateHistogramAggregation("projects_started_per_month")
			{
				Field = "startedOn",
				Interval = DateInterval.Month,
				Aggregations =
					new SumAggregation("commits", "numberOfCommits") &&
					new MovingAverageAggregation("commits_moving_avg", "commits")
					{
						GapPolicy = GapPolicy.InsertZeros,
						Model = new LinearModel()
					}
			}
		};

		protected override void ExpectResponse(ISearchResponse<Project> response)
		{
			response.ShouldBeValid();

			var projectsPerMonth = response.Aggs.DateHistogram("projects_started_per_month");
			projectsPerMonth.Should().NotBeNull();
			projectsPerMonth.Buckets.Should().NotBeNull();
			projectsPerMonth.Buckets.Count.Should().BeGreaterThan(0);

			// average not calculated for the first bucket
			foreach(var item in projectsPerMonth.Buckets.Skip(1))
			{
				var movingAvg = item.MovingAverage("commits_moving_avg");
				movingAvg.Should().NotBeNull();
				movingAvg.Value.Should().BeGreaterThan(0);
			}
		}
	}
}
