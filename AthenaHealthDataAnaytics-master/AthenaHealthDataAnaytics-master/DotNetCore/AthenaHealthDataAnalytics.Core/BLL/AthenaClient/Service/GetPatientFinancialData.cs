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
    public class GetPatientFinancialData : IGetPatientFinancialData
    {
        private APIConnection _ApiConnection { get; }
        private readonly AthenaHealthApiConnectionManager _athenaHealthApiConnectionManager;
        private readonly IAthenaApiHttpClient _athenaApiHttpClient;

        
        public GetPatientFinancialData(IAthenaHealthConfigs athenaHealthConfigs,IAthenaApiHttpClient athenaApiHttpClient)
        {
            _athenaHealthApiConnectionManager = new AthenaHealthApiConnectionManager(athenaHealthConfigs);
            _ApiConnection = _athenaHealthApiConnectionManager.Connection;
            _athenaApiHttpClient = athenaApiHttpClient;
        }
        
        public async Task<List<BsonDocument>> GetPatientReferralAuths(string patientid)
        {
            JsonValue apiResult;
            int offsetCounter = 0;
            const int offsetValue = 100;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"showexpired", "true"},
                {"limit",offsetValue.ToString()},
                {"offset", $"{offsetCounter * offsetValue}"},
            };
            try
            {
                string path = $"/patients/{patientid}/referralauths";//GET /patients/{patientid}/referralauths 
                bool isNextPath = true;
                var referralList = new List<BsonDocument>();
                while (isNextPath)
                {
                    apiResult = await _athenaApiHttpClient.GetJson(path, parameters);
                    if (apiResult == null)
                    {
                        return null;
                    }

                    var bsonData = BsonSerializer.Deserialize<BsonDocument>(apiResult.ToString());
                    
                    if (!bsonData.Names.AsQueryable().Contains("referralauths") ||
                        !bsonData.Names.AsQueryable().Contains("totalcount"))
                    {
                        break;
                    }

                    BsonElement count = bsonData.GetElement("totalcount");

                    if (count.Value.AsInt32 <= 0)
                    {
                        break;
                    }

                    var referrals = bsonData.GetElement("referralauths").Value.AsBsonArray;
                    if (referrals.Count > 0)
                    {
                        referralList.AddRange(referrals.Select(e => e.AsBsonDocument).ToList());
                    }

                    isNextPath = bsonData.Names.AsQueryable().Contains("next");
                    offsetCounter++;
                    parameters["offset"] = $"{offsetCounter * offsetValue}";
                }

                return referralList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public async Task<BsonDocument> GetPatientEPaymentReceiptsDetails(string patientid, string epaymentid)
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
            };
            try
            {
                string path = $"/patients/{patientid}/receipts/{epaymentid}/details";//GET /patients/{patientid}/receipts/{epaymentid}/details 
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

        public async Task<List<BsonDocument>> GetPatientEPaymentReceipts(string patientid, string departmentid)
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
            };
            
            try
            {
                string path = $"/patients/{patientid}/receipts";//  GET /patients/{patientid}/receipts 
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

        
        public async Task<List<BsonDocument>> GetPatientInsuranceCcmEnrollmentStatus(string patientid, string departmentid, string insuranceid)
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
            };
            
            try
            {
                string path = $"/patients/{patientid}/insurances/{insuranceid}/ccmenrollmentstatus".Trim();// GET /patients/{patientid}/insurances/{insuranceid}/ccmenrollmentstatus 
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
        
        public async Task<BsonDocument> GetPatientInsuranceBenefitDetails(string patientid, string insuranceid)
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
            };
            try
            {
                string path = $"/patients/{patientid}/insurances/{insuranceid}/benefitdetails";// GET /patients/{patientid}/insurances/{insuranceid}/benefitdetails 
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
        
        public async Task<List<BsonDocument>> GetPatientInsurance(string patientid)
        {
            JsonValue apiResult;
            int offsetCounter = 0;
            const int offsetValue = 100;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"ignorerestrictions", "true"},
                {"showcancelled", "true"},
                {"showfullssn", "true"},
                {"limit",offsetValue.ToString()},
                {"offset", $"{offsetCounter * offsetValue}"},
            };
            try
            {
                string path = $"/patients/{patientid}/insurances"; //GET /patients/{patientid}/insurances 
                bool isNextPath = true;
                var insuranceList = new List<BsonDocument>();
                while (isNextPath)
                {
                    apiResult = await _athenaApiHttpClient.GetJson(path, parameters);
                    if (apiResult == null)
                    {
                        return null;
                    }

                    var bsonData = BsonSerializer.Deserialize<BsonDocument>(apiResult.ToString());
                    
                    if (!bsonData.Names.AsQueryable().Contains("insurances") ||
                        !bsonData.Names.AsQueryable().Contains("totalcount"))
                    {
                        break;
                    }

                    BsonElement count = bsonData.GetElement("totalcount");

                    if (count.Value.AsInt32 <= 0)
                    {
                        break;
                    }

                    var insurances = bsonData.GetElement("insurances").Value.AsBsonArray;
                    if (insurances.Count > 0)
                    {
                        insuranceList.AddRange(insurances.Select(e => e.AsBsonDocument).ToList());
                    }

                    isNextPath = bsonData.Names.AsQueryable().Contains("next");
                    offsetCounter++;
                    parameters["offset"] = $"{offsetCounter * offsetValue}";
                }

                return insuranceList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public async Task<List<BsonDocument>> GetPatientContractsStoredCard(string patientid, string departmentid)
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
            };
            
            try
            {
                string path = $"/patients/{patientid}/collectpayment/storedcard";//   GET /patients/{patientid}/collectpayment/storedcard 
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
        
        public async Task<List<BsonDocument>> GetPatientContractsPaymentPlan(string patientid, string departmentid)
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
            };
            
            try
            {
                string path = $"/patients/{patientid}/collectpayment/singleappointment";//get /patients/{patientid}/collectpayment/singleappointment
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
        
        public async Task<List<BsonDocument>> GetPatientContractsOneYearByAppointmentId(string patientid, string departmentid, string appointmentid)
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
                {"appointmentid", appointmentid},
            };
            
            try
            {
                string path = $"/patients/{patientid}/collectpayment/oneyear/{appointmentid}";//  GET /patients/{patientid}/collectpayment/oneyear/{appointmentid} 
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
        
        public async Task<List<BsonDocument>> GetPatientContractsOneYear(string patientid, string departmentid)
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
            };
            
            try
            {
                string path = $"/patients/{patientid}/collectpayment/oneyear";// GET /patients/{patientid}/collectpayment/oneyear 
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
        
        public async Task<BsonDocument> GetPatientClaimsOutstanding(string patientid, string departmentid)
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
            };
            try
            {
                string path = $"/patients/{patientid}/claims/patientoutstanding"; //GET /patients/{patientid}/claims/patientoutstanding
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
        
        public async Task<BsonDocument> GetPatientClaimsClosed(string patientid, string departmentid)
        {
            JsonValue apiResult;
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"departmentid", departmentid},
                
            };
            try
            {
                string path = $"/patients/{patientid}/claims/patientclosed"; //GET /patients/{patientid}/claims/patientclosed 
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

    }
}