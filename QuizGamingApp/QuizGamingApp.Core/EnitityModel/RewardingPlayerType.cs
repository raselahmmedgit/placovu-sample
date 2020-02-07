using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGamingApp.Core.EnitityModel
{
    public class RewardingPlayerType
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "RewardingPlayerTypeId")]
        public int RewardingPlayerTypeId { get; set; }
        [JsonProperty(PropertyName = "RewardingPlayerTypeName")]
        public string RewardingPlayerTypeName { get; set; }
    }
}
