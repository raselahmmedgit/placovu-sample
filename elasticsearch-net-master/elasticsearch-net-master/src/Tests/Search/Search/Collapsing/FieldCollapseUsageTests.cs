﻿using System;
using FluentAssertions;
using Nest;
using Tests.Framework.Integration;
using Tests.Framework.ManagedElasticsearch.Clusters;
using Tests.Framework.MockData;
using static Nest.Infer;

namespace Tests.Search.Search.Collapsing
{
	/**
	 */
	public class FieldCollapseUsageTests : SearchUsageTestBase
	{
		public FieldCollapseUsageTests(ReadOnlyCluster cluster, EndpointUsage usage) : base(cluster, usage) { }

		protected override object ExpectJson => new
		{
			collapse = new
			{
				field = "state",
				max_concurrent_group_searches = 1000,
				inner_hits = new
				{
					from = 1,
					name = "stateofbeing",
					size = 5
				}

			}
		};

		protected override Func<SearchDescriptor<Project>, ISearchRequest> Fluent => s => s
			.Collapse(c => c
				.Field(f => f.State)
				.MaxConcurrentGroupSearches(1000)
				.InnerHits(i => i
					.Name(nameof(StateOfBeing).ToLowerInvariant())
					.Size(5)
					.From(1)
				)
			);

		protected override SearchRequest<Project> Initializer => new SearchRequest<Project>
		{
			Collapse = new FieldCollapse
			{
				Field = Field<Project>(p => p.State),
				MaxConcurrentGroupSearches = 1000,
				InnerHits = new InnerHits
				{
					Name = nameof(StateOfBeing).ToLowerInvariant(),
					Size = 5,
					From = 1
				}
			}
		};

		protected override void ExpectResponse(ISearchResponse<Project> response)
		{
			var numberOfStates = Enum.GetValues(typeof(StateOfBeing)).Length;
			response.HitsMetaData.Total.Should().BeGreaterThan(numberOfStates);
			response.Hits.Count.Should().Be(numberOfStates);
			foreach (var hit in response.Hits)
			{
				var name = nameof(StateOfBeing).ToLowerInvariant();
				hit.InnerHits.Should().NotBeNull().And.ContainKey(name);
				var innherHits = hit.InnerHits[name];
				innherHits.Hits.Total.Should().BeGreaterThan(0);
			}
		}
	}
}
