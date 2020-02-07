using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGamingApp.Core.EnitityModel
{
    public class RewardDistributionType
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "RewardDistributionTypeId")]
        public int RewardDistributionTypeId { get; set; }
        [JsonProperty(PropertyName = "RewardDistributionTypeName")]
        public string RewardDistributionTypeName { get; set; }
    }
}
