using QuizGamingApp.Core.EnitityModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGamingApp.Core.DAL
{
    public class GameSubscriptionTypeRepository : BaseRepository<GameSubscriptionType>
    {
        public GameSubscriptionTypeRepository() : base(typeof(GameSubscriptionType).Name)
        {
                
        }
    }
}
