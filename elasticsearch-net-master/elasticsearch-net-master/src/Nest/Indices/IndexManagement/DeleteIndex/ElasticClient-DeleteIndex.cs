﻿using System;
using System.Threading.Tasks;
using Elasticsearch.Net;
using System.Threading;

namespace Nest
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// The delete index API allows to delete an existing index.
		/// <para> </para>http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/indices-delete-index.html
		/// </summary>
		/// <param name="selector">A descriptor that describes the parameters for the delete index operation</param>
		IDeleteIndexResponse DeleteIndex(Indices indices, Func<DeleteIndexDescriptor, IDeleteIndexRequest> selector = null);

		/// <inheritdoc/>
		IDeleteIndexResponse DeleteIndex(IDeleteIndexRequest request);

		/// <inheritdoc/>
		Task<IDeleteIndexResponse> DeleteIndexAsync(
			Indices indices,
			Func<DeleteIndexDescriptor, IDeleteIndexRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		);

		/// <inheritdoc/>
		Task<IDeleteIndexResponse> DeleteIndexAsync(IDeleteIndexRequest request, CancellationToken cancellationToken = default(CancellationToken));

	}

	public partial class ElasticClient
	{
		/// <inheritdoc/>
		public IDeleteIndexResponse DeleteIndex(Indices indices, Func<DeleteIndexDescriptor, IDeleteIndexRequest> selector = null) =>
			this.DeleteIndex(selector.InvokeOrDefault(new DeleteIndexDescriptor(indices)));

		/// <inheritdoc/>
		public IDeleteIndexResponse DeleteIndex(IDeleteIndexRequest request) =>
			this.Dispatcher.Dispatch<IDeleteIndexRequest, DeleteIndexRequestParameters, DeleteIndexResponse>(
				request,
				(p, d) => this.LowLevelDispatch.IndicesDeleteDispatch<DeleteIndexResponse>(p)
			);

		/// <inheritdoc/>
		public Task<IDeleteIndexResponse> DeleteIndexAsync(
			Indices indices,
			Func<DeleteIndexDescriptor, IDeleteIndexRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		) => this.DeleteIndexAsync(selector.InvokeOrDefault(new DeleteIndexDescriptor(indices)), cancellationToken);

		/// <inheritdoc/>
		public Task<IDeleteIndexResponse> DeleteIndexAsync(IDeleteIndexRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
			this.Dispatcher.DispatchAsync<IDeleteIndexRequest, DeleteIndexRequestParameters, DeleteIndexResponse, IDeleteIndexResponse>(
				request,
				cancellationToken,
				(p, d, c) => this.LowLevelDispatch.IndicesDeleteDispatchAsync<DeleteIndexResponse>(p, c)
			);
	}
}
