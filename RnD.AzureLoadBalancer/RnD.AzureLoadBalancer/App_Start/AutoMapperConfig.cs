using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using RnD.AzureLoadBalancer.Models;
using AutoMapper;

namespace RnD.AzureLoadBalancer.App_Start
{
    public static class AutoMapperConfig
    {
        public static IMapper Mapper;
        public static void RegisterMapper()
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingConfig());
            });
            Mapper = mappingConfig.CreateMapper();
            //mappingConfig.AssertConfigurationIsValid();
        }
    }

    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<ApplicationSetting, ApplicationSettingViewModel>();
            CreateMap<ApplicationSettingViewModel, ApplicationSetting>();
        }
    }
}