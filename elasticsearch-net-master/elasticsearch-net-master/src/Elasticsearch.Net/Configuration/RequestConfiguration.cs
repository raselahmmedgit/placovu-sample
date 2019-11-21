using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Elasticsearch.Net
{
	public interface IRequestConfiguration
	{
		/// <summary>
		/// The timeout for this specific request, takes precedence over the global timeout settings
		/// </summary>
		TimeSpan? RequestTimeout { get; set; }

		/// <summary>
		/// The ping timeout for this specific request
		/// </summary>
		TimeSpan? PingTimeout { get; set;  }

		/// <summary>
		/// Force a different Content-Type header on the request
		/// </summary>
		string ContentType { get; set; }

		/// <summary>
		/// Force a different Accept header on the request
		/// </summary>
		string Accept { get; set; }

		/// <summary>
		/// This will override whatever is set on the connection configuration or whatever default the connectionpool has.
		/// </summary>
		int? MaxRetries { get; set; }

		/// <summary>
		/// This will force the operation on the specified node, this will bypass any configured connection pool and will no retry.
		/// </summary>
		Uri ForceNode { get; set; }

		/// <summary>
		/// Forces no sniffing to occur on the request no matter what configuration is in place
		/// globally
		/// </summary>
		bool? DisableSniff { get; set; }

		/// <summary>
		/// Under no circumstance do a ping before the actual call. If a node was previously dead a small ping with
		/// low connect timeout will be tried first in normal circumstances
		/// </summary>
		bool? DisablePing { get; set; }

		/// <summary>
		/// Whether to buffer the request and response bytes for the call
		/// </summary>
		bool? DisableDirectStreaming { get; set; }

		/// <summary>
		/// Treat the following statuses (on top of the 200 range) NOT as error.
		/// </summary>
		IEnumerable<int> AllowedStatusCodes { get; set; }

		/// <summary>
		/// Basic access authorization credentials to specify with this request.
		/// Overrides any credentials that are set at the global IConnectionSettings level.
		/// </summary>
		BasicAuthenticationCredentials BasicAuthenticationCredentials { get; set; }

		/// <summary>
		/// Whether or not this request should be pipelined. http://en.wikipedia.org/wiki/HTTP_pipelining defaults to true
		/// </summary>
		bool EnableHttpPipelining { get; set; }

		/// <summary>
		/// Submit the request on behalf in the context of a different shield user
		/// <pre/>https://www.elastic.co/guide/en/shield/current/submitting-requests-for-other-users.html
		/// </summary>
		string RunAs { get; set; }

		/// <summary>
		/// Use the following client certificates to authenticate this single request
		/// </summary>
		X509CertificateCollection ClientCertificates { get; set; }
	}

	public class RequestConfiguration : IRequestConfiguration
	{
		public TimeSpan? RequestTimeout { get; set; }
		public TimeSpan? PingTimeout { get; set; }
		public string ContentType { get; set; }
		public string Accept { get; set; }
		public int? MaxRetries { get; set; }
		public Uri ForceNode { get; set; }
		public bool? DisableSniff { get; set; }
		public bool? DisablePing { get; set; }
		public bool? DisableDirectStreaming { get; set; }
		public IEnumerable<int> AllowedStatusCodes { get; set; }
		public BasicAuthenticationCredentials BasicAuthenticationCredentials { get; set; }
		public bool EnableHttpPipelining { get; set; } = true;
		public CancellationToken CancellationToken { get; set; }
		/// <summary>
		/// Submit the request on behalf in the context of a different user
		/// https://www.elastic.co/guide/en/shield/current/submitting-requests-for-other-users.html
		/// </summary>
		public string RunAs { get; set; }

		public X509CertificateCollection ClientCertificates { get; set; }
	}

	public class RequestConfigurationDescriptor : IRequestConfiguration
	{
		private IRequestConfiguration Self => this;
		TimeSpan? IRequestConfiguration.RequestTimeout { get; set; }
		TimeSpan? IRequestConfiguration.PingTimeout { get; set; }
		string IRequestConfiguration.ContentType { get; set; }
		string IRequestConfiguration.Accept { get; set; }

		int? IRequestConfiguration.MaxRetries { get; set; }
		Uri IRequestConfiguration.ForceNode { get; set; }
		bool? IRequestConfiguration.DisableSniff { get; set; }
		bool? IRequestConfiguration.DisablePing { get; set; }
		bool? IRequestConfiguration.DisableDirectStreaming { get; set; }
		IEnumerable<int> IRequestConfiguration.AllowedStatusCodes { get; set; }
		BasicAuthenticationCredentials IRequestConfiguration.BasicAuthenticationCredentials { get; set; }
		bool IRequestConfiguration.EnableHttpPipelining { get; set; } = true;
		string IRequestConfiguration.RunAs { get; set; }
		X509CertificateCollection IRequestConfiguration.ClientCertificates { get; set; }

		public RequestConfigurationDescriptor(IRequestConfiguration config)
		{
			Self.RequestTimeout = config?.RequestTimeout;
			Self.PingTimeout = config?.PingTimeout;
			Self.ContentType = config?.ContentType;
			Self.Accept = config?.Accept;
			Self.MaxRetries = config?.MaxRetries;
			Self.ForceNode = config?.ForceNode;
			Self.DisableSniff = config?.DisableSniff;
			Self.DisablePing = config?.DisablePing;
			Self.DisableDirectStreaming = config?.DisableDirectStreaming;
			Self.AllowedStatusCodes = config?.AllowedStatusCodes;
			Self.BasicAuthenticationCredentials = config?.BasicAuthenticationCredentials;
			Self.EnableHttpPipelining = config?.EnableHttpPipelining ?? true;
			Self.RunAs = config?.RunAs;
			Self.ClientCertificates = config?.ClientCertificates;
		}

		/// <summary>
		/// Submit the request on behalf in the context of a different shield user
		/// <pre/>https://www.elastic.co/guide/en/shield/current/submitting-requests-for-other-users.html
		/// </summary>
		public RequestConfigurationDescriptor RunAs(string username)
		{
			Self.RunAs = username;
			return this;
		}

		public RequestConfigurationDescriptor RequestTimeout(TimeSpan requestTimeout)
		{
			Self.RequestTimeout = requestTimeout;
			return this;
		}

		public RequestConfigurationDescriptor PingTimeout(TimeSpan pingTimeout)
		{
			Self.PingTimeout = pingTimeout;
			return this;
		}

		public RequestConfigurationDescriptor ContentType(string contentTypeHeader)
		{
			Self.ContentType = contentTypeHeader;
			return this;
		}

		public RequestConfigurationDescriptor Accept(string acceptHeader)
		{
			Self.Accept = acceptHeader;
			return this;
		}

		public RequestConfigurationDescriptor AllowedStatusCodes(IEnumerable<int> codes)
		{
			Self.AllowedStatusCodes = codes;
			return this;
		}

		public RequestConfigurationDescriptor AllowedStatusCodes(params int[] codes)
		{
			Self.AllowedStatusCodes = codes;
			return this;
		}

		public RequestConfigurationDescriptor DisableSniffing(bool? disable = true)
		{
			Self.DisableSniff = disable;
			return this;
		}

		public RequestConfigurationDescriptor DisablePing(bool? disable = true)
		{
			Self.DisablePing = disable;
			return this;
		}

		public RequestConfigurationDescriptor DisableDirectStreaming(bool? disable = true)
		{
			Self.DisableDirectStreaming = disable;
			return this;
		}

		public RequestConfigurationDescriptor ForceNode(Uri uri)
		{
			Self.ForceNode = uri;
			return this;
		}

		public RequestConfigurationDescriptor MaxRetries(int retry)
		{
			Self.MaxRetries = retry;
			return this;
		}

		public RequestConfigurationDescriptor BasicAuthentication(string userName, string password)
		{
			if (Self.BasicAuthenticationCredentials == null)
				Self.BasicAuthenticationCredentials = new BasicAuthenticationCredentials();
			Self.BasicAuthenticationCredentials.Username = userName;
			Self.BasicAuthenticationCredentials.Password = password;
			return this;
		}

		public RequestConfigurationDescriptor EnableHttpPipelining(bool enable = true)
		{
			Self.EnableHttpPipelining = enable;
			return this;
		}

		/// <summary> Use the following client certificates to authenticate this request to Elasticsearch </summary>
		public RequestConfigurationDescriptor ClientCertificates(X509CertificateCollection certificates)
		{
			Self.ClientCertificates = certificates;
			return this;
		}

		/// <summary> Use the following client certificate to authenticate this request to Elasticsearch </summary>
		public RequestConfigurationDescriptor ClientCertificate(X509Certificate certificate) =>
			this.ClientCertificates(new X509Certificate2Collection { certificate });

		/// <summary> Use the following client certificate to authenticate this request to Elasticsearch </summary>
		public RequestConfigurationDescriptor ClientCertificate(string certificatePath) =>
			this.ClientCertificates(new X509Certificate2Collection {new X509Certificate(certificatePath)});
	}
}
