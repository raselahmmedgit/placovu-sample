using AthenaHealthDataAnalytics.Core.BLL.AthenaClient.Interface;
using BLL.AthenaClient;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Json;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AthenaHealthDataAnalytics.Core.Util;
using AthenaHealthDataAnalytics.Core.ViewModels;
using Newtonsoft.Json;

namespace AthenaHealthDataAnalytics.Core.BLL.AthenaClient.Service
{
    public class CreateUpdatePatientHistoryChartData : ICreateUpdatePatientHistoryChartData
    {
        private APIConnection _ApiConnection { get; set; }
        private readonly AthenaHealthApiConnectionManager _athenaHealthApiConnectionManager;
        private readonly IAthenaHealthConfigs _athenaHealthConfigs;
        private readonly IAthenaApiHttpClient _athenaApiHttpClient;

        public CreateUpdatePatientHistoryChartData(IAthenaHealthConfigs athenaHealthConfigs,
            IAthenaApiHttpClient athenaApiHttpClient)
        {
            _athenaHealthApiConnectionManager = new AthenaHealthApiConnectionManager(athenaHealthConfigs);
            _ApiConnection = _athenaHealthApiConnectionManager.Connection;
            _athenaApiHttpClient = athenaApiHttpClient;
            _athenaHealthConfigs = athenaHealthConfigs;
        }

        public async Task<ApiCallResult> PutHpiDataByEncounterId(string encounterid, HpiDataTemplate hpiDataTemplate)
        {
            var result = new ApiCallResult();
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>
                {
                    {"encounterid", encounterid},
                    {"practiceid", _athenaHealthConfigs.practiceId},
                    {"sectionnote", hpiDataTemplate.SectionNote},
                    {"replacesectionnote", hpiDataTemplate.ReplaceSectionNote},
                    {"hpi", JsonConvert.SerializeObject(hpiDataTemplate.HpiData)},
                    {"templatedata", JsonConvert.SerializeObject(hpiDataTemplate.TemplateData)},
                };
                string path =
                    $"/chart/encounter/{encounterid}/hpi"; // GET /chart/encounter/{encounterid}/hpi
                var apiResult = await _athenaApiHttpClient.PutRequest(path, parameters);
                if (apiResult == null || apiResult.StatusCode != HttpStatusCode.OK)
                {
                    result.IsSuccess = false;
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                return result;
            }
        }
    }
}