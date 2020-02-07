using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGamingApp.Core.EnitityModel
{
    public class QuestionAnswer : Base
    {
        [JsonProperty(PropertyName = "quizQuestionId")]
        public string QuizQuestionId { get; set; }
        [JsonProperty(PropertyName = "answerText")]
        public string AnswerText { get; set; }
        [JsonProperty(PropertyName = "isCorrectAnswer")]
        public bool IsCorrectAnswer { get; set; }
        [JsonProperty(PropertyName = "displayOrder")]
        public int DisplayOrder { get; set; }
    }
}
