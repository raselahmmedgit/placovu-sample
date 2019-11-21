﻿using Elasticsearch.Net;
using FluentAssertions;
using Nest;
using Tests.Framework;
using Tests.Framework.Integration;
using Tests.Framework.ManagedElasticsearch.Clusters;
using Xunit;

namespace Tests.Cluster.ClusterSettings.ClusterPutSettings
{
	public class ClusterPutSettingsApiTests : ApiIntegrationTestBase<IntrusiveOperationCluster, IClusterPutSettingsResponse, IClusterPutSettingsRequest, ClusterPutSettingsDescriptor, ClusterPutSettingsRequest>
	{
		public ClusterPutSettingsApiTests(IntrusiveOperationCluster cluster, EndpointUsage usage) : base(cluster, usage) { }
		protected override LazyResponses ClientUsage() => Calls(
			fluent: (client, f) => client.ClusterPutSettings(f),
			fluentAsync: (client, f) => client.ClusterPutSettingsAsync(f),
			request: (client, r) => client.ClusterPutSettings(r),
			requestAsync: (client, r) => client.ClusterPutSettingsAsync(r)
		);

		protected override HttpMethod HttpMethod => HttpMethod.PUT;
		protected override string UrlPath => "/_cluster/settings";

		protected override int ExpectStatusCode => 400;
		protected override bool ExpectIsValid => false;

		protected override ClusterPutSettingsRequest Initializer => new ClusterPutSettingsRequest
		{
		};

		protected override void ExpectResponse(IClusterPutSettingsResponse response)
		{
			response.ShouldNotBeValid();
			response.ServerError.Should().NotBeNull();
			response.ServerError.Status.Should().Be(400);
			response.ServerError.Error.Should().NotBeNull();
			response.ServerError.Error.Reason.Should().Contain("no settings to update");
			response.ServerError.Error.Type.Should().Contain("action_request_validation_exception");
		}
	}

	//TODO write a success test

}
