using AthenaHealthDataAnalytics.Core.BLL.AthenaClient.Interface;
using AthenaHealthDataAnalytics.Core.BLL.AthenaClient.Service;
using AthenaHealthDataAnalytics.Core.BLL.MongoDBClient;
using AthenaHealthDataAnalytics.Core.DAL;
using AthenaHealthDataAnalytics.Core.DAL.Interfaces;
using AthenaHealthDataAnalytics.Core.EntityModels;
using BLL.AthenaClient;
using log4net;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AthenaHealthDataAnalytics.Core.BLL
{
    public partial class PatientDetailManager 
    {
        private IPatientDetailRepository _patientDetailRepository;
        private ILog _log;
        public PatientDetailManager(IAthenaHealthConfigs athenaHealthConfigs, IMongoDatabaseSettings mongoDatabseSettings)
        {
            _log = LogManager.GetLogger(typeof(PatientDetailManager));
            _patientDetailRepository = new PatientDetailRepository(mongoDatabseSettings);
        }
        
    }
}
