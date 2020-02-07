using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGamingApp.Core.EnitityModel
{
    public class GameType
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "gameTypeId")]
        public int GameTypeId { get; set; }
        [JsonProperty(PropertyName = "gameTypeName")]
        public string GameTypeName { get; set; }
    }
}
