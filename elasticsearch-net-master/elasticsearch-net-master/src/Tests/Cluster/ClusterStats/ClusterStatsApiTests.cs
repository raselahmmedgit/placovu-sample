﻿using System.Linq;
using Elasticsearch.Net;
using FluentAssertions;
using Nest;
using Tests.Framework;
using Tests.Framework.Integration;
using Tests.Framework.ManagedElasticsearch.Clusters;
using Xunit;

namespace Tests.Cluster.ClusterStats
{
	public class ClusterStatsApiTests : ApiIntegrationTestBase<ReadOnlyCluster, IClusterStatsResponse, IClusterStatsRequest, ClusterStatsDescriptor, ClusterStatsRequest>
	{
		public ClusterStatsApiTests(ReadOnlyCluster cluster, EndpointUsage usage) : base(cluster, usage) { }
		protected override LazyResponses ClientUsage() => Calls(
			fluent: (client, f) => client.ClusterStats(),
			fluentAsync: (client, f) => client.ClusterStatsAsync(),
			request: (client, r) => client.ClusterStats(r),
			requestAsync: (client, r) => client.ClusterStatsAsync(r)
		);

		protected override bool ExpectIsValid => true;
		protected override int ExpectStatusCode => 200;
		protected override HttpMethod HttpMethod => HttpMethod.GET;
		protected override string UrlPath => "/_cluster/stats";

		protected override void ExpectResponse(IClusterStatsResponse response)
		{
			response.ClusterName.Should().NotBeNullOrWhiteSpace();
			response.Status.Should().NotBe(ClusterStatus.Red);
			response.Timestamp.Should().BeGreaterThan(0);
			Assert(response.Nodes);
			Assert(response.Indices);
		}

		protected void Assert(ClusterNodesStats nodes)
		{
			nodes.Should().NotBeNull();
			nodes.Count.Should().NotBeNull();
			nodes.Count.Master.Should().BeGreaterOrEqualTo(1);

			nodes.FileSystem.Should().NotBeNull();
			nodes.FileSystem.AvailableInBytes.Should().BeGreaterThan(0);
			nodes.FileSystem.FreeInBytes.Should().BeGreaterThan(0);
			nodes.FileSystem.TotalInBytes.Should().BeGreaterThan(0);

			nodes.Jvm.Should().NotBeNull();
			nodes.Jvm.MaxUptimeInMilliseconds.Should().BeGreaterThan(0);
			nodes.Jvm.Threads.Should().BeGreaterThan(0);
			nodes.Jvm.Memory.Should().NotBeNull();
			nodes.Jvm.Memory.HeapMaxInBytes.Should().BeGreaterThan(0);
			nodes.Jvm.Memory.HeapUsedInBytes.Should().BeGreaterThan(0);

			nodes.Jvm.Versions.Should().NotBeEmpty();
			var version = nodes.Jvm.Versions.First();
			version.Count.Should().BeGreaterThan(0);
			version.Version.Should().NotBeNullOrWhiteSpace();
			version.VmName.Should().NotBeNullOrWhiteSpace();
			version.VmVendor.Should().NotBeNullOrWhiteSpace();
			version.VmVersion.Should().NotBeNullOrWhiteSpace();

			nodes.OperatingSystem.Should().NotBeNull();
			nodes.OperatingSystem.AvailableProcessors.Should().BeGreaterThan(0);
			nodes.OperatingSystem.AllocatedProcessors.Should().BeGreaterThan(0);

			nodes.OperatingSystem.Names.Should().NotBeEmpty();

			var plugins = nodes.Plugins;
			plugins.Should().NotBeEmpty();

			var plugin = plugins.First();
			plugin.Name.Should().NotBeNullOrWhiteSpace();
			plugin.Description.Should().NotBeNullOrWhiteSpace();
			plugin.Version.Should().NotBeNullOrWhiteSpace();
			plugin.ClassName.Should().NotBeNullOrWhiteSpace();

			nodes.Process.Should().NotBeNull();
			nodes.Process.Cpu.Should().NotBeNull();
			nodes.Process.OpenFileDescriptors.Should().NotBeNull();
			nodes.Process.OpenFileDescriptors.Max.Should().NotBe(0);
			nodes.Process.OpenFileDescriptors.Min.Should().NotBe(0);

			nodes.Versions.Should().NotBeEmpty();
		}

		protected void Assert(ClusterIndicesStats indices)
		{
			indices.Should().NotBeNull();
			indices.Count.Should().BeGreaterThan(0);

			indices.Documents.Should().NotBeNull();
			indices.Documents.Count.Should().BeGreaterThan(0);

			indices.Completion.Should().NotBeNull();
			indices.Fielddata.Should().NotBeNull();
			indices.QueryCache.Should().NotBeNull();

			indices.Segments.Should().NotBeNull();
			indices.Segments.Count.Should().BeGreaterThan(0);
			indices.Segments.DocValuesMemoryInBytes.Should().BeGreaterThan(0);
			indices.Segments.MemoryInBytes.Should().BeGreaterThan(0);
			indices.Segments.NormsMemoryInBytes.Should().BeGreaterThan(0);
			indices.Segments.StoredFieldsMemoryInBytes.Should().BeGreaterThan(0);
			indices.Segments.TermsMemoryInBytes.Should().BeGreaterThan(0);

			indices.Shards.Should().NotBeNull();
			indices.Shards.Primaries.Should().BeGreaterThan(0);
			indices.Shards.Total.Should().BeGreaterThan(0);
			indices.Shards.Index.Primaries.Should().NotBeNull();
			indices.Shards.Index.Primaries.Avg.Should().BeGreaterThan(0);
			indices.Shards.Index.Primaries.Min.Should().BeGreaterThan(0);
			indices.Shards.Index.Primaries.Max.Should().BeGreaterThan(0);
			indices.Shards.Index.Replication.Should().NotBeNull();
			indices.Shards.Index.Shards.Should().NotBeNull();
			indices.Shards.Index.Shards.Avg.Should().BeGreaterThan(0);
			indices.Shards.Index.Shards.Min.Should().BeGreaterThan(0);
			indices.Shards.Index.Shards.Max.Should().BeGreaterThan(0);

			indices.Store.Should().NotBeNull();
			indices.Store.SizeInBytes.Should().BeGreaterThan(0);
		}
	}
}
