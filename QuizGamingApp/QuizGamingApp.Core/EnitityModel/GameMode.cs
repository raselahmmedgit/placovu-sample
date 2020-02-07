using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGamingApp.Core.EnitityModel
{
    public class GameMode
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "gameModeId")]
        public int GameModeId { get; set; }
        [JsonProperty(PropertyName = "gameModeName")]
        public string GameModeName { get; set; }
    }
}
