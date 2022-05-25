using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AthenaHealthDataAnalytics.Core.Util
{
    public static class AutoMapperConfiguration
    {
        public static IMapper _mapper;
        public static void RegisterMapper(IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DefaultMappingProfile());
            });
            _mapper = mappingConfig.CreateMapper();
            services.AddSingleton(_mapper);
        }
    }
}
