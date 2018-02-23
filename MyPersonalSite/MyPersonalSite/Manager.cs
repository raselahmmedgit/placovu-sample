using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MyPersonalSite.EntityModel;

namespace MyPersonalSite
{
    public class PatientSurveyManager
    {
        private readonly OntrackHealthEntities _ontrackHealthEntities;
        public PatientSurveyManager()
        {
            _ontrackHealthEntities = new OntrackHealthEntities();
        }
        
        public async Task<IEnumerable<PatientSurveyActivityDetailView>> GetPatientSurveyActivityDetailView()
        {
            var query = _ontrackHealthEntities.PatientSurveyActivityDetailViews.AsQueryable();
            return await query.ToListAsync();
        }
        public async Task<IEnumerable<PatientSurveyActivityView>> GetPatientSurveyActivity()
        {
            string query = " select newid() as AutoPk, * from"
                           + " ("
                               + " select PatientProfileId, ProcedureId, NotificationTitle, SurveyQuestionSetName, convert(date,t1.NotificationDate) NotificationDate"
                               + " from PatientSurveyActivityView t1"
                               + " where t1.HasSubmited = 0 and t1.NotificationDate <= GETUTCDATE()"
                               + " group by PatientProfileId, ProcedureId, NotificationTitle, SurveyQuestionSetName, convert(date,t1.NotificationDate)"
                           + " ) t1"
                           + " outer apply("
                           + " select dbo.DecryptString(PreferredName, dbo.HashKey('Qwer!234'), dbo.HashSalt('!234Qwer')) PreferredName"
                           + " , dbo.DecryptString(EmailAddress, dbo.HashKey('Qwer!234'), dbo.HashSalt('!234Qwer')) EmailAddress"
                           + " , isnull(PrimaryPhoneCode,'') + '' + dbo.DecryptString(PrimaryPhone, dbo.HashKey('Qwer!234'), dbo.HashSalt('!234Qwer')) PrimaryPhone"
                           + " from PatientProfile t2 where t2.PatientProfileId = t1.PatientProfileId"
                           + " ) tt1"
                           + " outer apply("
                           + " select ProcedureName from[Procedure] t3 where t3.ProcedureId = t1.ProcedureId"
                           + " ) tt2";
            return await _ontrackHealthEntities.Database.SqlQuery<PatientSurveyActivityView>("exec [dbo].[SpPatientSurveyActivityForExcel]").ToListAsync();
            //var query = _ontrackHealthEntities.PatientSurveyActivityViews.Where(x=> x.HasSubmited == false && x.NotificationDate <= DateTime.UtcNow).AsQueryable();
           // return await query.ToListAsync();
        }
    }
}