﻿using System;
using System.Threading.Tasks;
using Elasticsearch.Net;
using System.Threading;

namespace Nest
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// The refresh API allows to explicitly refresh one or more index, making all operations performed since the last refresh
		/// available for search. The (near) real-time capabilities depend on the index engine used.
		/// <para> </para><a href="http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/indices-refresh.html">http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/indices-refresh.html</a>
		/// </summary>
		/// <param name="selector">A descriptor that describes the parameters for the refresh operation</param>
		IRefreshResponse Refresh(Indices indices, Func<RefreshDescriptor, IRefreshRequest> selector = null);

		/// <inheritdoc/>
		IRefreshResponse Refresh(IRefreshRequest request);

		/// <inheritdoc/>
		Task<IRefreshResponse> RefreshAsync(Indices indices, Func<RefreshDescriptor, IRefreshRequest> selector = null, CancellationToken cancellationToken = default(CancellationToken));

		/// <inheritdoc/>
		Task<IRefreshResponse> RefreshAsync(IRefreshRequest request, CancellationToken cancellationToken = default(CancellationToken));

	}
	public partial class ElasticClient
	{
		/// <inheritdoc/>
		public IRefreshResponse Refresh(Indices indices, Func<RefreshDescriptor, IRefreshRequest> selector = null) =>
			this.Refresh(selector.InvokeOrDefault(new RefreshDescriptor().Index(indices)));

		/// <inheritdoc/>
		public IRefreshResponse Refresh(IRefreshRequest request) =>
			this.Dispatcher.Dispatch<IRefreshRequest, RefreshRequestParameters, RefreshResponse>(
				request,
				(p, d) => this.LowLevelDispatch.IndicesRefreshDispatch<RefreshResponse>(p)
			);

		/// <inheritdoc/>
		public Task<IRefreshResponse> RefreshAsync(Indices indices, Func<RefreshDescriptor, IRefreshRequest> selector = null, CancellationToken cancellationToken = default(CancellationToken)) =>
			this.RefreshAsync(selector.InvokeOrDefault(new RefreshDescriptor().Index(indices)), cancellationToken);

		/// <inheritdoc/>
		public Task<IRefreshResponse> RefreshAsync(IRefreshRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
			this.Dispatcher.DispatchAsync<IRefreshRequest, RefreshRequestParameters, RefreshResponse, IRefreshResponse>(
				request,
				cancellationToken,
				(p, d, c) => this.LowLevelDispatch.IndicesRefreshDispatchAsync<RefreshResponse>(p, c)
			);
	}
}
