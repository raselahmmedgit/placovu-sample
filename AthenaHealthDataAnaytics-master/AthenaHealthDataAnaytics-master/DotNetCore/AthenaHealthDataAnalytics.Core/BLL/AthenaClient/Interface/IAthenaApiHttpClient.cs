using System.Collections.Generic;
using System.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace AthenaHealthDataAnalytics.Core.BLL.AthenaClient.Interface
{
    public interface IAthenaApiHttpClient
    {
        Task<string> GetFileAsBase64String(string absolutePath);

        Task<string> GetFileAsBase64String(string relativePath, Dictionary<string, string> parameters = default,
            Dictionary<string, string> headers = default);
        
        Task<JsonValue> GetJson(string path, Dictionary<string, string> parameters = default,
            Dictionary<string, string> headers = default);

        Task<HttpResponseMessage> PutRequest(string path, Dictionary<string, string> parameters = default,
            Dictionary<string, string> headers = default);
    }
}