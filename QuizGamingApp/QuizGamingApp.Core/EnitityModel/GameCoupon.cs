using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGamingApp.Core.EnitityModel
{
    public class GameCoupon : Base
    {
        [JsonProperty(PropertyName = "couponTitle")]
        public string CouponTitle { get; set; }
        [JsonProperty(PropertyName = "prizeMoney")]
        public decimal PrizeMoney { get; set; }
        [JsonProperty(PropertyName = "startDate")]
        public DateTime StartDate { get; set; }
        [JsonProperty(PropertyName = "endDate")]
        public DateTime EndDate { get; set; }
        [JsonProperty(PropertyName = "pictureId")]
        public string PictureId { get; set; }
    }
}
