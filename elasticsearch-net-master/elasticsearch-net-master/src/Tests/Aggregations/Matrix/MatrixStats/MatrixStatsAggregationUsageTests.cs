﻿using System;
using FluentAssertions;
using Nest;
using Tests.Framework.Integration;
using Tests.Framework.MockData;
using static Nest.Infer;
using System.Collections.Generic;
using Tests.Framework;
using System.Linq;
using Tests.Framework.ManagedElasticsearch.Clusters;

namespace Tests.Aggregations.Matrix.MatrixStats
{
	public class MatrixStatsAggregationUsageTests : AggregationUsageTestBase
	{
		public MatrixStatsAggregationUsageTests(ReadOnlyCluster i, EndpointUsage usage) : base(i, usage) { }

		protected override object ExpectJson => new
		{
			aggs = new
			{
				matrixstats = new
				{
					meta = new
					{
						foo = "bar"
					},
					matrix_stats = new
					{
						fields = new[] { "numberOfCommits", "numberOfContributors" },
						missing = new {
							numberOfCommits = 0.0,
							numberOfContributors = 1.0
						},
						mode = "median"
					}
				}
			}
		};

		protected override Func<SearchDescriptor<Project>, ISearchRequest> Fluent => s => s
			.Aggregations(a => a
				.MatrixStats("matrixstats", ms => ms
					.Meta(m => m
						.Add("foo", "bar")
					)
					.Fields(fs => fs
						.Field(p => p.NumberOfCommits)
						.Field(p => p.NumberOfContributors)
					)
					.Missing(m => m
						.Add(Field<Project>(p => p.NumberOfCommits), 0)
						.Add(Field<Project>(p => p.NumberOfContributors), 1)
					)
					.Mode(MatrixStatsMode.Median)
				)
			);

		protected override SearchRequest<Project> Initializer =>
			new SearchRequest<Project>
			{
				Aggregations = new MatrixStatsAggregation("matrixstats", Field<Project>(p => p.NumberOfCommits))
				{
					Meta = new Dictionary<string, object>
					{
						{ "foo", "bar" }
					},
					Missing = new Dictionary<Field, double>
					{
						{ "numberOfCommits", 0.0 },
						{ "numberOfContributors", 1.0 },
					},
					Mode = MatrixStatsMode.Median,
					Fields = Field<Project>(p => p.NumberOfCommits).And("numberOfContributors")
				}
			};

		protected override void ExpectResponse(ISearchResponse<Project> response)
		{
			response.ShouldBeValid();
			var matrix = response.Aggs.MatrixStats("matrixstats");
			matrix.Should().NotBeNull();
			matrix.Fields.Should().NotBeNull().And.HaveCount(2);

			AssertField(matrix, "numberOfCommits");
			AssertField(matrix, "numberOfContributors");
		}

		// hide
		private void AssertField(MatrixStatsAggregate aggregate, string name)
		{
			var stats = aggregate.Fields.FirstOrDefault(f => f.Name == name);
			stats.Should().NotBeNull();
			stats.Count.Should().NotBe(0);
			stats.Mean.Should().NotBe(0);
			stats.Variance.Should().NotBe(0);
			stats.Skewness.Should().NotBe(0);
			stats.Kurtosis.Should().NotBe(0);
			stats.Covariance.Should().NotBeNull().And.HaveCount(2);
			stats.Correlation.Should().NotBeNull().And.HaveCount(2);
		}
	}
}
