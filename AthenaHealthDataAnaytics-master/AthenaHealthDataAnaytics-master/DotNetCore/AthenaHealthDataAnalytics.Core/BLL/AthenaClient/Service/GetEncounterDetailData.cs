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
    public class GetEncounterDetailData : IGetEncounterDetailData
    {
        private APIConnection _ApiConnection { get; }
        private readonly AthenaHealthApiConnectionManager _athenaHealthApiConnectionManager;
        private readonly IAthenaApiHttpClient _athenaApiHttpClient;

        
        public GetEncounterDetailData(IAthenaHealthConfigs athenaHealthConfigs,IAthenaApiHttpClient athenaApiHttpClient)
        {
            _athenaHealthApiConnectionManager = new AthenaHealthApiConnectionManager(athenaHealthConfigs);
            _ApiConnection = _athenaHealthApiConnectionManager.Connection;
            _athenaApiHttpClient = athenaApiHttpClient;

        }
        
        public async Task<BsonDocument> GetEncounterServices(string encounterid)
        {
            try
            {
                var patientDocuments = new List<BsonDocument>();
                string path = $"/encounter/{encounterid}/services";//  GET /encounter/{encounterid}/services 
                JsonValue apiResult = await _athenaApiHttpClient.GetJson(path);
                if (apiResult == null)
                {
                    return null;
                }

                var bsonData = BsonSerializer.Deserialize<BsonDocument>(apiResult.ToString());


                return bsonData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public async Task<List<BsonDocument>> GetEncounterVitals(string encounterid)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"allowdischargetype", "true"},
                {"showclinicalprovider", "true"},
                {"showdeclinedorders", "true"},
                {"showdiagnoseswithoutorders", "true"},
                {"showexternalcodes", "true"},
            };
            try
            {
                var patientDocuments = new List<BsonDocument>();
                string path = $"/chart/encounter/{encounterid}/vitals"; //GET /chart/encounter/{encounterid}/vitals  
                JsonValue apiResult = await _athenaApiHttpClient.GetJson(path);
                if (apiResult == null)
                {
                    return null;
                }

                var bsonData = BsonSerializer.Deserialize<List<BsonDocument>>(apiResult.ToString());


                if (bsonData.Count <= 0)
                {
                    return null;
                }

                patientDocuments.AddRange(bsonData);

                return patientDocuments;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public async Task<List<BsonDocument>> GetEncounterProcedureDocumentation(string encounterid)
        {
            JsonValue apiResult;
            int offsetCounter = 0;
            const int offsetValue = 100;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"showhtml", "false"},
                {"limit",offsetValue.ToString()},
                {"offset", $"{offsetCounter * offsetValue}"},
            };
            try
            {
                string path = $"/chart/encounter/{encounterid}/proceduredocumentation"; // GET /chart/encounter/{encounterid}/proceduredocumentation 
                bool isNextPath = true;
                var procedureDocumentationList = new List<BsonDocument>();
                while (isNextPath)
                {
                    apiResult = await _athenaApiHttpClient.GetJson(path, parameters);
                    if (apiResult == null)
                    {
                        return null;
                    }

                    var bsonData = BsonSerializer.Deserialize<BsonDocument>(apiResult.ToString());
                    
                    if (!bsonData.Names.AsQueryable().Contains("proceduredocumentation") ||
                        !bsonData.Names.AsQueryable().Contains("totalcount"))
                    {
                        break;
                    }

                    BsonElement count = bsonData.GetElement("totalcount");

                    if (count.Value.AsInt32 <= 0)
                    {
                        break;
                    }

                    var procedures = bsonData.GetElement("proceduredocumentation").Value.AsBsonArray;
                    if (procedures.Count > 0)
                    {
                        procedureDocumentationList.AddRange(procedures.Select(e => e.AsBsonDocument).ToList());
                    }

                    isNextPath = bsonData.Names.AsQueryable().Contains("next");
                    offsetCounter++;
                    parameters["offset"] = $"{offsetCounter * offsetValue}";
                }

                return procedureDocumentationList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public async Task<BsonDocument> GetEncounterPhysicalExam(string encounterid)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"showstructured", "true"},
            };
            try
            {
                var patientDocuments = new List<BsonDocument>();
                string path = $"/chart/encounter/{encounterid}/physicalexam";// GET /chart/encounter/{encounterid}/physicalexam 
                JsonValue apiResult = await _athenaApiHttpClient.GetJson(path,parameters);
                if (apiResult == null)
                {
                    return null;
                }

                var bsonData = BsonSerializer.Deserialize<BsonDocument>(apiResult.ToString());


                return bsonData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public async Task<List<BsonDocument>> GetEncounterOrders(string encounterid)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"allowdischargetype", "true"},
                {"showclinicalprovider", "true"},
                {"showdeclinedorders", "true"},
                {"showdiagnoseswithoutorders", "true"},
                {"showexternalcodes", "true"},
            };
            try
            {
                var patientDocuments = new List<BsonDocument>();
                string path = $"/chart/encounter/{encounterid}/orders"; // GET /chart/encounter/{encounterid}/orders 
                JsonValue apiResult = await _athenaApiHttpClient.GetJson(path);
                if (apiResult == null)
                {
                    return null;
                }

                var bsonData = BsonSerializer.Deserialize<List<BsonDocument>>(apiResult.ToString());


                if (bsonData.Count <= 0)
                {
                    return null;
                }

                patientDocuments.AddRange(bsonData);

                return patientDocuments;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public async Task<BsonDocument> GetEncounterHpi(string encounterid)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"showstructured", "true"},
            };
            try
            {
                var patientDocuments = new List<BsonDocument>();
                string path = $"/chart/encounter/{encounterid}/hpi";// GET /chart/encounter/{encounterid}/hpi 
                JsonValue apiResult = await _athenaApiHttpClient.GetJson(path,parameters);
                if (apiResult == null)
                {
                    return null;
                }

                var bsonData = BsonSerializer.Deserialize<BsonDocument>(apiResult.ToString());


                return bsonData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<BsonDocument>> GetEncounterDiagnoses(string encounterid)
        {
            try
            {
                var patientDocuments = new List<BsonDocument>();
                string path = $"/chart/encounter/{encounterid}/diagnoses";
                JsonValue apiResult = await _athenaApiHttpClient.GetJson(path);
                if (apiResult == null)
                {
                    return null;
                }

                var bsonData = BsonSerializer.Deserialize<List<BsonDocument>>(apiResult.ToString());


                if (bsonData.Count <= 0)
                {
                    return null;
                }

                patientDocuments.AddRange(bsonData);

                return patientDocuments;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<BsonDocument>> GetEncounterDescription(string encounterid)
        {
            try
            {
                var patientDocuments = new List<BsonDocument>();
                string path = $"/chart/encounter/{encounterid}";
                JsonValue apiResult = await _athenaApiHttpClient.GetJson(path);
                if (apiResult == null)
                {
                    return null;
                }

                var bsonData = BsonSerializer.Deserialize<List<BsonDocument>>(apiResult.ToString());


                if (bsonData.Count <= 0)
                {
                    return null;
                }

                patientDocuments.AddRange(bsonData);

                return patientDocuments;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<BsonDocument> GetEncounterAssessment(string encounterid)
        {
            try
            {
                var patientDocuments = new List<BsonDocument>();
                string path = $"/chart/encounter/{encounterid}/assessment ";
                JsonValue apiResult = await _athenaApiHttpClient.GetJson(path);
                if (apiResult == null)
                {
                    return null;
                }

                var bsonData = BsonSerializer.Deserialize<BsonDocument>(apiResult.ToString());
                return bsonData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<BsonDocument> GetEncounterDefaultSearchFacilities(string encounterid)
        {
            try
            {
                var patientDocuments = new List<BsonDocument>();
                string path = $"/chart/encounter/{encounterid}/defaultsearchfacilities ";
                JsonValue apiResult = await _athenaApiHttpClient.GetJson(path);
                if (apiResult == null)
                {
                    return null;
                }

                var bsonData = BsonSerializer.Deserialize<BsonDocument>(apiResult.ToString());


                return bsonData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        
    }
}