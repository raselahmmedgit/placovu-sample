using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGamingApp.Core.EnitityModel
{
    public class Game : Base
    {
        [JsonProperty(PropertyName = "gameTitle")]
        public string GameTitle { get; set; }
        [JsonProperty(PropertyName = "gameDescription")]
        public string GameDescription { get; set; }
        [JsonProperty(PropertyName = "gameTypeId")]
        public int GameTypeId { get; set; }
        [JsonProperty(PropertyName = "gameModeId")]
        public int GameModeId { get; set; }
        [JsonProperty(PropertyName = "monthlyGamePrice")]
        public decimal MonthlyGamePrice { get; set; }
        [JsonProperty(PropertyName = "yearlyDiscount")]
        public decimal YearlyDiscount { get; set; }


    }
}
