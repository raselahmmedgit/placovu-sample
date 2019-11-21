﻿using System.Threading.Tasks;
using Tests.Framework;
using static Elasticsearch.Net.AuditEvent;

namespace Tests.ClientConcepts.ConnectionPooling.FailOver
{
	public class FallingOver
	{
		/**[[fail-over]]
		* === Fail over
		* When using a connection pool with more than one node, a request will be retried if
		* the call to a node throws an exception or returns a 502, 503 or 504 response
		*/
		[U]
		public async Task ExceptionFallsOverToNextNode()
		{
			var audit = new Auditor(() => Framework.Cluster
				.Nodes(10)
				.ClientCalls(r => r.FailAlways())
				.ClientCalls(r => r.OnPort(9201).SucceedAlways())
				.StaticConnectionPool()
				.Settings(s => s.DisablePing())
			);

			audit = await audit.TraceCall(
				new ClientCall {
					{ BadResponse, 9200 },
					{ HealthyResponse, 9201 },
				}
			);
		}

		/**[[bad-gateway]]
		*==== 502 Bad Gateway
		*
		* Will be treated as an error that requires retrying
		*/
		[U]
		public async Task Http502FallsOver()
		{
			var audit = new Auditor(() => Framework.Cluster
				.Nodes(10)
				.ClientCalls(r => r.FailAlways(502))
				.ClientCalls(r => r.OnPort(9201).SucceedAlways())
				.StaticConnectionPool()
				.Settings(s => s.DisablePing())
			);

			audit = await audit.TraceCall(
				new ClientCall {
					{ BadResponse, 9200 },
					{ HealthyResponse, 9201 },
				}
			);
		}

		/**[[service-unavailable]]
		*==== 503 Service Unavailable
		*
		* Will be treated as an error that requires retrying
		*/
		[U]
		public async Task Http503FallsOver()
		{
			var audit = new Auditor(() => Framework.Cluster
				.Nodes(10)
				.ClientCalls(r => r.FailAlways(503))
				.ClientCalls(r => r.OnPort(9201).SucceedAlways())
				.StaticConnectionPool()
				.Settings(s => s.DisablePing())
			);

			audit = await audit.TraceCall(
				new ClientCall {
					{ BadResponse, 9200 },
					{ HealthyResponse, 9201 },
				}
			);
		}

		/**[[gateway-timeout]]
		*==== 504 Gateway Timeout
		*
		* Will be treated as an error that requires retrying
		*/
		[U]
		public async Task Http504FallsOver()
		{
			var audit = new Auditor(() => Framework.Cluster
				.Nodes(10)
				.ClientCalls(r => r.FailAlways(504))
				.ClientCalls(r => r.OnPort(9201).SucceedAlways())
				.StaticConnectionPool()
				.Settings(s => s.DisablePing())
			);

			audit = await audit.TraceCall(
				new ClientCall {
					{ BadResponse, 9200 },
					{ HealthyResponse, 9201 },
				}
			);
		}

		/**
		* If a call returns a __valid__ HTTP status code other than 502 or 503, the request won't be retried.
		*
		* IMPORTANT: Different requests may have different status codes that are deemed __valid__. For example,
		* a *404 Not Found* response is a __valid__ status code for an index exists request
		*/
		[U]
		public async Task HttpTeapotDoesNotFallOver()
		{
			var audit = new Auditor(() => Framework.Cluster
				.Nodes(10)
				.ClientCalls(r => r.FailAlways(418))
				.ClientCalls(r => r.OnPort(9201).SucceedAlways())
				.StaticConnectionPool()
				.Settings(s => s.DisablePing())
			);

			audit = await audit.TraceCall(
				new ClientCall {
					{ BadResponse, 9200 },
				}
			);
		}
	}
}
