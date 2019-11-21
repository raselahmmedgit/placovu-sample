﻿using System.Linq;
using FluentAssertions;
using Nest;
using Tests.Framework;
using Tests.Framework.Integration;
using Tests.Framework.ManagedElasticsearch.Clusters;
using Tests.Framework.MockData;
using Xunit;

namespace Tests.Reproduce
{
	public class GithubIssue2323 : IClusterFixture<ReadOnlyCluster>
	{
		private readonly ReadOnlyCluster _cluster;

		public GithubIssue2323(ReadOnlyCluster cluster)
		{
			_cluster = cluster;
		}

		[I]
		public void NestedInnerHitsShouldIncludedNestedProperty()
		{
			var client = _cluster.Client;
			var response = client.Search<Project>(s => s
					.Query(q => q
							.Nested(n => n
									.Path(p => p.Tags)
									.Query(nq => nq
											.MatchAll()
									)
									.InnerHits(i => i
											.Source(false)
									)
							)
					)
			);

			response.ShouldBeValid();

			var innerHits = response.Hits.Select(h => h.InnerHits).ToList();

			innerHits.Should().NotBeNullOrEmpty();

			var innerHit = innerHits.First();
			innerHit.Should().ContainKey("tags");
			var hitMetadata = innerHit["tags"].Hits.Hits.First();

			hitMetadata.Nested.Should().NotBeNull();
			hitMetadata.Nested.Field.Should().Be(new Field("tags"));
			hitMetadata.Nested.Offset.Should().BeGreaterOrEqualTo(0);
		}
	}
}
