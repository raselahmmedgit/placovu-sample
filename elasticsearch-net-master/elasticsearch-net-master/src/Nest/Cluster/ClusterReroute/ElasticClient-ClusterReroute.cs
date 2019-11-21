﻿using System;
using System.Threading.Tasks;
using Elasticsearch.Net;
using System.Threading;

namespace Nest
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Allows to explicitly execute a cluster reroute allocation command including specific commands.
		/// For example, a shard can be moved from one node to another explicitly, an allocation can be canceled,
		/// or an unassigned shard can be explicitly allocated on a specific node.
		/// </summary>
		IClusterRerouteResponse ClusterReroute(Func<ClusterRerouteDescriptor, IClusterRerouteRequest> selector);

		/// <inheritdoc/>
		Task<IClusterRerouteResponse> ClusterRerouteAsync(Func<ClusterRerouteDescriptor, IClusterRerouteRequest> selector, CancellationToken cancellationToken = default(CancellationToken));

		/// <inheritdoc/>
		IClusterRerouteResponse ClusterReroute(IClusterRerouteRequest request);

		/// <inheritdoc/>
		Task<IClusterRerouteResponse> ClusterRerouteAsync(IClusterRerouteRequest request, CancellationToken cancellationToken = default(CancellationToken));

	}

	public partial class ElasticClient
	{
		/// <inheritdoc/>
		public IClusterRerouteResponse ClusterReroute(Func<ClusterRerouteDescriptor, IClusterRerouteRequest> selector) =>
			this.ClusterReroute(selector?.Invoke(new ClusterRerouteDescriptor()));

		/// <inheritdoc/>
		public Task<IClusterRerouteResponse> ClusterRerouteAsync(Func<ClusterRerouteDescriptor, IClusterRerouteRequest> selector, CancellationToken cancellationToken = default(CancellationToken)) =>
			this.ClusterRerouteAsync(selector?.Invoke(new ClusterRerouteDescriptor()), cancellationToken);

		/// <inheritdoc/>
		public IClusterRerouteResponse ClusterReroute(IClusterRerouteRequest request) =>
			this.Dispatcher.Dispatch<IClusterRerouteRequest, ClusterRerouteRequestParameters, ClusterRerouteResponse>(
				request,
				this.LowLevelDispatch.ClusterRerouteDispatch<ClusterRerouteResponse>
			);

		/// <inheritdoc/>
		public Task<IClusterRerouteResponse> ClusterRerouteAsync(IClusterRerouteRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
			this.Dispatcher.DispatchAsync<IClusterRerouteRequest, ClusterRerouteRequestParameters, ClusterRerouteResponse, IClusterRerouteResponse>(
				request,
				cancellationToken,
				this.LowLevelDispatch.ClusterRerouteDispatchAsync<ClusterRerouteResponse>
			);
	}
}
