using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGamingApp.Core.EnitityModel
{
    public class GameSubscription : Base
    {
        [JsonProperty(PropertyName = "clientProfileId")]
        public string ClientProfileId { get; set; }
        [JsonProperty(PropertyName = "gameId")]
        public string GameId { get; set; }
        [JsonProperty(PropertyName = "subscriptionTypeId")]
        public int SubscriptionTypeId { get; set; }
        [JsonProperty(PropertyName = "paymentAmount")]
        public decimal PaymentAmount { get; set; }
        [JsonProperty(PropertyName = "startDate")]
        public DateTime StartDate { get; set; }
        [JsonProperty(PropertyName = "endDate")]
        public DateTime EndDate { get; set; }
    }
}
