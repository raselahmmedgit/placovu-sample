using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGamingApp.Core.EnitityModel
{
    public class QuizGameAnswer
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "clientProfileId")]
        public string ClientProfileId { get; set; }
        [JsonProperty(PropertyName = "playerProfileId")]
        public string PlayerProfileId { get; set; }
        [JsonProperty(PropertyName = "quizQuestionId")]
        public string QuizQuestionId { get; set; }
        [JsonProperty(PropertyName = "questionAnserId")]
        public string QuestionAnserId { get; set; }
        [JsonProperty(PropertyName = "submitedDate")]
        public DateTime SubmitedDate { get; set; }
        [JsonProperty(PropertyName = "isDeleted")]
        public bool IsDeleted { get; set; }
    }
}
