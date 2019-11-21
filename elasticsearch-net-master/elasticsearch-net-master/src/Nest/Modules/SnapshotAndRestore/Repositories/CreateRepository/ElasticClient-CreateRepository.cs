﻿using System;
using System.Threading.Tasks;
using Elasticsearch.Net;
using System.Threading;

namespace Nest
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Before any snapshot or restore operation can be performed a snapshot repository should be registered in Elasticsearch.
		/// <para> </para>http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/modules-snapshots.html#_repositories
		/// </summary>
		/// <param name="repository">The name for the repository</param>
		/// <param name="selector">describe what the repository looks like</param>
		ICreateRepositoryResponse CreateRepository(Name repository, Func<CreateRepositoryDescriptor, ICreateRepositoryRequest> selector);

		/// <inheritdoc/>
		ICreateRepositoryResponse CreateRepository(ICreateRepositoryRequest request);

		/// <inheritdoc/>
		Task<ICreateRepositoryResponse> CreateRepositoryAsync(Name repository, Func<CreateRepositoryDescriptor, ICreateRepositoryRequest> selector, CancellationToken cancellationToken = default(CancellationToken));

		/// <inheritdoc/>
		Task<ICreateRepositoryResponse> CreateRepositoryAsync(ICreateRepositoryRequest request, CancellationToken cancellationToken = default(CancellationToken));

	}

	public partial class ElasticClient
	{
		/// <inheritdoc/>
		public ICreateRepositoryResponse CreateRepository(Name repository, Func<CreateRepositoryDescriptor, ICreateRepositoryRequest> selector) =>
			this.CreateRepository(selector?.Invoke(new CreateRepositoryDescriptor(repository)));

		/// <inheritdoc/>
		public ICreateRepositoryResponse CreateRepository(ICreateRepositoryRequest request) =>
			this.Dispatcher.Dispatch<ICreateRepositoryRequest, CreateRepositoryRequestParameters, CreateRepositoryResponse>(
				request,
				this.LowLevelDispatch.SnapshotCreateRepositoryDispatch<CreateRepositoryResponse>
			);

		/// <inheritdoc/>
		public Task<ICreateRepositoryResponse> CreateRepositoryAsync(Name repository, Func<CreateRepositoryDescriptor, ICreateRepositoryRequest> selector, CancellationToken cancellationToken = default(CancellationToken)) =>
			this.CreateRepositoryAsync(selector?.Invoke(new CreateRepositoryDescriptor(repository)), cancellationToken);

		/// <inheritdoc/>
		public Task<ICreateRepositoryResponse> CreateRepositoryAsync(ICreateRepositoryRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
			this.Dispatcher.DispatchAsync<ICreateRepositoryRequest, CreateRepositoryRequestParameters, CreateRepositoryResponse, ICreateRepositoryResponse>(
				request,
				cancellationToken,
				this.LowLevelDispatch.SnapshotCreateRepositoryDispatchAsync<CreateRepositoryResponse>
			);
	}
}
