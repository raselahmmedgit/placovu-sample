﻿using System;
using System.Threading.Tasks;
using Elasticsearch.Net;
using System.Threading;

namespace Nest
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Deletes an index template
		/// <para> </para><a href="http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/indices-templates.html#delete">http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/indices-templates.html#delete</a>
		/// </summary>
		/// <param name="name">The name of the template to delete</param>
		/// <param name="selector">An optional selector specifying additional parameters for the delete template operation</param>
		IDeleteIndexTemplateResponse DeleteIndexTemplate(Name name, Func<DeleteIndexTemplateDescriptor, IDeleteIndexTemplateRequest> selector = null);

		/// <inheritdoc/>
		IDeleteIndexTemplateResponse DeleteIndexTemplate(IDeleteIndexTemplateRequest request);

		/// <inheritdoc/>
		Task<IDeleteIndexTemplateResponse> DeleteIndexTemplateAsync(
			Name name,
			Func<DeleteIndexTemplateDescriptor, IDeleteIndexTemplateRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		);

		/// <inheritdoc/>
		Task<IDeleteIndexTemplateResponse> DeleteIndexTemplateAsync(IDeleteIndexTemplateRequest request, CancellationToken cancellationToken = default(CancellationToken));

	}

	public partial class ElasticClient
	{
		/// <inheritdoc/>
		public IDeleteIndexTemplateResponse DeleteIndexTemplate(Name name, Func<DeleteIndexTemplateDescriptor, IDeleteIndexTemplateRequest> selector = null) =>
			this.DeleteIndexTemplate(selector.InvokeOrDefault(new DeleteIndexTemplateDescriptor(name)));

		/// <inheritdoc/>
		public IDeleteIndexTemplateResponse DeleteIndexTemplate(IDeleteIndexTemplateRequest request) =>
			this.Dispatcher.Dispatch<IDeleteIndexTemplateRequest, DeleteIndexTemplateRequestParameters, DeleteIndexTemplateResponse>(
				request,
				(p, d) => this.LowLevelDispatch.IndicesDeleteTemplateDispatch<DeleteIndexTemplateResponse>(p)
			);

		/// <inheritdoc/>
		public Task<IDeleteIndexTemplateResponse> DeleteIndexTemplateAsync(
			Name name, Func<DeleteIndexTemplateDescriptor,
			IDeleteIndexTemplateRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		) => this.DeleteIndexTemplateAsync(selector.InvokeOrDefault(new DeleteIndexTemplateDescriptor(name)), cancellationToken);

		/// <inheritdoc/>
		public Task<IDeleteIndexTemplateResponse> DeleteIndexTemplateAsync(IDeleteIndexTemplateRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
			this.Dispatcher.DispatchAsync<IDeleteIndexTemplateRequest, DeleteIndexTemplateRequestParameters, DeleteIndexTemplateResponse, IDeleteIndexTemplateResponse>(
				request,
				cancellationToken,
				(p, d, c) => this.LowLevelDispatch.IndicesDeleteTemplateDispatchAsync<DeleteIndexTemplateResponse>(p, c)
			);
	}
}
