using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGamingApp.Core.EnitityModel
{
    public class GameSubscriptionType
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "GameSubscriptionTypeId")]
        public int GameSubscriptionTypeId { get; set; }
        [JsonProperty(PropertyName = "GameSubscriptionTypeName")]
        public string GameSubscriptionTypeName { get; set; }
    }
}
