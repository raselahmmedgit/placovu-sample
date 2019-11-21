﻿using System;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Tests.Framework;
using static Elasticsearch.Net.AuditEvent;

namespace Tests.ClientConcepts.ConnectionPooling.RequestOverrides
{
	public class RespectsMaxRetryOverrides
	{
		/**=== Maximum retries per request
		*
		* By default retry as many times as we have nodes. However retries still respect the request timeout.
		* Meaning if you have a 100 node cluster and a request timeout of 20 seconds we will retry as many times as we can
		* but give up after 20 seconds
		*/

		[U]
		public async Task DefaultMaxIsNumberOfNodes()
		{
			var audit = new Auditor(() => Framework.Cluster
				.Nodes(10)
				.ClientCalls(r => r.FailAlways())
				.ClientCalls(r => r.OnPort(9209).SucceedAlways())
				.StaticConnectionPool()
				.Settings(s => s.DisablePing())
			);

			audit = await audit.TraceCall(
				new ClientCall(r => r.MaxRetries(2)) {
					{ BadResponse, 9200 },
					{ BadResponse, 9201 },
					{ BadResponse, 9202 },
					{ MaxRetriesReached }
				}
			);
		}

		/**
		* When you have a 100 node cluster you might want to ensure a fixed number of retries.
		* Remember that the actual number of requests is initial attempt + set number of retries
		*/

		[U]
		public async Task FixedMaximumNumberOfRetries()
		{
			var audit = new Auditor(() => Framework.Cluster
				.Nodes(10)
				.ClientCalls(r => r.FailAlways())
				.ClientCalls(r => r.OnPort(9209).SucceedAlways())
				.StaticConnectionPool()
				.Settings(s => s.DisablePing().MaximumRetries(5))
			);

			audit = await audit.TraceCall(
				new ClientCall(r => r.MaxRetries(2)) {
					{ BadResponse, 9200 },
					{ BadResponse, 9201 },
					{ BadResponse, 9202 },
					{ MaxRetriesReached }
				}
			);
		}

		/**
		* This makes setting any retry setting on a single node connection pool a NOOP, this is by design!
		* Connection pooling and connection failover is about trying to fail sanely whilst still utilizing available resources and
		* not giving up on the fail fast principle. It's *NOT* a mechanism for forcing requests to succeed.
		*/
		[U]
		public async Task DoesNotRetryOnSingleNodeConnectionPool()
		{
			var audit = new Auditor(() => Framework.Cluster
				.Nodes(10)
				.ClientCalls(r => r.FailAlways().Takes(TimeSpan.FromSeconds(3)))
				.ClientCalls(r => r.OnPort(9209).SucceedAlways())
				.SingleNodeConnection()
				.Settings(s => s.DisablePing().MaximumRetries(10))
			);

			audit = await audit.TraceCall(
				new ClientCall(r => r.MaxRetries(10)) {
					{ BadResponse, 9200 }
				}
			);

		}
	}
}
