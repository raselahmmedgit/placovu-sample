﻿using System;
using System.Threading.Tasks;
using Elasticsearch.Net;
using FluentAssertions;
using Tests.Framework;
using static Tests.Framework.TimesHelper;
using static Elasticsearch.Net.AuditEvent;

namespace Tests.ClientConcepts.ConnectionPooling.Sniffing
{
	public class OnConnectionFailure
	{
		/**=== Sniffing on connection failure
		*
		* Sniffing on connection is enabled by default when using a connection pool that allows reseeding.
		* The only connection pool we ship with that allows this is the <<sniffing-connection-pool, Sniffing connection pool>>.
		*
		* This can be very handy to force a refresh of the connection pool's known healthy nodes by asking the Elasticsearch cluster itself, and
		* a sniff tries to get the nodes by asking each node it currently knows about, until one responds.
		*/

		[U] public async Task DoesASniffAfterConnectionFailure()
		{
			/**
			* Here we seed our connection with 5 known nodes on ports 9200-9204, of which we think
			* 9202, 9203, 9204 are master eligible nodes. Our virtualized cluster will throw once when doing
			* a search on 9201. This should cause a sniff to be kicked off.
			*/
			var audit = new Auditor(() => Framework.Cluster
				.Nodes(5)
				.MasterEligible(9202, 9203, 9204)
				.ClientCalls(r => r.SucceedAlways())
				.ClientCalls(r => r.OnPort(9201).Fails(Once)) // <1> When the call fails on 9201, the following sniff succeeds and returns a new cluster state of healthy nodes. This cluster only has 3 nodes and the known masters are 9200 and 9202. A search on 9201 is setup to still fail once
                .Sniff(p => p.SucceedAlways(Framework.Cluster
					.Nodes(3)
					.MasterEligible(9200, 9202)
					.ClientCalls(r => r.OnPort(9201).Fails(Once))
					.Sniff(s => s.SucceedAlways(Framework.Cluster // <2> After this second failure on 9201, another sniff will happen which returns a cluster state that no longer fails but looks completely different; It's now three nodes on ports 9210 - 9212, with 9210 and 9212 being master eligible.
                        .Nodes(3, 9210)
						.MasterEligible(9210, 9212)
						.ClientCalls(r => r.SucceedAlways())
						.Sniff(r => r.SucceedAlways())
					))
				))
				.SniffingConnectionPool()
				.Settings(s => s.DisablePing().SniffOnStartup(false))
			);

			audit = await audit.TraceCalls(
			/** */
				new ClientCall {
					{ HealthyResponse, 9200 },
					{ pool =>  pool.Nodes.Count.Should().Be(5) }
				},
				new ClientCall {
					{ BadResponse, 9201},
					{ SniffOnFail },
					{ SniffSuccess, 9202}, // <3> We assert we do a sniff on our first known master node 9202 after the failed call on 9201
					{ HealthyResponse, 9200},
					{ pool =>  pool.Nodes.Count.Should().Be(3) } // <4> Our pool should now have three nodes
				},
				new ClientCall {
					{ BadResponse, 9201},
					{ SniffOnFail }, // <5> We assert we do a sniff on the first master node in our updated cluster
					{ SniffSuccess, 9200},
					{ HealthyResponse, 9210},
					{ pool =>  pool.Nodes.Count.Should().Be(3) }
				},
				new ClientCall { { HealthyResponse, 9211 } },
				new ClientCall { { HealthyResponse, 9212 } },
				new ClientCall { { HealthyResponse, 9210 } },
				new ClientCall { { HealthyResponse, 9211 } },
				new ClientCall { { HealthyResponse, 9212 } },
				new ClientCall { { HealthyResponse, 9210 } },
				new ClientCall { { HealthyResponse, 9211 } },
				new ClientCall { { HealthyResponse, 9212 } },
				new ClientCall { { HealthyResponse, 9210 } }
			);
		}

