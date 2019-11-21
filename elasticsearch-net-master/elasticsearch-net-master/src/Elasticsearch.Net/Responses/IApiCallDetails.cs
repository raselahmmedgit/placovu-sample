using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Elasticsearch.Net
{
	public interface IApiCallDetails
	{
		/// <summary>
		/// The response status code is in the 200 range or is in the allowed list of status codes set on the request.
		/// </summary>
		bool Success { get; }

		/// <summary>
		/// If <see cref="Success"/> is <c>false</c>, this will hold the original exception.
		/// This will be the orginating CLR exception in most cases.
		/// </summary>
		Exception OriginalException { get; }

		/// <summary>
		/// The error returned by Elasticsearch
		/// </summary>
		ServerError ServerError { get; }

		/// <summary>
		/// The HTTP method used by the request
		/// </summary>
		HttpMethod HttpMethod { get; }

		/// <summary>
		/// The url as requested
		/// </summary>
		Uri Uri { get; }

		/// <summary>
		/// The HTTP status code as returned by Elasticsearch
		/// </summary>
		int? HttpStatusCode { get; }

        /// <summary>
        /// The response body bytes.
        /// <para>NOTE: Only set when disable direct streaming is set for the request</para> 
        /// </summary>
        [DebuggerDisplay("{ResponseBodyInBytes != null ? System.Text.Encoding.UTF8.GetString(ResponseBodyInBytes) : null,nq}")]
		byte[] ResponseBodyInBytes { get; }

        /// <summary>
        /// The request body bytes.
        /// <para>NOTE: Only set when disable direct streaming is set for the request</para> 
        /// </summary>
        [DebuggerDisplay("{RequestBodyInBytes != null ? System.Text.Encoding.UTF8.GetString(RequestBodyInBytes) : null,nq}")]
		byte[] RequestBodyInBytes { get; }

        /// <summary>
        /// An audit trail of requests made to nodes within the cluster
        /// </summary>
        List<Audit> AuditTrail { get; }

        /// <summary>
        /// A lazy human readable string representation of what happened during this request for both successful and 
        /// failed requests.
        /// </summary>
        string DebugInformation { get; }

        /// <summary>
        ///A collection of deprecation warnings returned from Elasticsearch.
        ///<para>Used to signal that the request uses an API feature that is marked as deprecated</para>
        /// </summary>
        IEnumerable<string> DeprecationWarnings { get; }
	}
}
