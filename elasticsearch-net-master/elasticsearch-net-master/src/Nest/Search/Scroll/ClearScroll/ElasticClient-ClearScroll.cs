﻿using System;
using System.Threading.Tasks;
using Elasticsearch.Net;
using System.Threading;

namespace Nest
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Deletes a registered scroll request on the cluster
		/// <para> </para>http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/search-request-scroll.html
		/// </summary>
		/// <param name="selector">Specify the scroll id as well as request specific configuration</param>
		IClearScrollResponse ClearScroll(Func<ClearScrollDescriptor, IClearScrollRequest> selector);

		/// <inheritdoc/>
		IClearScrollResponse ClearScroll(IClearScrollRequest request);

		/// <inheritdoc/>
		Task<IClearScrollResponse> ClearScrollAsync(Func<ClearScrollDescriptor, IClearScrollRequest> selector, CancellationToken cancellationToken = default(CancellationToken));

		/// <inheritdoc/>
		Task<IClearScrollResponse> ClearScrollAsync(IClearScrollRequest request, CancellationToken cancellationToken = default(CancellationToken));
	}

	public partial class ElasticClient
	{
		/// <inheritdoc/>
		public IClearScrollResponse ClearScroll(Func<ClearScrollDescriptor, IClearScrollRequest> selector) =>
			this.ClearScroll(selector.InvokeOrDefault(new ClearScrollDescriptor()));

		/// <inheritdoc/>
		public IClearScrollResponse ClearScroll(IClearScrollRequest request) =>
			this.Dispatcher.Dispatch<IClearScrollRequest, ClearScrollRequestParameters, ClearScrollResponse>(
				request,
				(p, d) => this.LowLevelDispatch.ClearScrollDispatch<ClearScrollResponse>(p, d)
			);


		/// <inheritdoc/>
		public Task<IClearScrollResponse> ClearScrollAsync(Func<ClearScrollDescriptor, IClearScrollRequest> selector, CancellationToken cancellationToken = default(CancellationToken)) =>
			this.ClearScrollAsync(selector.InvokeOrDefault(new ClearScrollDescriptor()), cancellationToken);

		/// <inheritdoc/>
		public Task<IClearScrollResponse> ClearScrollAsync(IClearScrollRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
			this.Dispatcher.DispatchAsync<IClearScrollRequest, ClearScrollRequestParameters, ClearScrollResponse, IClearScrollResponse>(
				request,
				cancellationToken,
				(p, d, c) => this.LowLevelDispatch.ClearScrollDispatchAsync<ClearScrollResponse>(p, d, c)
			);
	}
}