        /**==== Sniffing after ping failure
         *
         */
		[U] public async Task DoesASniffAfterConnectionFailureOnPing()
		{
			/** Here we set up our cluster exactly the same as the previous setup
			* Only we enable pinging (default is `true`) and make the ping fail
			*/
			var audit = new Auditor(() => Framework.Cluster
				.Nodes(5)
				.MasterEligible(9202, 9203, 9204)
				.Ping(r => r.OnPort(9201).Fails(Once))
				.Sniff(p => p.SucceedAlways(Framework.Cluster
					.Nodes(3)
					.MasterEligible(9200, 9202)
					.Ping(r => r.OnPort(9201).Fails(Once))
					.Sniff(s => s.SucceedAlways(Framework.Cluster
						.Nodes(3, 9210)
						.MasterEligible(9210, 9211)
						.Ping(r => r.SucceedAlways())
						.Sniff(r => r.SucceedAlways())
					))
				))
				.SniffingConnectionPool()
				.Settings(s => s.SniffOnStartup(false))
			);

			audit = await audit.TraceCalls(
				new ClientCall {
					{ PingSuccess, 9200 },
					{ HealthyResponse, 9200 },
					{ pool =>  pool.Nodes.Count.Should().Be(5) }
				},
				new ClientCall {
					{ PingFailure, 9201},
					{ SniffOnFail }, // <1> We assert we do a sniff on our first known master node 9202
					{ SniffSuccess, 9202},
					{ PingSuccess, 9200},
					{ HealthyResponse, 9200},
					{ pool =>  pool.Nodes.Count.Should().Be(3) } // <2> Our pool should now have three nodes
				},
				new ClientCall {
					{ PingFailure, 9201},
					{ SniffOnFail }, // <3> We assert we do a sniff on the first master node in our updated cluster
					{ SniffSuccess, 9200},
					{ PingSuccess, 9210},
					{ HealthyResponse, 9210},
					{ pool =>  pool.Nodes.Count.Should().Be(3) }
				},
				new ClientCall {
					{ PingSuccess, 9211 },
					{ HealthyResponse, 9211 }
				},
				new ClientCall {
					{ PingSuccess, 9212 },
					{ HealthyResponse, 9212 }
				},
				new ClientCall { { HealthyResponse, 9210 } }, // <4> 9210 was already pinged after the sniff returned the new nodes
                new ClientCall { { HealthyResponse, 9211 } },
				new ClientCall { { HealthyResponse, 9212 } },
				new ClientCall { { HealthyResponse, 9210 } }
			);
		}

        /**==== Client uses publish address
         *
         */
		[U] public async Task UsesPublishAddress()
		{
			var audit = new Auditor(() => Framework.Cluster
					.Nodes(2)
					.MasterEligible(9200)
					.Ping(r => r.OnPort(9200).Fails(Once))
					.Sniff(p => p.SucceedAlways(Framework.Cluster
							.Nodes(10)
							.MasterEligible(9200, 9202, 9201)
							.PublishAddress("10.0.12.1")
					))
					.SniffingConnectionPool()
					.Settings(s => s.SniffOnStartup(false))
			);

			Action<Audit, string, int> hostAssert = (a, host, expectedPort) =>
			{
				a.Node.Uri.Host.Should().Be(host);
				a.Node.Uri.Port.Should().Be(expectedPort);
			};

			audit = await audit.TraceCalls(
				new ClientCall {
					{ PingFailure, a => hostAssert(a, "localhost", 9200)},
					{ SniffOnFail },
					{ SniffSuccess, a => hostAssert(a, "localhost", 9200)},
					{ PingSuccess, a => hostAssert(a, "10.0.12.1", 9200)},
					{ HealthyResponse,  a => hostAssert(a, "10.0.12.1", 9200)},
					{ pool =>  pool.Nodes.Count.Should().Be(10) } // <1> Our pool should now have 10 nodes
				}
			);
		}
	}
}
