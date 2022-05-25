using System;
using System.Collections.Generic;
using System.Json;
using System.Linq;
using System.Threading.Tasks;
using AthenaHealthDataAnalytics.Core.BLL.AthenaClient.Interface;
using BLL.AthenaClient;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace AthenaHealthDataAnalytics.Core.BLL.AthenaClient.Service
{
    public class GetPatientDocumentData:IGetPatientDocumentData
    {
        private APIConnection _ApiConnection { get; set; }
        private readonly AthenaHealthApiConnectionManager _athenaHealthApiConnectionManager;
        private readonly IAthenaApiHttpClient _athenaApiHttpClient;

        public GetPatientDocumentData(IAthenaHealthConfigs athenaHealthConfigs,IAthenaApiHttpClient athenaApiHttpClient)
        {
            _athenaApiHttpClient = athenaApiHttpClient;
            _athenaHealthApiConnectionManager = new AthenaHealthApiConnectionManager(athenaHealthConfigs);
            _ApiConnection = _athenaHealthApiConnectionManager.Connection;
            _athenaApiHttpClient = athenaApiHttpClient;

        }
        public async Task<List<BsonDocument>> GetPatientLabResultDetail(string patientid, string labresultid)
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"showtemplate", "true"},
            };
            try
            {
                string path = $"/patients/{patientid}/documents/labresult/{labresultid}"; // GET /patients/{patientid}/documents/labresult/{labresultid}
                apiResult = await _athenaApiHttpClient.GetJson(path, parameters);
                if (apiResult == null)
                {
                    return null;
                }

                var bsonData = BsonSerializer.Deserialize<List<BsonDocument>>(apiResult.ToString());

                return bsonData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        
        public async Task<List<BsonDocument>> GetPatientDocuments(string patientId, string departmentId)
        {
            try
            {
                var patientDocuments = new List<BsonDocument>();
                int offsetCounter = 0;
                const int offsetValue = 100;
                Dictionary<string, string> parameters = new Dictionary<string, string>
                {
                    {"departmentid", $"{departmentId}"},
                    {"showdeclinedorders", "true"},
                    {"showdeleted", "true"},
                    {"offset", $"{offsetCounter * offsetValue}"}
                };
                //?departmentid=3&showdeclinedorders=true&showdeleted=true

                string path = $"/patients/{patientId}/documents";
                bool isNextPath = true;
                while (isNextPath)
                {
                    JsonValue apiResult = await _athenaApiHttpClient.GetJson(path, parameters);
                    if (apiResult == null)
                    {
                        return null;
                    }

                    var bsonData = BsonSerializer.Deserialize<BsonDocument>(apiResult.ToString());
                    if (!bsonData.Names.AsQueryable().Contains("documents") ||
                        !bsonData.Names.AsQueryable().Contains("totalcount"))
                    {
                        break;
                    }

                    BsonElement count = bsonData.GetElement("totalcount");

                    if (count.Value.AsInt32 <= 0)
                    {
                        break;
                    }

                    var encounters = bsonData.GetElement("documents").Value.AsBsonArray;
                    if (encounters.Count > 0)
                    {
                        patientDocuments.AddRange(encounters.Select(e => e.AsBsonDocument).ToList());
                    }

                    isNextPath = bsonData.Names.AsQueryable().Contains("next");
                    offsetCounter++;
                    parameters["offset"] = $"{offsetCounter * offsetValue}";
                }

                return patientDocuments;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
    }
}