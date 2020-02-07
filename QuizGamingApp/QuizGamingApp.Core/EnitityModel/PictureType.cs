using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGamingApp.Core.EnitityModel
{
    public class PictureType
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "pictureTypeId")]
        public int PictureTypeId { get; set; }
        [JsonProperty(PropertyName = "pictureTypeName")]
        public string PictureTypeName { get; set; }
    }
}
