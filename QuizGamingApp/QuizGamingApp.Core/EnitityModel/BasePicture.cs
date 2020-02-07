using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGamingApp.Core.EnitityModel
{
    public partial class BasePicture : Base
    {
        [JsonProperty(PropertyName = "pictureTypeId")]
        public int PictureTypeId { get; set; }
        [JsonProperty(PropertyName = "mimeType")]
        public string MimeType { get; set; }
        [JsonProperty(PropertyName = "seoFilename")]
        public string SeoFilename { get; set; }
        [JsonProperty(PropertyName = "altAttribute")]
        public string AltAttribute { get; set; }
        [JsonProperty(PropertyName = "titleAttribute")]
        public string TitleAttribute { get; set; }
        [JsonProperty(PropertyName = "virtualPath")]
        public string VirtualPath { get; set; }
        [JsonProperty(PropertyName = "isNew")]
        public bool IsNew { get; set; }
        [JsonProperty(PropertyName = "isTemporaryPicture")]
        public bool? IsTemporaryPicture { get; set; }

    }
}
