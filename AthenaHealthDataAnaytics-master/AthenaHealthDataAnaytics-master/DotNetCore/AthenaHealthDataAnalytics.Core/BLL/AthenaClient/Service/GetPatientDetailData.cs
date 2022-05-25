using AthenaHealthDataAnalytics.Core.BLL.AthenaClient.Interface;
using BLL.AthenaClient;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthenaHealthDataAnalytics.Core.BLL.AthenaClient.Service
{
    public class GetPatientDetailData : IGetPatientDetailData
    {
        private APIConnection _ApiConnection { get; set; }
        private readonly AthenaHealthApiConnectionManager _athenaHealthApiConnectionManager;
        private readonly IAthenaHealthConfigs _athenaHealthConfigs;
        private readonly IAthenaApiHttpClient _athenaApiHttpClient;

        public GetPatientDetailData(IAthenaHealthConfigs athenaHealthConfigs,IAthenaApiHttpClient athenaApiHttpClient)
        {
            _athenaHealthApiConnectionManager = new AthenaHealthApiConnectionManager(athenaHealthConfigs);
            _ApiConnection = _athenaHealthApiConnectionManager.Connection;
            _athenaApiHttpClient = athenaApiHttpClient;
            _athenaHealthConfigs = athenaHealthConfigs;
            
        }
        
        public async Task<BsonDocument> GetPatientPhoto(string patientid)
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"patientid",patientid},
                {"practiceid",_athenaHealthConfigs.practiceId},
                {"jpegoutput","true"}
            };
            try
            {
                string path = $"/patients/{patientid}/photo";//GET /patients/{patientid}/photo 
                string imageString= await _athenaApiHttpClient.GetFileAsBase64String(path, parameters);
                if (imageString == null)
                {
                    return null;
                }

                var bsonData = new BsonDocument
                {
                    {"base64stringimage",imageString},
                    {"contenttype","jpeg"}
                };
                
                return bsonData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public async Task<BsonDocument> GetPatientPrivacyInformationVerified(string patientid, string departmentid )
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
            };
            try
            {
                string path = $"/patients/{patientid}/privacyinformationverified";//GET /patients/{patientid}/privacyinformationverified 
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
        
        public async Task<List<BsonDocument>> GetPatientStatement(string patientid, string departmentid )
        {
            JsonValue apiResult;
            int offsetCounter = 0;
            const int offsetValue = 100;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
                {"startdate", DateTime.MinValue.ToString("MM/dd/yyyy")},
                {"enddate", DateTime.Now.ToString("MM/dd/yyyy")},
                {"limit",offsetValue.ToString()},
                {"offset", $"{offsetCounter * offsetValue}"},
            };
            try
            {
                string path = $"/patients/{patientid}/patientstatement";// GET /patients/{patientid}/patientstatement 
                bool isNextPath = true;
                var consentData = new List<BsonDocument>();
                while (isNextPath)
                {
                    apiResult = await _athenaApiHttpClient.GetJson(path, parameters);
                    if (apiResult == null)
                    {
                        return null;
                    }

                    var bsonData = BsonSerializer.Deserialize<BsonDocument>(apiResult.ToString());
                    
                    if (!bsonData.Names.AsQueryable().Contains("STATEMENTS") ||
                        !bsonData.Names.AsQueryable().Contains("totalcount"))
                    {
                        break;
                    }

                    BsonElement count = bsonData.GetElement("totalcount");

                    if (count.Value.AsInt32 <= 0)
                    {
                        break;
                    }

                    var consents = bsonData.GetElement("STATEMENTS").Value.AsBsonArray;
                    if (consents.Count > 0)
                    {
                        consentData.AddRange(consents.Select(e => e.AsBsonDocument).ToList());
                    }

                    isNextPath = bsonData.Names.AsQueryable().Contains("next");
                    offsetCounter++;
                    parameters["offset"] = $"{offsetCounter * offsetValue}";
                }

                return consentData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public async Task<List<BsonDocument>> GetPatientInterfaceConsents(string patientid, string departmentid )
        {
            JsonValue apiResult;
            int offsetCounter = 0;
            const int offsetValue = 100;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
                {"limit",offsetValue.ToString()},
                {"offset", $"{offsetCounter * offsetValue}"}
            };
            try
            {
                string path = $"/patients/{patientid}/interfaceconsents";//GET /patients/{patientid}/interfaceconsents 
                bool isNextPath = true;
                var consentData = new List<BsonDocument>();
                while (isNextPath)
                {
                    apiResult = await _athenaApiHttpClient.GetJson(path, parameters);
                    if (apiResult == null)
                    {
                        return null;
                    }

                    var bsonData = BsonSerializer.Deserialize<BsonDocument>(apiResult.ToString());
                    
                    if (!bsonData.Names.AsQueryable().Contains("consents") ||
                        !bsonData.Names.AsQueryable().Contains("totalcount"))
                    {
                        break;
                    }

                    BsonElement count = bsonData.GetElement("totalcount");

                    if (count.Value.AsInt32 <= 0)
                    {
                        break;
                    }

                    var consents = bsonData.GetElement("consents").Value.AsBsonArray;
                    if (consents.Count > 0)
                    {
                        consentData.AddRange(consents.Select(e => e.AsBsonDocument).ToList());
                    }

                    isNextPath = bsonData.Names.AsQueryable().Contains("next");
                    offsetCounter++;
                    parameters["offset"] = $"{offsetCounter * offsetValue}";
                }

                return consentData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public async Task<List<BsonDocument>> GetPatientCustomFields(string patientid, string departmentid )
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
            };
            try
            {
                string path = $"/patients/{patientid}/customfields";//GET /patients/{patientid}/customfields
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
        
        public async Task<BsonDocument> GetPatientChartAlert(string patientid, string departmentid )
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
            };
            try
            {
                string path = $"/patients/{patientid}/chartalert";//GET /patients/{patientid}/chartalert 
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
        
        public async Task<List<BsonDocument>> GetPatientAuthorizations(string patientid, string departmentid )
        {
            JsonValue apiResult;
            int offsetCounter = 0;
            const int offsetValue = 100;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
                {"showdeleted", "true"},
                {"limit",offsetValue.ToString()},
                {"offset", $"{offsetCounter * offsetValue}"},
            };
            try
            {
                string path = $"/patients/{patientid}/authorizations";//GET /patients/{patientid}/authorizations 
                bool isNextPath = true;
                var authorizationData = new List<BsonDocument>();
                while (isNextPath)
                {
                    apiResult = await _athenaApiHttpClient.GetJson(path, parameters);
                    if (apiResult == null)
                    {
                        return null;
                    }

                    var bsonData = BsonSerializer.Deserialize<BsonDocument>(apiResult.ToString());
                    
                    if (!bsonData.Names.AsQueryable().Contains("releaseauthorizations") ||
                        !bsonData.Names.AsQueryable().Contains("totalcount"))
                    {
                        break;
                    }

                    BsonElement count = bsonData.GetElement("totalcount");

                    if (count.Value.AsInt32 <= 0)
                    {
                        break;
                    }

                    var authorizations = bsonData.GetElement("releaseauthorizations").Value.AsBsonArray;
                    if (authorizations.Count > 0)
                    {
                        authorizationData.AddRange(authorizations.Select(e => e.AsBsonDocument).ToList());
                    }

                    isNextPath = bsonData.Names.AsQueryable().Contains("next");
                    offsetCounter++;
                    parameters["offset"] = $"{offsetCounter * offsetValue}";
                }

                return authorizationData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<BsonDocument>> GetPatientAppointmentDetail(string patientid, string appointmentid)
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"ignorerestrictions", "true"},
                {"showclaimdetail", "true"},
                {"showcopay", "true"},
                {"showexpectedprocedurecodes", "true"},
                {"showinsurance", "true"},
                {"showpatientdetail", "true"},
                
            };
            
            try
            {
                string path = $"/patients/{patientid}/appointments/{appointmentid}";// GET /patients/{patientid}/appointments/{appointmentid}
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
        
        public async Task<List<BsonDocument>> GetPatientAppointment(string patientid)
        {
            JsonValue apiResult;
            int offsetCounter = 0;
            const int offsetValue = 100;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"showcancelled", "true"},
                {"showpast", "true"},
                {"showexpectedprocedurecodes", "true"},
                {"limit",offsetValue.ToString()},
                {"offset", $"{offsetCounter * offsetValue}"},
            };
            try
            {
                string path = $"/patients/{patientid}/appointments";
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
                    
                    if (!bsonData.Names.AsQueryable().Contains("appointments") ||
                        !bsonData.Names.AsQueryable().Contains("totalcount"))
                    {
                        break;
                    }

                    BsonElement count = bsonData.GetElement("totalcount");

                    if (count.Value.AsInt32 <= 0)
                    {
                        break;
                    }

                    var appointments = bsonData.GetElement("appointments").Value.AsBsonArray;
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

        public async Task<BsonDocument> GetPatientProfile(string patientid)
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"showallclaims", "true"},
                {"showallpatientdepartmentstatus", "true"},
                {"showbalancedetails", "true"},
                {"showcustomfields", "true"},
                {"showfullssn", "true"},
                {"showinsurance", "true"},
                {"showlocalpatientid", "true"},
                {"showportalstatus", "true"},
                {"showpreviouspatientids", "true"}
            };
            try
            {
                string path = $"/patients/{patientid}";
                apiResult = await _athenaApiHttpClient.GetJson(path, parameters);
                if (apiResult == null)
                {
                    return null;
                }

                var bsonData = BsonSerializer.Deserialize<List<BsonDocument>>(apiResult.ToString());
                var patientData = bsonData.Count > 0 ? bsonData.First() : null;

                return patientData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
    }
}
