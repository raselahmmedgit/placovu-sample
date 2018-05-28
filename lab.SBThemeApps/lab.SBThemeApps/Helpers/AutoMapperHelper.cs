using lab.SBThemeApps.Models;
using lab.SBThemeApps.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab.SBThemeApps.Helpers
{
    public static class AutoMapperHelper
    {
        public static void RegisterMaps()
        {
            // Source , Destination
            AutoMapper.Mapper.Initialize(config => {

                config.CreateMap<StudentViewModel, Student>();
                config.CreateMap<Student, StudentViewModel>();

            });
        }

    }
}