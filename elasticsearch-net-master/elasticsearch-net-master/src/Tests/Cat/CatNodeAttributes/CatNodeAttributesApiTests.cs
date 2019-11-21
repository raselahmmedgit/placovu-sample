﻿using Elasticsearch.Net;
using FluentAssertions;
using Nest;
using Tests.Framework;
using Tests.Framework.Integration;
using Tests.Framework.ManagedElasticsearch.Clusters;
using Xunit;

namespace Tests.Cat.CatNodeAttributes
{
	public class CatNodeAttributesApiTests : ApiIntegrationTestBase<ReadOnlyCluster,ICatResponse<CatNodeAttributesRecord>, ICatNodeAttributesRequest, CatNodeAttributesDescriptor, CatNodeAttributesRequest>
	{
		public CatNodeAttributesApiTests(ReadOnlyCluster cluster, EndpointUsage usage) : base(cluster, usage) { }
		protected override LazyResponses ClientUsage() => Calls(
			fluent: (client, f) => client.CatNodeAttributes(),
			fluentAsync: (client, f) => client.CatNodeAttributesAsync(),
			request: (client, r) => client.CatNodeAttributes(r),
			requestAsync: (client, r) => client.CatNodeAttributesAsync(r)
		);

		protected override bool ExpectIsValid => true;
		protected override int ExpectStatusCode => 200;
		protected override HttpMethod HttpMethod => HttpMethod.GET;
		protected override string UrlPath => "/_cat/nodeattrs";

		protected override void ExpectResponse(ICatResponse<CatNodeAttributesRecord> response)
		{
			response.Records.Should().NotBeEmpty().And.Contain(a => a.Attribute == "testingcluster");
		}
	}
}
