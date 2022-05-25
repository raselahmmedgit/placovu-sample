using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace AthenaHealthDataAnalytics.Core.BLL.MongoDBClient
{
    public class MongoDBConnectionManager
    {
        public static IMongoDatabase GetConnection(IMongoDatabaseSettings MongoDatabaseSettings)
        {
            try
            {
                var client = new MongoClient(MongoDatabaseSettings.ConnectionString);
                return client.GetDatabase(MongoDatabaseSettings.DatabaseName);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static bool CollectionExists(IMongoDatabase database, string collectionName)
        {
            try
            {
                var filter = new BsonDocument("name", collectionName);
                var options = new ListCollectionNamesOptions { Filter = filter };
                return database.ListCollectionNames(options).Any();
            }
            catch(Exception)
            {

            }
            return false;
            
        }
        public static void CreateCollection(IMongoDatabase database, string collectionName)
        {
            try
            {
                var isExist = CollectionExists(database, collectionName);
                if (!isExist)
                {
                    database.CreateCollection(collectionName);
                }
            }
            catch (Exception)
            {

            }
            
        }
    }
}
