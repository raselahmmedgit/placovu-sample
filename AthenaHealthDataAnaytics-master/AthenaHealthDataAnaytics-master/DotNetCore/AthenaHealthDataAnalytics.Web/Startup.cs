using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using AthenaHealthDataAnalytics.Web.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BLL.AthenaClient;
using Microsoft.Extensions.Options;
using AthenaHealthDataAnalytics.Core.BLL.MongoDBClient;
using AthenaHealthDataAnalytics.Core.BLL;
using AthenaHealthDataAnalytics.Core.BLL.Interface;
using AthenaHealthDataAnalytics.Core.Util;
using AutoMapper;
using DataTables.AspNet.AspNetCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using AthenaHealthDataAnalytics.Core.BLL.AthenaClient.Interface;
using AthenaHealthDataAnalytics.Core.BLL.AthenaClient.Service;
using System.Net.Http;
using Polly.Extensions.Http;
using Polly;

namespace AthenaHealthDataAnalytics.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IServiceProvider Services { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            // requires using Microsoft.Extensions.Options
            services.Configure<AthenaHealthConfigs>(
                Configuration.GetSection(nameof(AthenaHealthConfigs)));

            services.AddSingleton<IAthenaHealthConfigs>(sp =>
                sp.GetRequiredService<IOptions<AthenaHealthConfigs>>().Value);

            services.Configure<MongoDatabaseSettings>(
                Configuration.GetSection(nameof(MongoDatabaseSettings)));

            services.AddSingleton<IMongoDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<MongoDatabaseSettings>>().Value);

            services.TryAddTransient(s => s.GetRequiredService<IHttpClientFactory>().CreateClient(string.Empty));
            services.AddHttpClient<IAthenaApiHttpClient, AthenaApiHttpClient>().SetHandlerLifetime(TimeSpan.FromMinutes(5)).AddPolicyHandler(e=>
            {
                return HttpPolicyExtensions
                        .HandleTransientHttpError()
                        .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                        .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
            });
            services.AddTransient<IGetEncounterDetailData, GetEncounterDetailData>();
            services.AddTransient<IGetPatientDetailData, GetPatientDetailData>();
            services.AddTransient<IGetPatientDocumentData, GetPatientDocumentData>();
            services.AddTransient<IGetPatientFinancialData, GetPatientFinancialData>();
            services.AddTransient<IGetPatientHistoryChartData, GetPatientHistoryChartData>();
            services.AddTransient<IGetPatientSecureMessagingData, GetPatientSecureMessagingData>();
            services.AddTransient<IAthenaPatientDataManager,AthenaPatientDataManager>();
            services.AddTransient<IAthenaPatientDataViewManager, AthenaPatientDataViewManager>();
            services.AddTransient<IAthenaHealthApiManager, AthenaHealthApiManager>();
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();

            //AutoMapper registration
            AutoMapperConfiguration.RegisterMapper(services);

            // DataTables.AspNet registration with default options.
            services.RegisterDataTables();
            /*using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var athenaService = scope.ServiceProvider.GetRequiredService<IAthenaHealthApiManager>();
                var dbService = scope.ServiceProvider.GetRequiredService<IAthenaPatientDataViewManager>();
                var data = dbService.GetPatientDetailByPatientId("522632").GetAwaiter().GetResult();
                if (data==null)
                {
                    athenaService.GetAthenaPatientData("522632", "20").GetAwaiter().GetResult();
                }
            }*/
                
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IAthenaHealthConfigs athenaHealthConfigs, IMongoDatabaseSettings mongoDatabaseSettings)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            
        }
    }
}
