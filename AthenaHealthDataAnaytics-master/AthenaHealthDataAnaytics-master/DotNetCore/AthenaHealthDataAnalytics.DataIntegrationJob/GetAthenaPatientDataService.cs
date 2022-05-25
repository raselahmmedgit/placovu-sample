using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AthenaHealthDataAnalytics.Core.BLL.AthenaClient.Interface;
using AthenaHealthDataAnalytics.Core.BLL.AthenaClient.Service;
using BLL.AthenaClient;
using log4net;

namespace AthenaHealthDataAnalytics.DataIntegrationJob
{
    internal class GetAthenaPatientDataService : IHostedService
    {
        private readonly ILog _logger;
        
        private IAthenaPatientDataManager _getAthenaPatientDataManager;

        public GetAthenaPatientDataService(IServiceProvider services,
            IAthenaPatientDataManager athenaPatientDataManager,
            ILogger<GetAthenaPatientDataService> logger)
        {
            _getAthenaPatientDataManager = athenaPatientDataManager;
            
            Services = services;
            _logger = LogManager.GetLogger(typeof(GetAthenaPatientDataService));
        }

        public IServiceProvider Services { get; }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.Info(
                "Get Athena Patient Hosted Service is starting.");

            GetAthenaHealthPatient();

            return Task.CompletedTask;
        }

        private async Task GetAthenaHealthPatient()
        {
            _logger.Info(
                "Get Athena Patient Hosted Service is working.");

            /*var patientList = getPatientListToFetch();
            foreach (var patient in patientList)
            {
                await _getAthenaPatientDataManager.InsertAthenaPatientDetailToMongoDB(patient.patientId, patient.departmentId);
                await _getAthenaPatientDataManager.InsertAthenaEncounterDataToMongoDB(patient.patientId, patient.departmentId);
                await _getAthenaPatientDataManager.InsertAthenaPatientDocumentDataToMongoDB(patient.patientId, patient.departmentId);
                await _getAthenaPatientDataManager.InsertAthenaPatientFinancialToMongoDB(patient.patientId, patient.departmentId);
                await _getAthenaPatientDataManager.InsertAthenaPatientHistoryToMongoDB(patient.patientId, patient.departmentId);
            }
            _logger.Info($"Inserted Athena Patient Data for {patientList.Count} patients.");*/
            /*var patient = new { patientId = "1172007", departmentId = "3" };
            await _getAthenaPatientDataManager.InsertAthenaPatientDocumentDataToMongoDB(patient.patientId, patient.departmentId);
            
            await _getAthenaPatientDataManager.InsertAthenaPatientDetailToMongoDB(patient.patientId, patient.departmentId);
            await _getAthenaPatientDataManager.InsertAthenaEncounterDataToMongoDB(patient.patientId, patient.departmentId);
            await _getAthenaPatientDataManager.InsertAthenaPatientFinancialToMongoDB(patient.patientId, patient.departmentId);
            await _getAthenaPatientDataManager.InsertAthenaPatientHistoryToMongoDB(patient.patientId, patient.departmentId);
            _logger.Info($"Inserted Athena Patient Data .");*/

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.Info(
                "Get Athena Patient Hosted Service is stopping.");

            return Task.CompletedTask;
        }

        private List<(string patientId, string departmentId)> getPatientListToFetch()
        {
            return new List<(string patientId, string departmentId)>
            {
                ("1172007","3"),
                ("1173924","20"),
                ("1173933","3"),
                ("1174276","19"),
                ("1174566","20"),
                ("1174954","3"),
                ("1175462","20"),
                ("1176973","19"),
                ("1177127","20"),
                ("1177399","20"),
                ("1177460","3"),
                ("1177907","20"),
                ("1177910","20"),
                ("1178186","20"),
                ("1178410","3"),
                ("1178494","3"),
                ("1178564","3"),
                ("1178777","20"),
                ("1179334","20"),
                ("1179419","20"),
                ("1179437","20"),
                ("1179493","20"),
                ("1179752","20"),
                ("294793","20"),
                ("342415","20"),
                ("405368","20"),
                ("408441","20"),
                ("422207","20"),
                ("427659","20"),
                ("449352","3"),
                ("454139","20"),
                ("458310","3"),
                ("462116","20"),
                ("478782","20"),
                ("507443","20"),
                ("516885","20"),
                ("520787","3"),
                ("522632","20"),
                ("524112","20"),
                ("537973","3"),
                ("552431","20"),
                ("557656","3"),
                ("560414","3"),
                ("571286","3"),
                ("597386","3"),
                ("598316","20"),
                ("619402","20"),
                ("620625","20"),
                ("621568","4"),
                ("633935","20"),
            };
        }
    }
}
