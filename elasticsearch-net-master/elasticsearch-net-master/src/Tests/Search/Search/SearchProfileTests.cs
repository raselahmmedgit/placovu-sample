using Nest;
using Tests.Framework;
using Tests.Framework.Integration;
using Tests.Framework.ManagedElasticsearch;
using Tests.Framework.ManagedElasticsearch.Clusters;
using Tests.Framework.MockData;
using Tests.Framework.Profiling.Timeline;

namespace Tests.Search.Search
{
    public class SearchProfileTests
    {
        private readonly IElasticClient _client;

        public SearchProfileTests(ClusterBase cluster)
        {
            _client = cluster.Client;
        }

        [Timeline(Iterations = 1000)]
        public void Deserialization()
        {
            _client.Search<Developer>(s => s.Query(q => q.MatchAll()));
        }

        [Timeline(Iterations = 1000)]
        public void Serialization()
        {
            TestClient.DefaultInMemoryClient.Search<Developer>();
        }
    }
}
