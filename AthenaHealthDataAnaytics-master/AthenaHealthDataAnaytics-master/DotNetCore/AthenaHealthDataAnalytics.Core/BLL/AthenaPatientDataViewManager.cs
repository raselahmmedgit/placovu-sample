using AthenaHealthDataAnalytics.Core.BLL.Interface;
using AthenaHealthDataAnalytics.Core.BLL.MongoDBClient;
using AthenaHealthDataAnalytics.Core.DAL;
using AthenaHealthDataAnalytics.Core.DAL.Interfaces;
using AthenaHealthDataAnalytics.Core.EntityModels;
using AthenaHealthDataAnalytics.Core.ViewModels;
using AutoMapper;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthenaHealthDataAnalytics.Core.BLL
{
    public class AthenaPatientDataViewManager : IAthenaPatientDataViewManager
    {
        private IMongoDatabaseSettings _mongoDatabaseSettings;
        private IPatientDetailRepository _patientDetailRepository;
        private IPatientEncounterRepository _PatientEncounterRepository;
        private IPatientFinancialRepository _PatientFinancialRepository;
        private IPatientHistoryRepository _PatientHistoryRepository;
        private IPatientDocumentRepository _patientDocumentRepository;
        private IMapper _iMapper;
        public AthenaPatientDataViewManager(IMongoDatabaseSettings mongoDatabseSettings,
            IMapper iMapper)
        {
            _mongoDatabaseSettings = mongoDatabseSettings;
            _iMapper = iMapper;
            _patientDetailRepository = new PatientDetailRepository(_mongoDatabaseSettings);
            _PatientEncounterRepository = new PatientEncounterRepository(_mongoDatabaseSettings);
            _PatientHistoryRepository = new PatientHistoryRepository(_mongoDatabaseSettings);
            _PatientFinancialRepository = new PatientFinancialRepository(_mongoDatabaseSettings);
            _patientDocumentRepository = new PatientDocumentRepository(_mongoDatabaseSettings);
        }
        public async Task<List<PatientDetail>> GetPatientDetail()
        {
            try
            {
                return await _patientDetailRepository.GetPatientDetail();
            }
            catch(Exception)
            {
                throw;
            }
        }
        public async Task<PatientDetail> GetPatientDetailByPatientId(string PatientId)
        {
            try
            {
                return await _patientDetailRepository.GetItemByPatientId(PatientId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<PatientEncounter> GetPatientEncounterByPatientId(string PatientId)
        {
            try
            {
                return await _PatientEncounterRepository.GetItemByPatientId(PatientId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<PatientHistory> GetPatienHistoricalByPatientId(string PatientId)
        {
            try
            {
                return await _PatientHistoryRepository.GetItemByPatientId(PatientId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<PatientFinancial> GetPatientFinancialByPatientId(string PatientId)
        {
            try
            {
                return await _PatientFinancialRepository.GetItemByPatientId(PatientId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<PatientDocument> GetPatientDocumentByPatientId(string PatientId)
        {
            try
            {
                return await _patientDocumentRepository.GetItemByPatientId(PatientId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<DataTablesResponse> GetPatientDetailForDataTablesResponseAsync(IDataTablesRequest request)
        {
            var modelList = await _patientDetailRepository.GetPatientDetail();
            var viewModelList = _iMapper.Map<IEnumerable<PatientDetail>, IEnumerable<AthenaPatientDataViewModel>>(modelList);

            // Global filtering.
            // Filter is being manually applied due to in-memmory (IEnumerable) data.
            // If you want something rather easier, check IEnumerableExtensions Sample.

            int dataCount = viewModelList.Count();
            int filteredDataCount = 0;
            IEnumerable<AthenaPatientDataViewModel> dataPage;
            if (viewModelList.Count() > 0 && request != null)
            {
                //var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                //? viewModelList
                //: viewModelList.Where(_item => _item.PreferredName.Contains(request.Search.Value));

                var filteredData = viewModelList;

                dataCount = filteredData.Count();

                // Paging filtered data.
                // Paging is rather manual due to in-memmory (IEnumerable) data.
                dataPage = filteredData.Skip(request.Start).Take(request.Length);

                filteredDataCount = filteredData.Count();
            }
            else
            {
                var filteredData = viewModelList;

                dataCount = filteredData.Count();

                dataPage = filteredData;

                filteredDataCount = filteredData.Count();
            }

            // Response creation. To create your response you need to reference your request, to avoid
            // request/response tampering and to ensure response will be correctly created.
            var response = DataTablesResponse.Create(request, dataCount, filteredDataCount, dataPage);

            return response;
        }
    }
}
