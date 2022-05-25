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
    public class GetPatientHistoryChartData : IGetPatientHistoryChartData
    {
        
        private APIConnection _ApiConnection { get; }
        private readonly AthenaHealthApiConnectionManager _athenaHealthApiConnectionManager;
        private readonly IAthenaApiHttpClient _athenaApiHttpClient;

        
        public GetPatientHistoryChartData(IAthenaHealthConfigs athenaHealthConfigs,IAthenaApiHttpClient athenaApiHttpClient)
        {
            _athenaHealthApiConnectionManager = new AthenaHealthApiConnectionManager(athenaHealthConfigs);
            _ApiConnection = _athenaHealthApiConnectionManager.Connection;
            _athenaApiHttpClient = athenaApiHttpClient;

        }
        
        public async Task<List<BsonDocument>> GetPatientCcda(string patientid, string departmentid)
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
                {"format", "data portability"},
                {"purpose", "internal"},
                {"xmloutput", "false"},
            };
            
            try
            {
                string path = $"/patients/{patientid}/ccda";//GET /patients/{patientid}/ccda  
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
        
        public async Task<List<BsonDocument>> GetPatientVitals(string patientid, string departmentid)
        {
            JsonValue apiResult;
            int offsetCounter = 0;
            const int offsetValue = 100;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
                {"limit",offsetValue.ToString()},
                {"offset", $"{offsetCounter * offsetValue}"},
            };
            try
            {
                string path = $"/chart/{patientid}/vitals";// GET /chart/{patientid}/vitals 
                bool isNextPath = true;
                var patientVitals = new List<BsonDocument>();
                while (isNextPath)
                {
                    apiResult = await _athenaApiHttpClient.GetJson(path, parameters);
                    if (apiResult == null)
                    {
                        return null;
                    }

                    var bsonData = BsonSerializer.Deserialize<BsonDocument>(apiResult.ToString());
                    
                    if (!bsonData.Names.AsQueryable().Contains("vitals") ||
                        !bsonData.Names.AsQueryable().Contains("totalcount"))
                    {
                        break;
                    }

                    BsonElement count = bsonData.GetElement("totalcount");

                    if (count.Value.AsInt32 <= 0)
                    {
                        break;
                    }

                    var vital = bsonData.GetElement("vitals").Value.AsBsonArray;
                    if (vital.Count > 0)
                    {
                        patientVitals.AddRange(vital.Select(e => e.AsBsonDocument).ToList());
                    }

                    isNextPath = bsonData.Names.AsQueryable().Contains("next");
                    offsetCounter++;
                    parameters["offset"] = $"{offsetCounter * offsetValue}";
                }

                return patientVitals;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public async Task<List<BsonDocument>> GetPatientVaccines(string patientid, string departmentid)
        {
            JsonValue apiResult;
            int offsetCounter = 0;
            const int offsetValue = 100;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
                {"showdeclinedorders", "true"},
                {"showdeleted", "true"},
                {"showprescribednotadministered", "true"},
                {"showrefused", "true"},
                {"limit",offsetValue.ToString()},
                {"offset", $"{offsetCounter * offsetValue}"},
            };
            try
            {
                string path = $"/chart/{patientid}/vaccines";//GET /chart/{patientid}/vaccines 
                bool isNextPath = true;
                var patientVaccines = new List<BsonDocument>();
                while (isNextPath)
                {
                    apiResult = await _athenaApiHttpClient.GetJson(path, parameters);
                    if (apiResult == null)
                    {
                        return null;
                    }

                    var bsonData = BsonSerializer.Deserialize<BsonDocument>(apiResult.ToString());
                    
                    if (!bsonData.Names.AsQueryable().Contains("vaccines") ||
                        !bsonData.Names.AsQueryable().Contains("totalcount"))
                    {
                        break;
                    }

                    BsonElement count = bsonData.GetElement("totalcount");

                    if (count.Value.AsInt32 <= 0)
                    {
                        break;
                    }

                    var vaccineData = bsonData.GetElement("vaccines").Value.AsBsonArray;
                    if (vaccineData.Count > 0)
                    {
                        patientVaccines.AddRange(vaccineData.Select(e => e.AsBsonDocument).ToList());
                    }

                    isNextPath = bsonData.Names.AsQueryable().Contains("next");
                    offsetCounter++;
                    parameters["offset"] = $"{offsetCounter * offsetValue}";
                }

                return patientVaccines;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public async Task<BsonDocument> GetPatientSurgicalHistory(string patientid, string departmentid)
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
            };
            
            try
            {
                string path = $"/chart/{patientid}/surgicalhistory";// GET /chart/{patientid}/surgicalhistory   
                apiResult = await _athenaApiHttpClient.GetJson(path, parameters);
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
        
        public async Task<BsonDocument> GetPatientSocialHistory(string patientid, string departmentid)
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
            };
            
            try
            {
                string path = $"/chart/{patientid}/socialhistory";// GET /chart/{patientid}/socialhistory  
                apiResult = await _athenaApiHttpClient.GetJson(path, parameters);
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
        
        public async Task<List<BsonDocument>> GetPatientQualityManagementProviders(string patientid, string departmentid)
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
            };
            
            try
            {
                string path = $"/chart/{patientid}/qualitymanagement/providers";//  GET /chart/{patientid}/qualitymanagement/providers 
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
        
        public async Task<List<BsonDocument>> GetPatientQualityManagement(string patientid, string departmentid)
        {
            JsonValue apiResult;
            int offsetCounter = 0;
            const int offsetValue = 100;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid",departmentid},
                {"measuretype","All"},
                {"status","All"},
                {"limit",offsetValue.ToString()},
                {"offset", $"{offsetCounter * offsetValue}"},
            };
            try
            {
                string path = $"/chart/{patientid}/qualitymanagement"; // GET /chart/{patientid}/qualitymanagement
                bool isNextPath = true;
                var dataList = new List<BsonDocument>();
                while (isNextPath)
                {
                    apiResult = await _athenaApiHttpClient.GetJson(path, parameters);
                    if (apiResult == null)
                    {
                        return null;
                    }

                    var bsonData = BsonSerializer.Deserialize<BsonDocument>(apiResult.ToString());
                    
                    if (!bsonData.Names.AsQueryable().Contains("measures") ||
                        !bsonData.Names.AsQueryable().Contains("totalcount"))
                    {
                        break;
                    }

                    BsonElement count = bsonData.GetElement("totalcount");

                    if (count.Value.AsInt32 <= 0)
                    {
                        break;
                    }

                    var measures = bsonData.GetElement("measures").Value.AsBsonArray;
                    if (measures.Count > 0)
                    {
                        dataList.AddRange(measures.Select(e => e.AsBsonDocument).ToList());
                    }

                    isNextPath = bsonData.Names.AsQueryable().Contains("next");
                    offsetCounter++;
                    parameters["offset"] = $"{offsetCounter * offsetValue}";
                }

                return dataList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public async Task<List<BsonDocument>> GetPatientProblems(string patientid, string departmentid)
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
                {"showdiagnosisinfo", "true"},
                {"showinactive", "true"},
            };
            
            try
            {
                string path = $"/chart/{patientid}/problems";// GET /chart/{patientid}/problems
                apiResult = await _athenaApiHttpClient.GetJson(path, parameters);
                if (apiResult == null)
                {
                    return null;
                }

                var bsonData = BsonSerializer.Deserialize<BsonDocument>(apiResult.ToString());
                var result = new List<BsonDocument>();
                if (bsonData.TryGetElement("totalcount", out BsonElement count) && count.Value.AsInt32 > 0)
                {
                    result.AddRange(bsonData.GetElement("problems").Value.AsBsonArray.Select(e => e.AsBsonDocument).ToList());
                }

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public async Task<List<BsonDocument>> GetPatientPharmaciesPreferred(string patientid, string departmentid)
        {
            JsonValue apiResult;
            int offsetCounter = 0;
            const int offsetValue = 100;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid",departmentid},
                {"limit",offsetValue.ToString()},
                {"offset", $"{offsetCounter * offsetValue}"},
            };
            try
            {
                string path = $"/chart/{patientid}/pharmacies/preferred"; //GET /chart/{patientid}/pharmacies/preferred 
                bool isNextPath = true;
                var pharmaciesPreferred = new List<BsonDocument>();
                while (isNextPath)
                {
                    apiResult = await _athenaApiHttpClient.GetJson(path, parameters);
                    if (apiResult == null)
                    {
                        return null;
                    }

                    var bsonData = BsonSerializer.Deserialize<BsonDocument>(apiResult.ToString());
                    
                    if (!bsonData.Names.AsQueryable().Contains("pharmacies") ||
                        !bsonData.Names.AsQueryable().Contains("totalcount"))
                    {
                        break;
                    }

                    BsonElement count = bsonData.GetElement("totalcount");

                    if (count.Value.AsInt32 <= 0)
                    {
                        break;
                    }

                    var pharmacy = bsonData.GetElement("pharmacies").Value.AsBsonArray;
                    if (pharmacy.Count > 0)
                    {
                        pharmaciesPreferred.AddRange(pharmacy.Select(e => e.AsBsonDocument).ToList());
                    }

                    isNextPath = bsonData.Names.AsQueryable().Contains("next");
                    offsetCounter++;
                    parameters["offset"] = $"{offsetCounter * offsetValue}";
                }

                return pharmaciesPreferred;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public async Task<BsonDocument> GetPatientPharmaciesDefault(string patientid, string departmentid)
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
                
            };
            
            try
            {
                string path = $"/chart/{patientid}/pharmacies/default";// GET /chart/{patientid}/pharmacies/default 
                apiResult = await _athenaApiHttpClient.GetJson(path, parameters);
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
        
        public async Task<List<BsonDocument>> GetPatientChartList(string patientid)
        {
            JsonValue apiResult;
            int offsetCounter = 0;
            const int offsetValue = 100;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                
                {"limit",offsetValue.ToString()},
                {"offset", $"{offsetCounter * offsetValue}"},
            };
            try
            {
                string path = $"/chart/{patientid}/patientchartlist"; //GET /chart/{patientid}/patientchartlist
                bool isNextPath = true;
                var chartList = new List<BsonDocument>();
                while (isNextPath)
                {
                    apiResult = await _athenaApiHttpClient.GetJson(path, parameters);
                    if (apiResult == null)
                    {
                        return null;
                    }

                    var bsonData = BsonSerializer.Deserialize<BsonDocument>(apiResult.ToString());
                    
                    if (!bsonData.Names.AsQueryable().Contains("chartlist") ||
                        !bsonData.Names.AsQueryable().Contains("totalcount"))
                    {
                        break;
                    }

                    BsonElement count = bsonData.GetElement("totalcount");

                    if (count.Value.AsInt32 <= 0)
                    {
                        break;
                    }

                    var charts = bsonData.GetElement("chartlist").Value.AsBsonArray;
                    if (charts.Count > 0)
                    {
                        chartList.AddRange(charts.Select(e => e.AsBsonDocument).ToList());
                    }

                    isNextPath = bsonData.Names.AsQueryable().Contains("next");
                    offsetCounter++;
                    parameters["offset"] = $"{offsetCounter * offsetValue}";
                }

                return chartList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public async Task<BsonDocument> GetPatientMedications(string patientid, string departmentid)
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
                {"showndc", "true"},
                {"showpend", "true"},
                {"showrxnorm", "true"},
            };
            
            try
            {
                string path = $"/chart/{patientid}/medications";//  /chart/{patientid}/medications  
                apiResult = await _athenaApiHttpClient.GetJson(path, parameters);
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
        
        public async Task<BsonDocument> GetPatientMedicalHistory(string patientid, string departmentid)
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
            };
            
            try
            {
                string path = $"/chart/{patientid}/medicalhistory";//  /chart/{patientid}/medicalhistory  
                apiResult = await _athenaApiHttpClient.GetJson(path, parameters);
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
        
        public async Task<BsonDocument> GetPatientLabsDefault (string patientid, string departmentid)
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
            };
            
            try
            {
                string path = $"/chart/{patientid}/labs/default";// GET /chart/{patientid}/labs/default 
                apiResult = await _athenaApiHttpClient.GetJson(path, parameters);
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
        
        public async Task<List<BsonDocument>> GetPatientLabResults(string patientid,string departmentid)
        {
            JsonValue apiResult;
            int offsetCounter = 0;
            const int offsetValue = 100;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
                {"showabnormaldetails", "true"},
                {"showhidden", "true"},
                {"limit",offsetValue.ToString()},
                {"offset", $"{offsetCounter * offsetValue}"},
            };
            try
            {
                string path = $"/chart/{patientid}/labresults"; // GET /chart/{patientid}/labresults
                bool isNextPath = true;
                var appointmentData = new List<BsonDocument>();
                while (isNextPath)
                {
                    apiResult = await _athenaApiHttpClient.GetJson(path, parameters);
                    if (apiResult == null)
                    {
                        return null;
                    }

                    var bsonData = BsonSerializer.Deserialize<BsonDocument>(apiResult.ToString());
                    
                    if (!bsonData.Names.AsQueryable().Contains("results") ||
                        !bsonData.Names.AsQueryable().Contains("totalcount"))
                    {
                        break;
                    }

                    BsonElement count = bsonData.GetElement("totalcount");

                    if (count.Value.AsInt32 <= 0)
                    {
                        break;
                    }

                    var appointments = bsonData.GetElement("results").Value.AsBsonArray;
                    if (appointments.Count > 0)
                    {
                        appointmentData.AddRange(appointments.Select(e => e.AsBsonDocument).ToList());
                    }

                    isNextPath = bsonData.Names.AsQueryable().Contains("next");
                    offsetCounter++;
                    parameters["offset"] = $"{offsetCounter * offsetValue}";
                }

                return appointmentData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public async Task<List<BsonDocument>> GetPatientImagingPreferred(string patientid, string departmentid)
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
            };
            
            try
            {
                string path = $"/chart/{patientid}/imaging/preferred";//  GET /chart/{patientid}/imaging/preferred 
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
        
        public async Task<BsonDocument> GetPatientGynHistory(string patientid, string departmentid)
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
            };
            
            try
            {
                string path = $"/chart/{patientid}/gynhistory";// GET /chart/{patientid}/gynhistory 
                apiResult = await _athenaApiHttpClient.GetJson(path, parameters);
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
        
        public async Task<BsonDocument> GetPatientFamilyHistory(string patientid, string departmentid)
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
            };
            
            try
            {
                string path = $"/chart/{patientid}/careteam";//GET /chart/{patientid}/familyhistory  
                apiResult = await _athenaApiHttpClient.GetJson(path, parameters);
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
        
        public async Task<BsonDocument> GetPatientEncounterSummary(string patientid, string appointmentid)
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"mobile", "false"},
                {"skipamendments", "false"},
            };
            
            try
            {
                string path = $"/chart/{patientid}/encounters/{appointmentid}/summary";//  GET /chart/{patientid}/encounters/{appointmentid}/summary 
                apiResult = await _athenaApiHttpClient.GetJson(path, parameters);
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
        
        public async Task<BsonDocument> GetPatientCareTeam(string patientid, string departmentid)
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
            };
            
            try
            {
                string path = $"/chart/{patientid}/careteam";//  GET /chart/{patientid}/careteam 
                apiResult = await _athenaApiHttpClient.GetJson(path, parameters);
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
        
        public async Task<List<BsonDocument>> GetPatientAnalytes(string patientid,string departmentid)
        {
            JsonValue apiResult;
            int offsetCounter = 0;
            const int offsetValue = 100;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
                {"showabnormaldetails", "true"},
                {"showhidden", "true"},
                {"showtemplate", "true"},
                {"limit",offsetValue.ToString()},
                {"offset", $"{offsetCounter * offsetValue}"},
            };
            try
            {
                string path = $"/chart/{patientid}/analytes"; // GET /chart/{patientid}/analytes 
                bool isNextPath = true;
                var appointmentData = new List<BsonDocument>();
                while (isNextPath)
                {
                    apiResult = await _athenaApiHttpClient.GetJson(path, parameters);
                    if (apiResult == null)
                    {
                        return null;
                    }

                    var bsonData = BsonSerializer.Deserialize<BsonDocument>(apiResult.ToString());
                    
                    if (!bsonData.Names.AsQueryable().Contains("analytes") ||
                        !bsonData.Names.AsQueryable().Contains("totalcount"))
                    {
                        break;
                    }

                    BsonElement count = bsonData.GetElement("totalcount");

                    if (count.Value.AsInt32 <= 0)
                    {
                        break;
                    }

                    var appointments = bsonData.GetElement("analytes").Value.AsBsonArray;
                    if (appointments.Count > 0)
                    {
                        appointmentData.AddRange(appointments.Select(e => e.AsBsonDocument).ToList());
                    }

                    isNextPath = bsonData.Names.AsQueryable().Contains("next");
                    offsetCounter++;
                    parameters["offset"] = $"{offsetCounter * offsetValue}";
                }

                return appointmentData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public async Task<BsonDocument> GetPatientAllergies(string patientid, string departmentid)
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
                {"showinactive", "true"},
            };
            
            try
            {
                string path = $"/chart/{patientid}/allergies";// GET /chart/{patientid}/allergies 
                apiResult = await _athenaApiHttpClient.GetJson(path, parameters);
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
        
        public async Task<List<BsonDocument>> GetPatientAdministeredQuestionnaireScreeners(string patientid, string departmentid)
        {
            JsonValue apiResult;
            int offsetCounter = 0;
            const int offsetValue = 100;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
                {"showpast", "true"},
                {"showexpectedprocedurecodes", "true"},
                {"limit",offsetValue.ToString()},
                {"offset", $"{offsetCounter * offsetValue}"}
            };
            try
            {
                string path = $"/chart/{patientid}/administeredquestionnairescreeners";//GET /chart/{patientid}/administeredquestionnairescreeners 
                bool isNextPath = true;
                var questionnaireScreeners = new List<BsonDocument>();
                while (isNextPath)
                {
                    apiResult = await _athenaApiHttpClient.GetJson(path, parameters);
                    if (apiResult == null)
                    {
                        return null;
                    }

                    var bsonData = BsonSerializer.Deserialize<BsonDocument>(apiResult.ToString());
                    
                    if (!bsonData.Names.AsQueryable().Contains("questionnairescreeners") ||
                        !bsonData.Names.AsQueryable().Contains("totalcount"))
                    {
                        break;
                    }

                    BsonElement count = bsonData.GetElement("totalcount");

                    if (count.Value.AsInt32 <= 0)
                    {
                        break;
                    }

                    var appointments = bsonData.GetElement("questionnairescreeners").Value.AsBsonArray;
                    if (appointments.Count > 0)
                    {
                        questionnaireScreeners.AddRange(appointments.Select(e => e.AsBsonDocument).ToList());
                    }

                    isNextPath = bsonData.Names.AsQueryable().Contains("next");
                    offsetCounter++;
                    parameters["offset"] = $"{offsetCounter * offsetValue}";
                }

                return questionnaireScreeners;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public async Task<List<BsonDocument>> GetPatientEncounter(string patientid, string departmentid)
        {
            int offsetCounter = 0;
            const int offsetValue = 100;
            var encounterData = new List<BsonDocument>();
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", $"{departmentid}"},
                {"showallstatuses", "true"},
                {"showalltypes", "true"},
                {"showdiagnoses", "true"},
                {"limit",offsetValue.ToString()},
                {"offset", $"{offsetCounter * offsetValue}"}
            };
            try
            {
                string path = $"/chart/{patientid}/encounters";
                bool isNextPath = true;
                while (isNextPath)
                {
                    JsonValue apiResult = await _athenaApiHttpClient.GetJson(path, parameters);
                    if (apiResult == null)
                    {
                        return null;
                    }

                    var bsonData = BsonSerializer.Deserialize<BsonDocument>(apiResult.ToString());
                    if (!bsonData.Names.AsQueryable().Contains("encounters") ||
                        !bsonData.Names.AsQueryable().Contains("totalcount"))
                    {
                        break;
                    }

                    BsonElement count = bsonData.GetElement("totalcount");

                    if (count.Value.AsInt32 <= 0)
                    {
                        break;
                    }

                    var encounters = bsonData.GetElement("encounters").Value.AsBsonArray;
                    if (encounters.Count > 0)
                    {
                        encounterData.AddRange(encounters.Select(e => e.AsBsonDocument).ToList());
                    }

                    isNextPath = bsonData.Names.AsQueryable().Contains("next");
                    offsetCounter++;
                    parameters["offset"] = $"{offsetCounter * offsetValue}";
                }

                return encounterData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
    }
}