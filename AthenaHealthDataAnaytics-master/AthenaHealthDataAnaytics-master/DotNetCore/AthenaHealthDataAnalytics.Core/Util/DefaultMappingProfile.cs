using AthenaHealthDataAnalytics.Core.EntityModels;
using AthenaHealthDataAnalytics.Core.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AthenaHealthDataAnalytics.Core.Util
{
    public class DefaultMappingProfile : Profile
    {
        public DefaultMappingProfile()
        {
            CreateMap<PatientDetail, AthenaPatientDataViewModel>();
            CreateMap<AthenaPatientDataViewModel, PatientDetail>();
        }
    }
}
