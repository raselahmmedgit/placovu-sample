using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGamingApp.Core.EnitityModel
{
    public class PlayerLoginType
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "PlayerLoginTypeId")]
        public int PlayerLoginTypeId { get; set; }
        [JsonProperty(PropertyName = "PlayerLoginTypeName")]
        public string PlayerLoginTypeName { get; set; }
    }
}
