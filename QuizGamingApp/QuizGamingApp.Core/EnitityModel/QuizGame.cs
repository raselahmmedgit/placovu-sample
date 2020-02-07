using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGamingApp.Core.EnitityModel
{
    public class QuizGame : Base
    {
        [JsonProperty(PropertyName = "clientProfileId")]
        public string ClientProfileId { get; set; }
        [JsonProperty(PropertyName = "gameName")]
        public string GameId { get; set; }
        [JsonProperty(PropertyName = "gameNumber")]
        public string MainBoardIntroText { get; set; }
        [JsonProperty(PropertyName = "mainBoardFinalText")]
        public string MainBoardFinalText { get; set; }
        [JsonProperty(PropertyName = "mobileIntroText")]
        public string MobileIntroText { get; set; }
        [JsonProperty(PropertyName = "mobileFinalText")]
        public string MobileFinalText { get; set; }
        [JsonProperty(PropertyName = "winnerMessage")]
        public string WinnerMessage { get; set; }
        [JsonProperty(PropertyName = "loserMessage")]
        public string LoserMessage { get; set; }
        [JsonProperty(PropertyName = "playerLoginTypeId")]
        public int PlayerLoginTypeId { get; set; }


    }
}
