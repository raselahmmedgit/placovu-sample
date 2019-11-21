﻿using Elasticsearch.Net;
using FluentAssertions;
using Nest;
using Tests.Framework;
using Tests.Framework.Integration;
using Tests.Framework.ManagedElasticsearch.Clusters;
using Tests.Framework.ManagedElasticsearch.NodeSeeders;
using Xunit;

namespace Tests.Cat.CatAliases
{
	public class CatAliasesApiTests : ApiIntegrationTestBase<ReadOnlyCluster, ICatResponse<CatAliasesRecord>, ICatAliasesRequest, CatAliasesDescriptor, CatAliasesRequest>
	{
		public CatAliasesApiTests(ReadOnlyCluster cluster, EndpointUsage usage) : base(cluster, usage) { }
		protected override LazyResponses ClientUsage() => Calls(
			fluent: (client, f) => client.CatAliases(),
			fluentAsync: (client, f) => client.CatAliasesAsync(),
			request: (client, r) => client.CatAliases(r),
			requestAsync: (client, r) => client.CatAliasesAsync(r)
		);

		protected override bool ExpectIsValid => true;
		protected override int ExpectStatusCode => 200;
		protected override HttpMethod HttpMethod => HttpMethod.GET;
		protected override string UrlPath => "/_cat/aliases";

		protected override void ExpectResponse(ICatResponse<CatAliasesRecord> response)
		{
			response.Records.Should().NotBeEmpty().And.Contain(a => a.Alias == DefaultSeeder.ProjectsAliasName);
		}
	}
}
