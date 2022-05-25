using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using AthenaHealthDataAnalytics.Core.BLL;
using AthenaHealthDataAnalytics.Core.BLL.AthenaClient.Interface;
using AthenaHealthDataAnalytics.Core.BLL.AthenaClient.Service;
using AthenaHealthDataAnalytics.Core.BLL.MongoDBClient;
using BLL.AthenaClient;
using log4net;
using log4net.Config;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Extensions.Http;

namespace AthenaHealthDataAnalytics.DataIntegrationJob
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                XmlDocument log4netConfig = new XmlDocument();
                log4netConfig.Load(File.OpenRead("log4net.config"));
                var repo = LogManager.CreateRepository(Assembly.GetEntryAssembly(),
                    typeof(Hierarchy));
                XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseWindowsService()
            .ConfigureLogging((hostingContext, config) =>
            {

                config.AddLog4Net("log4net.config", true);
                config.SetMinimumLevel(LogLevel.Information);
            })
            .ConfigureServices((hostContext, services) =>
            {
                IConfiguration Configuration = hostContext.Configuration;
                services.AddHostedService<GetAthenaPatientDataService>();
                // requires using Microsoft.Extensions.Options
                services.Configure<AthenaHealthConfigs>(Configuration.GetSection(nameof(AthenaHealthConfigs)));

                services.AddSingleton<IAthenaHealthConfigs>(sp => sp.GetRequiredService<IOptions<AthenaHealthConfigs>>().Value);

                services.Configure<MongoDatabaseSettings>(Configuration.GetSection(nameof(MongoDatabaseSettings)));

                services.AddSingleton<IMongoDatabaseSettings>(sp => sp.GetRequiredService<IOptions<MongoDatabaseSettings>>().Value);

                services.TryAddTransient(s => s.GetRequiredService<IHttpClientFactory>().CreateClient(string.Empty));
                services.AddHttpClient<IAthenaApiHttpClient, AthenaApiHttpClient>().SetHandlerLifetime(TimeSpan.FromMinutes(5)).AddPolicyHandler(GetRetryPolicy());
                services.AddTransient<IGetEncounterDetailData, GetEncounterDetailData>();
                services.AddTransient<IGetPatientDetailData, GetPatientDetailData>();
                services.AddTransient<IGetPatientDocumentData, GetPatientDocumentData>();
                services.AddTransient<IGetPatientFinancialData, GetPatientFinancialData>();
                services.AddTransient<IGetPatientHistoryChartData, GetPatientHistoryChartData>();
                services.AddTransient<IGetPatientSecureMessagingData, GetPatientSecureMessagingData>();
                services.AddTransient<ICreateUpdatePatientHistoryChartData, CreateUpdatePatientHistoryChartData>();
                services.AddTransient<IAthenaPatientDataManager, AthenaPatientDataManager>();
            });

        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }
    }
}
