﻿using System;
using System.Collections.Generic;
using Elasticsearch.Net;
using Nest;
using Tests.Framework;
using Tests.Framework.Integration;
using Tests.Framework.ManagedElasticsearch.Clusters;
using Xunit;

namespace Tests.Indices.AliasManagement.DeleteAlias
{
	public class DeleteAliasApiTests : ApiIntegrationTestBase<WritableCluster, IDeleteAliasResponse, IDeleteAliasRequest, DeleteAliasDescriptor, DeleteAliasRequest>
	{
		private Names Names => Infer.Names(CallIsolatedValue + "-alias");

		protected override void IntegrationSetup(IElasticClient client, CallUniqueValues values)
		{
			foreach (var index in values.Values)
				client.CreateIndex(index, c=>c
					.Aliases(aa=>aa.Alias(index + "-alias"))
				);
		}

		public DeleteAliasApiTests(WritableCluster cluster, EndpointUsage usage) : base(cluster, usage) { }
		protected override LazyResponses ClientUsage() => Calls(
			fluent: (client, f) => client.DeleteAlias(Infer.AllIndices, Names),
			fluentAsync: (client, f) => client.DeleteAliasAsync(Infer.AllIndices, Names),
			request: (client, r) => client.DeleteAlias(r),
			requestAsync: (client, r) => client.DeleteAliasAsync(r)
		);

		protected override bool ExpectIsValid => true;
		protected override int ExpectStatusCode => 200;
		protected override HttpMethod HttpMethod => HttpMethod.DELETE;
		protected override string UrlPath => $"/_all/_alias/{CallIsolatedValue + "-alias"}";
		protected override bool SupportsDeserialization => false;

		protected override Func<DeleteAliasDescriptor, IDeleteAliasRequest> Fluent => null;
		protected override DeleteAliasRequest Initializer => new DeleteAliasRequest(Infer.AllIndices, Names);
	}
}
