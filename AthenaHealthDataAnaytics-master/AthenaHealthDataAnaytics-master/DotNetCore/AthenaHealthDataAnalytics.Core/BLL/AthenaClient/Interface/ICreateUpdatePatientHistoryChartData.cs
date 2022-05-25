using System.Threading.Tasks;
using AthenaHealthDataAnalytics.Core.Util;
using AthenaHealthDataAnalytics.Core.ViewModels;

namespace AthenaHealthDataAnalytics.Core.BLL.AthenaClient.Interface
{
    public interface ICreateUpdatePatientHistoryChartData
    {
        Task<ApiCallResult> PutHpiDataByEncounterId(string encounterid, HpiDataTemplate hpiDataTemplate);
    }
}