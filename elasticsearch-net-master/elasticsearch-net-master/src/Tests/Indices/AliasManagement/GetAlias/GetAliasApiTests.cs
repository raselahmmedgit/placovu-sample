﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Elasticsearch.Net;
using FluentAssertions;
using Nest;
using Tests.Framework;
using Tests.Framework.Integration;
using Tests.Framework.ManagedElasticsearch.Clusters;
using Tests.Framework.ManagedElasticsearch.NodeSeeders;
using Xunit;

namespace Tests.Indices.AliasManagement.GetAlias
{
	public class GetAliasApiTests : ApiIntegrationTestBase<ReadOnlyCluster, IGetAliasResponse, IGetAliasRequest, GetAliasDescriptor, GetAliasRequest>
	{
		private static readonly Names Names = Infer.Names(DefaultSeeder.ProjectsAliasName);

		public GetAliasApiTests(ReadOnlyCluster cluster, EndpointUsage usage) : base(cluster, usage) { }

		protected override LazyResponses ClientUsage() => Calls(
			fluent: (client, f) => client.GetAlias(f),
			fluentAsync: (client, f) => client.GetAliasAsync(f),
			request: (client, r) => client.GetAlias(r),
			requestAsync: (client, r) => client.GetAliasAsync(r)
		);

		protected override bool ExpectIsValid => true;
		protected override int ExpectStatusCode => 200;
		protected override HttpMethod HttpMethod => HttpMethod.GET;
		protected override string UrlPath => $"_all/_alias/{DefaultSeeder.ProjectsAliasName}";
		protected override void ExpectResponse(IGetAliasResponse response)
		{
			response.Indices.Should().NotBeNull();
			response.Indices.Count.Should().BeGreaterThan(0);
		}
		protected override bool SupportsDeserialization => false;

		protected override Func<GetAliasDescriptor, IGetAliasRequest> Fluent => d=>d
			.AllIndices()
			.Name(Names)
		;
		protected override GetAliasRequest Initializer => new GetAliasRequest(Nest.Indices.All, Names);
	}

	public class GetAliasPartialMatchApiTests : ApiIntegrationTestBase<ReadOnlyCluster, IGetAliasResponse, IGetAliasRequest, GetAliasDescriptor, GetAliasRequest>
	{
		private static readonly Names Names = Infer.Names(DefaultSeeder.ProjectsAliasName,"x", "y");

		public GetAliasPartialMatchApiTests(ReadOnlyCluster cluster, EndpointUsage usage) : base(cluster, usage) { }

		protected override LazyResponses ClientUsage() => Calls(
			fluent: (client, f) => client.GetAlias(f),
			fluentAsync: (client, f) => client.GetAliasAsync(f),
			request: (client, r) => client.GetAlias(r),
			requestAsync: (client, r) => client.GetAliasAsync(r)
		);

		protected override bool ExpectIsValid => true;
		protected override int ExpectStatusCode => TestClient.VersionUnderTestSatisfiedBy("<5.5.0") ? 200 : 404;
		protected override HttpMethod HttpMethod => HttpMethod.GET;
		protected override string UrlPath => $"_all/_alias/{DefaultSeeder.ProjectsAliasName}%2Cx%2Cy";
		protected override void ExpectResponse(IGetAliasResponse response)
		{
			response.Indices.Should().NotBeNull();
			response.Indices.Count.Should().BeGreaterThan(0);
		}
		protected override bool SupportsDeserialization => false;

		protected override Func<GetAliasDescriptor, IGetAliasRequest> Fluent => d=>d
			.AllIndices()
			.Name(Names)
		;
		protected override GetAliasRequest Initializer => new GetAliasRequest(Nest.Indices.All, Names);
	}

	public class GetAliasNotFoundApiTests : ApiIntegrationTestBase<ReadOnlyCluster, IGetAliasResponse, IGetAliasRequest, GetAliasDescriptor, GetAliasRequest>
	{
		private static readonly Names Names = Infer.Names("bad-alias");

		public GetAliasNotFoundApiTests(ReadOnlyCluster cluster, EndpointUsage usage) : base(cluster, usage) { }

		protected override LazyResponses ClientUsage() => Calls(
			fluent: (client, f) => client.GetAlias(f),
			fluentAsync: (client, f) => client.GetAliasAsync(f),
			request: (client, r) => client.GetAlias(r),
			requestAsync: (client, r) => client.GetAliasAsync(r)
		);

		protected override bool ExpectIsValid => false;
		protected override int ExpectStatusCode => 404;
		protected override HttpMethod HttpMethod => HttpMethod.GET;
		protected override string UrlPath => $"/_alias/bad-alias";
		protected override bool SupportsDeserialization => false;

		protected override Func<GetAliasDescriptor, IGetAliasRequest> Fluent => d=>d
			.Name(Names)
		;
		protected override GetAliasRequest Initializer => new GetAliasRequest(Names);

		protected override void ExpectResponse(IGetAliasResponse response)
		{
			response.ServerError.Should().NotBeNull();
			response.ServerError.Error.Reason.Should().Contain("missing");
			response.Indices.Should().NotBeNull();
		}

	}
}
