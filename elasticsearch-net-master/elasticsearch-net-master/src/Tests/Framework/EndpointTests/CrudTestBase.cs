using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Elasticsearch.Net;
using FluentAssertions;
using Nest;
using Tests.Framework.Integration;
using Tests.Framework.ManagedElasticsearch;
using Tests.Framework.ManagedElasticsearch.Clusters;
using Xunit;

namespace Tests.Framework
{
	public abstract class CrudWithNoDeleteTestBase<TCreateResponse, TReadResponse, TUpdateResponse>
		: CrudTestBase<TCreateResponse, TReadResponse, TUpdateResponse, AcknowledgedResponseBase>
			where TCreateResponse : class, IResponse
			where TReadResponse : class, IResponse
			where TUpdateResponse : class, IResponse
	{
	    protected CrudWithNoDeleteTestBase(ClusterBase cluster, EndpointUsage usage) : base(cluster, usage) { }
		protected override bool SupportsDeletes => false;
	}

	public abstract class CrudTestBase<TCreateResponse, TReadResponse, TUpdateResponse, TDeleteResponse>
		: CrudTestBase<WritableCluster, TCreateResponse, TReadResponse, TUpdateResponse, TDeleteResponse>
			where TCreateResponse : class, IResponse
			where TReadResponse : class, IResponse
			where TUpdateResponse : class, IResponse
			where TDeleteResponse : class, IResponse
	{
		protected CrudTestBase(ClusterBase cluster, EndpointUsage usage) : base(cluster, usage)
		{
		}
	}

