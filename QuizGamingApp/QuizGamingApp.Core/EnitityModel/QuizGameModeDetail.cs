using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGamingApp.Core.EnitityModel
{
    public class QuizGameModeDetail
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "quizGameId")]
        public string QuizGameId { get; set; }
        [JsonProperty(PropertyName = "gameModeId")]
        public int GameModeId { get; set; }
        [JsonProperty(PropertyName = "roundTimeInSec")]
        public int RoundTimeInSec { get; set; }
        [JsonProperty(PropertyName = "maximumPoint")]
        public int MaximumPoint { get; set; }
        [JsonProperty(PropertyName = "totalRound")]
        public int TotalRound { get; set; }
    }
}
