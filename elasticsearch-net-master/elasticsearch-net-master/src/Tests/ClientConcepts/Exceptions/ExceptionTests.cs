﻿using Elasticsearch.Net;
using FluentAssertions;
using Nest;
using System;
using Tests.Framework;
using Tests.Framework.Integration;
using Tests.Framework.ManagedElasticsearch.Clusters;
using Tests.Framework.MockData;
using Xunit;

namespace Tests.ClientConcepts.Exceptions
{
	public class ExceptionTests : IClusterFixture<WritableCluster>
	{
		private readonly int _port;

		public ExceptionTests(WritableCluster cluster)
		{
			_port = cluster.Node.Port;
		}

		//[I]
		public void ServerTestWhenThrowExceptionsEnabled()
		{
			var settings = new ConnectionSettings(TestClient.CreateUri(_port))
				.ThrowExceptions();
			var client = new ElasticClient(settings);
			var exception = Assert.Throws<ElasticsearchClientException>(() => client.GetMapping<Project>(s => s.Index("doesntexist")));
#if DOTNETCORE
			// HttpClient does not throw on "known error" status codes (i.e. 404) thus the inner exception should not be set
			exception.InnerException.Should().BeNull();
#else
			exception.InnerException.Should().NotBeNull();
#endif
			exception.Response.Should().NotBeNull();
			exception.Response.ServerError.Should().NotBeNull();
			exception.Response.ServerError.Status.Should().BeGreaterThan(0);
		}

		//[I]
		public void ClientTestWhenThrowExceptionsEnabled()
		{
			var settings = new ConnectionSettings(new Uri("http://doesntexist:9200"))
				.ThrowExceptions();
			var client = new ElasticClient(settings);
			var exception = Assert.Throws<ElasticsearchClientException>(() => client.RootNodeInfo());
			var inner = exception.InnerException;
#if DOTNETCORE
			// HttpClient does not throw on "known error" status codes (i.e. 404) thus OriginalException should not be set
			inner.Should().BeNull();
#else
			inner.Should().NotBeNull();
#endif
		}

		//[I]
		public void ServerTestWhenThrowExceptionsDisabled()
		{
			var settings = new ConnectionSettings(TestClient.CreateUri(_port));
			var client = new ElasticClient(settings);
			var response = client.GetMapping<Project>(s => s.Index("doesntexist"));
#if DOTNETCORE
			// HttpClient does not throw on "known error" status codes (i.e. 404) thus OriginalException should not be set
			response.ApiCall.OriginalException.Should().BeNull();
#else
			response.ApiCall.OriginalException.Should().NotBeNull();
#endif
			response.ApiCall.ServerError.Should().NotBeNull();
			response.ApiCall.ServerError.Status.Should().BeGreaterThan(0);
		}

		//[I]
		public void ClientTestWhenThrowExceptionsDisabled()
		{
			var settings = new ConnectionSettings(new Uri("http://doesntexist:9200"));
			var client = new ElasticClient(settings);
			var response = client.RootNodeInfo();
#if DOTNETCORE
			// HttpClient does not throw on "known error" status codes (i.e. 404) thus OriginalException should not be set
			response.ApiCall.OriginalException.Should().BeNull();
#else
			response.ApiCall.OriginalException.Should().NotBeNull();
#endif
			response.ApiCall.ServerError.Should().BeNull();
		}

		//TODO figure out a way to trigger this again
		//[U]
		public void DispatchIndicatesMissingRouteValues()
		{
			var settings = new ConnectionSettings(new Uri("http://doesntexist:9200"));
			var client = new ElasticClient(settings);

			System.Action dispatch = () => client.Index(new Project(), p=>p.Index(null));
			var ce = dispatch.ShouldThrow<ArgumentException>();
			ce.Should().NotBeNull();
			ce.Which.Message.Should().Contain("index=<NULL>");
		}
	}
}
