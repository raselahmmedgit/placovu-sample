﻿using System;
using System.Threading.Tasks;
using Elasticsearch.Net;
using System.Threading;

namespace Nest
{
	public partial interface IElasticClient
	{
		/// <inheritdoc/>
		ISearchShardsResponse SearchShards<T>(Func<SearchShardsDescriptor<T>, ISearchShardsRequest> selector) where T : class;

		/// <inheritdoc/>
		ISearchShardsResponse SearchShards(ISearchShardsRequest request);

		/// <inheritdoc/>
		Task<ISearchShardsResponse> SearchShardsAsync<T>(Func<SearchShardsDescriptor<T>, ISearchShardsRequest> selector, CancellationToken cancellationToken = default(CancellationToken))
			where T : class;

		/// <inheritdoc/>
		Task<ISearchShardsResponse> SearchShardsAsync(ISearchShardsRequest request, CancellationToken cancellationToken = default(CancellationToken));

	}
	public partial class ElasticClient
	{
		/// <inheritdoc/>
		public ISearchShardsResponse SearchShards<T>(Func<SearchShardsDescriptor<T>, ISearchShardsRequest> selector) where T : class =>
			this.SearchShards(selector?.Invoke(new SearchShardsDescriptor<T>()));

		/// <inheritdoc/>
		public ISearchShardsResponse SearchShards(ISearchShardsRequest request) =>
			this.Dispatcher.Dispatch<ISearchShardsRequest, SearchShardsRequestParameters, SearchShardsResponse>(
				request,
				(p, d) => this.LowLevelDispatch.SearchShardsDispatch<SearchShardsResponse>(p)
			);

		/// <inheritdoc/>
		public Task<ISearchShardsResponse> SearchShardsAsync<T>(Func<SearchShardsDescriptor<T>, ISearchShardsRequest> selector, CancellationToken cancellationToken = default(CancellationToken))
			where T : class =>
			this.SearchShardsAsync(selector?.Invoke(new SearchShardsDescriptor<T>()), cancellationToken);

		/// <inheritdoc/>
		public Task<ISearchShardsResponse> SearchShardsAsync(ISearchShardsRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
			this.Dispatcher.DispatchAsync<ISearchShardsRequest, SearchShardsRequestParameters, SearchShardsResponse, ISearchShardsResponse>(
				request,
				cancellationToken,
				(p, d, c) => this.LowLevelDispatch.SearchShardsDispatchAsync<SearchShardsResponse>(p, c)
			);
	}
}
