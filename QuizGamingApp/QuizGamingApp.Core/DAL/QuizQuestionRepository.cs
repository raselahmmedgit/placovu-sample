using QuizGamingApp.Core.EnitityModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGamingApp.Core.DAL
{
    public class QuizQuestionRepository : BaseRepository<QuizQuestion>
    {
        public QuizQuestionRepository() : base(typeof(QuizQuestion).Name)
        {

        }
    }
}
