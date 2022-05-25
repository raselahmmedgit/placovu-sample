using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace BLL.AthenaClient
{
    public class AthenaHealthConfigs : IAthenaHealthConfigs
    {
        public string APIKey { get; set; } 
        public string APISecret { get; set; }
        public string APIVersion { get; set; } 
        public string practiceId { get; set; }

    }
    public interface IAthenaHealthConfigs
    {
         string APIKey { get; set; }
         string APISecret { get; set; }
         string APIVersion { get; set; }
         string practiceId { get; set; }
    }
    public class AthenaHealthApiConnectionManager
    {
        public AthenaHealthApiConnectionManager(IAthenaHealthConfigs athenaHealthConfigs)
        {
            Connection = new APIConnection(athenaHealthConfigs.APIVersion, athenaHealthConfigs.APIKey, athenaHealthConfigs.APISecret, athenaHealthConfigs.practiceId);
        }
        public APIConnection Connection { get; }
    }
    
}
