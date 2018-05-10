using lab.SecurityApp.Models;
using lab.SecurityApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab.SecurityApp.Helpers
{
    public static class AutoMapperHelper
    {
        public static void RegisterMaps()
        {
            // Source , Destination
            AutoMapper.Mapper.Initialize(config => {

                config.CreateMap<RoleViewModel, Role>();
                config.CreateMap<Role, RoleViewModel>();

            });
        }

    }
}