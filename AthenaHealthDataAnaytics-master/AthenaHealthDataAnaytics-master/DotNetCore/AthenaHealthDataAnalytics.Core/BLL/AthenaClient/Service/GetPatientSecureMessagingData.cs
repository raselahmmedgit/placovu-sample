using System;
using System.Collections.Generic;
using System.Json;
using System.Threading.Tasks;
using AthenaHealthDataAnalytics.Core.BLL.AthenaClient.Interface;
using BLL.AthenaClient;
using MongoDB.Driver;

namespace AthenaHealthDataAnalytics.Core.BLL.AthenaClient.Service
{
    public class GetPatientSecureMessagingData:IGetPatientSecureMessagingData
    {
        private APIConnection _ApiConnection { get; }
        private readonly AthenaHealthApiConnectionManager _athenaHealthApiConnectionManager;
        private readonly IAthenaApiHttpClient _athenaApiHttpClient;

        
        public GetPatientSecureMessagingData(IAthenaHealthConfigs athenaHealthConfigs,IAthenaApiHttpClient athenaApiHttpClient)
        {
            _athenaHealthApiConnectionManager = new AthenaHealthApiConnectionManager(athenaHealthConfigs);
            _ApiConnection = _athenaHealthApiConnectionManager.Connection;
            _athenaApiHttpClient = athenaApiHttpClient;

        }
        
    }
}