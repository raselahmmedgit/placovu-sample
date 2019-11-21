﻿using System;
using FluentAssertions;
using Nest;
using Tests.Framework;
using Tests.Framework.Integration;
using Tests.Framework.ManagedElasticsearch.Clusters;
using Tests.Framework.MockData;

namespace Tests.Aggregations.Pipeline.MinBucket
{
	public class MinBucketAggregationUsageTests : AggregationUsageTestBase
	{
		public MinBucketAggregationUsageTests(ReadOnlyCluster cluster, EndpointUsage usage) : base(cluster, usage) { }

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
						}
					}
				},
				min_commits_per_month = new
				{
					min_bucket = new
					{
						buckets_path = "projects_started_per_month>commits"
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
					)
				)
				.MinBucket("min_commits_per_month", aaa => aaa
					.BucketsPath("projects_started_per_month>commits")
				)
			);

		protected override SearchRequest<Project> Initializer => new SearchRequest<Project>()
		{
			Size = 0,
			Aggregations = new DateHistogramAggregation("projects_started_per_month")
			{
				Field = "startedOn",
				Interval = DateInterval.Month,
				Aggregations = new SumAggregation("commits", "numberOfCommits")
			}
			&& new MinBucketAggregation("min_commits_per_month", "projects_started_per_month>commits")
		};

		protected override void ExpectResponse(ISearchResponse<Project> response)
		{
			response.ShouldBeValid();

			var projectsPerMonth = response.Aggs.DateHistogram("projects_started_per_month");
			projectsPerMonth.Should().NotBeNull();
			projectsPerMonth.Buckets.Should().NotBeNull();
			projectsPerMonth.Buckets.Count.Should().BeGreaterThan(0);

			var minCommits = response.Aggs.MinBucket("min_commits_per_month");
			minCommits.Should().NotBeNull();
			minCommits.Value.Should().BeGreaterThan(0);
			minCommits.Keys.Should().NotBeNull();
			minCommits.Keys.Count.Should().BeGreaterOrEqualTo(1);
			foreach (var key in minCommits.Keys)
				key.Should().NotBeNullOrEmpty();
		}
	}
}