	public abstract class CrudTestBase<TCluster, TCreateResponse, TReadResponse, TUpdateResponse, TDeleteResponse> : IClusterFixture<TCluster>
			where TCluster : ClusterBase, new()
			where TCreateResponse : class, IResponse
			where TReadResponse : class, IResponse
			where TUpdateResponse : class, IResponse
			where TDeleteResponse : class, IResponse
	{
		private readonly LazyResponses _createResponse;
		private readonly LazyResponses _createGetResponse;
		private readonly LazyResponses _updateResponse;
		private readonly LazyResponses _updateGetResponse;
		private readonly LazyResponses _deleteResponse;
		private readonly LazyResponses _deleteGetResponse;

		private readonly ClusterBase _cluster;

		[SuppressMessage("Potential Code Quality Issues", "RECS0021:Warns about calls to virtual member functions occuring in the constructor", Justification = "Expected behaviour")]
		protected CrudTestBase(ClusterBase cluster, EndpointUsage usage)
		{
			this._cluster = cluster;
			this.IntegrationPort = cluster.Node.Port;
			this._createResponse = usage.CallOnce(this.Create, 1);
			this._createGetResponse = usage.CallOnce(this.Read, 2);
			this._updateResponse = usage.CallOnce(this.Update, 3);
			this._updateGetResponse = usage.CallOnce(this.Read, 4);
			this._deleteResponse = usage.CallOnce(this.Delete, 5);
			this._deleteGetResponse = usage.CallOnce(this.Read, 6);
		}
		protected abstract LazyResponses Create();
		protected abstract LazyResponses Read();
		protected abstract LazyResponses Update();
		protected virtual LazyResponses Delete() => LazyResponses.Empty;

		private static string RandomFluent { get; } = $"fluent-{RandomString()}";
		private static string RandomFluentAsync { get; } = $"fluentasync-{RandomString()}";
		private static string RandomInitializer { get; } = $"ois-{RandomString()}";
		private static string RandomInitializerAsync { get; } = $"oisasync-{RandomString()}";

		protected virtual bool SupportsDeletes => true;

		protected LazyResponses Calls<TDescriptor, TInitializer, TInterface, TResponse>(
			Func<string, TInitializer> initializerBody,
			Func<string, TDescriptor, TInterface> fluentBody,
			Func<string, IElasticClient, Func<TDescriptor, TInterface>, TResponse> fluent,
			Func<string, IElasticClient, Func<TDescriptor, TInterface>, Task<TResponse>> fluentAsync,
			Func<string, IElasticClient, TInitializer, TResponse> request,
			Func<string, IElasticClient, TInitializer, Task<TResponse>> requestAsync
		)
			where TResponse : class, IResponse
			where TDescriptor : class, TInterface
			where TInitializer : class, TInterface
			where TInterface : class
		{
			var client = this.Client;
			return new LazyResponses(async () =>
			{
				var dict = new Dictionary<ClientMethod, IResponse>();

				var sf = Sanitize(RandomFluent);
				dict.Add(Integration.ClientMethod.Fluent, fluent(sf, client, f => fluentBody(sf, f)));

				var sfa = Sanitize(RandomFluentAsync);
				dict.Add(Integration.ClientMethod.FluentAsync, await fluentAsync(sfa, client, f => fluentBody(sfa, f)));

				var si = Sanitize(RandomInitializer);
				dict.Add(Integration.ClientMethod.Initializer, request(si, client, initializerBody(si)));

				var sia = Sanitize(RandomInitializerAsync);
				dict.Add(Integration.ClientMethod.InitializerAsync, await requestAsync(sia, client, initializerBody(sia)));
				return dict;
			});
		}
		protected static string RandomString() => Guid.NewGuid().ToString("N").Substring(0, 8);

		protected virtual string Sanitize(string randomString) => randomString + "-" + this.GetType().Name.Replace("CrudTests", "").ToLowerInvariant();

		protected int IntegrationPort { get; set; } = 9200;
		protected virtual IElasticClient Client => this._cluster.Client;

		protected async Task AssertOnAllResponses<TResponse>(LazyResponses responses, Action<TResponse> assert)
			where TResponse : class, IResponse
		{
			//hack to make sure these are resolved in the right order, calling twice yields cached results so
			//should be fast
			await this._createResponse;
			//this.WaitForYellow();
			await this._createGetResponse;
			await this._updateResponse;
			//this.WaitForYellow();
			await this._updateGetResponse;
			if (this.SupportsDeletes)
			{
				await this._deleteResponse;
				//this.WaitForYellow();
				await this._deleteGetResponse;
			}

			foreach (var kv in await responses)
			{
				var response = kv.Value as TResponse;
				if (response == null)
					throw new Exception($"{kv.Value.GetType()} is not expected response type {typeof(TResponse)}");
				//try
				//{
					assert(response);
				//}
#pragma warning disable 7095
				//catch (Exception ex) when (false)
#pragma warning restore 7095
				//{
				//	throw new Exception($"asserting over the response from: {kv.Key} failed: {ex.Message}", ex);
				//}
			}
		}

		protected void WaitForYellow()
		{
			//this.Client.ClusterHealth(g => g.WaitForStatus(WaitForStatus.Yellow));
		}

		protected async Task AssertOnCreate(Action<TCreateResponse> assert) => await this.AssertOnAllResponses(this._createResponse, assert);
		protected async Task AssertOnUpdate(Action<TUpdateResponse> assert) => await this.AssertOnAllResponses(this._updateResponse, assert);
		protected async Task AssertOnDelete(Action<TDeleteResponse> assert)
		{
			if (!this.SupportsDeletes) return;
			await this.AssertOnAllResponses(this._deleteResponse, assert);
		}

		protected async Task AssertOnGetAfterCreate(Action<TReadResponse> assert) => await this.AssertOnAllResponses(this._createGetResponse, assert);
		protected async Task AssertOnGetAfterUpdate(Action<TReadResponse> assert) => await this.AssertOnAllResponses(this._updateGetResponse, assert);
		protected async Task AssertOnGetAfterDelete(Action<TReadResponse> assert)
		{
			if (!this.SupportsDeletes) return;
			await this.AssertOnAllResponses(this._deleteGetResponse, assert);
		}

		protected virtual void ExpectAfterCreate(TReadResponse response) { }
		protected virtual void ExpectAfterUpdate(TReadResponse response) { }

		[I] protected virtual async Task CreateCallIsValid() => await this.AssertOnCreate(r => r.ShouldBeValid());
		[I] protected virtual async Task GetAfterCreateIsValid() => await this.AssertOnGetAfterCreate(r => {
			r.ShouldBeValid();
			ExpectAfterCreate(r);
		});

		[I] protected virtual async Task UpdateCallIsValid() => await this.AssertOnUpdate(r => r.ShouldBeValid());

		[I] protected virtual async Task GetAfterUpdateIsValid() => await this.AssertOnGetAfterUpdate(r => {
			r.ShouldBeValid();
			ExpectAfterUpdate(r);
		});

		[I] protected virtual async Task DeleteCallIsValid() => await this.AssertOnDelete(r => r.ShouldBeValid());
		[I] protected virtual async Task GetAfterDeleteIsValid() => await this.AssertOnGetAfterDelete(r => r.ShouldNotBeValid());
	}
}
