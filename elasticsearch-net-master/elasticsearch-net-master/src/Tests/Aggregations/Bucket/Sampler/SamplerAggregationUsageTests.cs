﻿using System;
using FluentAssertions;
using Nest;
using Tests.Framework;
using Tests.Framework.Integration;
using Tests.Framework.ManagedElasticsearch.Clusters;
using Tests.Framework.MockData;

namespace Tests.Aggregations.Bucket.Sampler
{
	public class SamplerAggregationUsageTests : AggregationUsageTestBase
	{
		public SamplerAggregationUsageTests(ReadOnlyCluster i, EndpointUsage usage) : base(i, usage) { }

		protected override object ExpectJson => new
		{
			aggs = new
			{
				sample = new
				{
					sampler = new
					{
						shard_size = 200
					},
					aggs = new
					{
						significant_names = new
						{
							significant_terms = new
							{
								field = "name"
							}
						}
					}
				}
			}
		};

		protected override Func<SearchDescriptor<Project>, ISearchRequest> Fluent => s => s
			.Aggregations(aggs => aggs
				.Sampler("sample", sm => sm
					.ShardSize(200)
					.Aggregations(aa => aa
						.SignificantTerms("significant_names", st => st
							.Field(p => p.Name)
						)
					)
				)
			);

		protected override SearchRequest<Project> Initializer =>
			new SearchRequest<Project>
			{
				Aggregations = new SamplerAggregation("sample")
				{
					ShardSize = 200,
					Aggregations = new SignificantTermsAggregation("significant_names")
					{
						Field = "name"
					}
				}
			};

		protected override void ExpectResponse(ISearchResponse<Project> response)
		{
			response.ShouldBeValid();

			var sample = response.Aggs.Sampler("sample");
			sample.Should().NotBeNull();
			var sigTags = sample.SignificantTerms("significant_names");
			sigTags.Should().NotBeNull();
			sigTags.DocCount.Should().BeGreaterThan(0);
			if (TestClient.VersionUnderTestSatisfiedBy(">=5.5.0"))
				sigTags.BgCount.Should().BeGreaterThan(0);
		}
	}
}
