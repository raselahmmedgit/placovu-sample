using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGamingApp.Core.EnitityModel
{
    public class QuizGameCouponDetail
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "quizGameId")]
        public string QuizGameId { get; set; }
        [JsonProperty(PropertyName = "rewardingPlayerTypeId")]
        public int RewardingPlayerTypeId { get; set; }
        [JsonProperty(PropertyName = "rewardDistributionTypeId")]
        public int RewardDistributionTypeId { get; set; }
        [JsonProperty(PropertyName = "numberOfCouponReward")]
        public int NumberOfCouponReward { get; set; }

    }
}
