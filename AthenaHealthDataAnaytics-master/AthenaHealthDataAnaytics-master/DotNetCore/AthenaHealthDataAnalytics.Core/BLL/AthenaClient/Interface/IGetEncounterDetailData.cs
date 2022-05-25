using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace AthenaHealthDataAnalytics.Core.BLL.AthenaClient.Interface
{
    public interface IGetEncounterDetailData
    {
        Task<List<BsonDocument>> GetEncounterDiagnoses(string encounterid);
        Task<List<BsonDocument>> GetEncounterDescription(string encounterid);
        Task<BsonDocument> GetEncounterAssessment(string encounterid);
        Task<BsonDocument> GetEncounterDefaultSearchFacilities(string encounterid);
        Task<BsonDocument> GetEncounterHpi(string encounterid);
        Task<List<BsonDocument>> GetEncounterOrders(string encounterid);
        Task<BsonDocument> GetEncounterPhysicalExam(string encounterid);
        Task<List<BsonDocument>> GetEncounterProcedureDocumentation(string encounterid);
        Task<List<BsonDocument>> GetEncounterVitals(string encounterid);
        Task<BsonDocument> GetEncounterServices(string encounterid);

    }
    
    /*
     * not Included
     *  GET /chart/encounter/{encounterid}/dictatablesections
     * GET /chart/encounter/{encounterid}/dictationstatus
     * GET /chart/encounter/{encounterid}/documentsreview
     * GET /chart/encounter/{encounterid}/encounterreasons
     *  GET /chart/encounter/{encounterid}/hpi/templates
     * GET /chart/encounter/{encounterid}/orders/outstanding
     * GET /chart/encounter/{encounterid}/orders/{orderid}
     *  GET /chart/encounter/{encounterid}/orders/{orderid}/deny
     * GET /chart/encounter/{encounterid}/patientgoals
     *  GET /chart/encounter/{encounterid}/physicalexam/templates
     *  GET /chart/encounter/{encounterid}/questionnairescreeners
     * GET /chart/encounter/{encounterid}/reviewofsystems
     *  GET /chart/encounter/{encounterid}/reviewofsystems/templates
     * GET /encounter/{encounterid}/procedurecodes
     *  GET /encounter/{encounterid}/services/{serviceid} 
     */
}