using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AthenaHealthDataAnalytics.Core.BLL.AthenaClient.Interface;
using BLL.AthenaClient;
using log4net;
using MongoDB.Bson;

namespace AthenaHealthDataAnalytics.Core.BLL.AthenaClient.Service
{
    public class AthenaApiHttpClient : IAthenaApiHttpClient
    {
        private ILog _log;
        private string practiceID;
        private string version;
        private string key;
        private string secret;
        private string baseUrl;
        private string token;
        private readonly HttpClient _httpClient;
        private APIConnection _ApiConnection { get; set; }
        private readonly AthenaHealthApiConnectionManager _athenaHealthApiConnectionManager;

        public AthenaApiHttpClient(HttpClient httpClient, IAthenaHealthConfigs athenaHealthConfigs)
        {
            _athenaHealthApiConnectionManager = new AthenaHealthApiConnectionManager(athenaHealthConfigs);
            _ApiConnection = _athenaHealthApiConnectionManager.Connection;
            baseUrl = "https://api.athenahealth.com/";
            version = athenaHealthConfigs.APIVersion;
            secret = athenaHealthConfigs.APISecret;
            key = athenaHealthConfigs.APIKey;
            practiceID = athenaHealthConfigs.practiceId;
            _log = LogManager.GetLogger(typeof(AthenaApiHttpClient));
            httpClient.Timeout = TimeSpan.FromMinutes(5);
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> PutRequest(string path, Dictionary<string, string> parameters = default,
            Dictionary<string, string> headers = default)
        {
            try{
                StringBuilder url = new StringBuilder();
                url.Append(PathJoin(baseUrl, version, practiceID, path));
                if (headers != null)
                {
                    foreach (KeyValuePair<string,string> header in headers)
                    {
                        if(!string.IsNullOrEmpty(header.Value) && !string.IsNullOrEmpty(header.Key))
                            _httpClient.DefaultRequestHeaders.Add(header.Key,header.Value);
                    }
                }

                if (parameters != null)
                {
                    url.Append( "?" + UrlEncode(parameters));
                }
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _ApiConnection.GetToken());
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
                var result = await _httpClient.PutAsync(url.ToString(),default);
                return result;
            }
            catch (Exception ex)
            {
                _log.Error("Error in httpclient PutRequest, "+$"path: {path}, ex: " + ex);  
                return null;
            }
        }
        
        public async Task<JsonValue> GetJson(string path, Dictionary<string, string> parameters = default,
            Dictionary<string, string> headers = default)
        {
            try{
                StringBuilder url = new StringBuilder();
                url.Append(PathJoin(baseUrl, version, practiceID, path));
                if (headers != null)
                {
                    foreach (KeyValuePair<string,string> header in headers)
                    {
                        if(!string.IsNullOrEmpty(header.Value) && !string.IsNullOrEmpty(header.Key))
                            _httpClient.DefaultRequestHeaders.Add(header.Key,header.Value);
                    }
                }

                if (parameters != null)
                {
                    url.Append( "?" + UrlEncode(parameters));
                }
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _ApiConnection.GetToken());
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
                string data = await _httpClient.GetStringAsync(url.ToString());
                return JsonValue.Parse(data);
            }
            catch (Exception ex)
            {
                _log.Error("Error in httpclient getJson, "+$"path: {path}, ex: " + ex);  
                return null;
            }
        }
        
        public async Task<string> GetFileAsBase64String(string relativePath, Dictionary<string, string> parameters = default,
            Dictionary<string, string> headers = default)
        {
            try{
                StringBuilder url = new StringBuilder();
                url.Append(PathJoin(baseUrl, version, practiceID, relativePath));
                if (headers != null)
                {
                    foreach (KeyValuePair<string,string> header in headers)
                    {
                        if(!string.IsNullOrEmpty(header.Value) && !string.IsNullOrEmpty(header.Key))
                            _httpClient.DefaultRequestHeaders.Add(header.Key,header.Value);
                    }
                }

                if (parameters != null)
                {
                    url.Append( "?" + UrlEncode(parameters));
                }
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _ApiConnection.GetToken());
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
                HttpResponseMessage msg = await _httpClient.GetAsync(url.ToString());
                string data = string.Empty;
                if (msg.IsSuccessStatusCode)
                {
                    var contentStream = await msg.Content.ReadAsByteArrayAsync(); // get the actual content stream   
                    data = System.Convert.ToBase64String(contentStream);
                }
                return data;
            }
            catch (Exception ex)
            {
                _log.Error("Error in httpclient getJson, "+$"path: {relativePath}, ex: " + ex);  
                return null;
            }
        }

        public async Task<string> GetFileAsBase64String(string absolutePath)
        {
            try{
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _ApiConnection.GetToken());
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
                HttpResponseMessage msg = await _httpClient.GetAsync(absolutePath);
                string data = string.Empty;
                if (msg.IsSuccessStatusCode)
                {
                    var contentStream = await msg.Content.ReadAsByteArrayAsync(); // get the actual content stream   
                    data = Convert.ToBase64String(contentStream);
                }
                return data;
            }
            catch (Exception ex)
            {
                _log.Error("Error in httpclient getJson, "+$"path: {absolutePath}, ex: " + ex);  
                return null;
            }
        }
        
        string UrlEncode(Dictionary<string, string> parameters)
        {
            var paramList = new List<string>();
            foreach (KeyValuePair<string,string> kvp in parameters)
            {
                if (!string.IsNullOrEmpty(kvp.Value) && !string.IsNullOrEmpty(kvp.Key))
                    paramList.Add(WebUtility.UrlEncode(kvp.Key) + "=" + WebUtility.UrlEncode(kvp.Value));
            }
            return string.Join("&", paramList);
        }

        string PathJoin(params string[] args)
        {
            return string.Join("/", args
                .Select(arg => arg.Trim(new char[] { '/' }))
                .Where(arg => !String.IsNullOrEmpty(arg))
            );
        }

    }
}