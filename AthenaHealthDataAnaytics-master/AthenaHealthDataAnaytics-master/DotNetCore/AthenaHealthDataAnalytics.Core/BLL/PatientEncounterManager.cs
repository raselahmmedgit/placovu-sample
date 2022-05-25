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
    public partial class PatientEncounterManager 
    {
        private IPatientEncounterRepository _encounterRepository;
        private ILog _log;
        public PatientEncounterManager(IAthenaHealthConfigs athenaHealthConfigs, IMongoDatabaseSettings mongoDatabseSettings)
        {
            _log = LogManager.GetLogger(typeof(PatientEncounterManager));
            _encounterRepository = new PatientEncounterRepository(mongoDatabseSettings);
        }
        
    }
}
