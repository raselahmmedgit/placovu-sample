﻿using System;
using System.IO;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{
	using System.Threading;
	using AliasExistConverter = Func<IApiCallDetails, Stream, ExistsResponse>;

	public partial interface IElasticClient
	{
		/// <inheritdoc/>
		IExistsResponse AliasExists(Func<AliasExistsDescriptor, IAliasExistsRequest> selector);

		/// <inheritdoc/>
		IExistsResponse AliasExists(IAliasExistsRequest request);

		/// <inheritdoc/>
		Task<IExistsResponse> AliasExistsAsync(Func<AliasExistsDescriptor, IAliasExistsRequest> selector, CancellationToken cancellationToken = default(CancellationToken));

		/// <inheritdoc/>
		Task<IExistsResponse> AliasExistsAsync(IAliasExistsRequest request, CancellationToken cancellationToken = default(CancellationToken));
	}

	public partial class ElasticClient
	{
		/// <inheritdoc/>
		public IExistsResponse AliasExists(Func<AliasExistsDescriptor, IAliasExistsRequest> selector) =>
			this.AliasExists(selector?.Invoke(new AliasExistsDescriptor()));

		/// <inheritdoc/>
		public IExistsResponse AliasExists(IAliasExistsRequest request) =>
			this.Dispatcher.Dispatch<IAliasExistsRequest, AliasExistsRequestParameters, ExistsResponse>(
				request,
				new AliasExistConverter(DeserializeExistsResponse),
				(p, d) => this.LowLevelDispatch.IndicesExistsAliasDispatch<ExistsResponse>(p)
			);

		/// <inheritdoc/>
		public Task<IExistsResponse> AliasExistsAsync(Func<AliasExistsDescriptor, IAliasExistsRequest> selector, CancellationToken cancellationToken = default(CancellationToken)) =>
			this.AliasExistsAsync(selector?.Invoke(new AliasExistsDescriptor()), cancellationToken);

		/// <inheritdoc/>
		public Task<IExistsResponse> AliasExistsAsync(IAliasExistsRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
			this.Dispatcher.DispatchAsync<IAliasExistsRequest, AliasExistsRequestParameters, ExistsResponse, IExistsResponse>(
				request,
				cancellationToken,
				new AliasExistConverter(DeserializeExistsResponse),
				(p, d, c) => this.LowLevelDispatch.IndicesExistsAliasDispatchAsync<ExistsResponse>(p, c)
			);
	}
}
