using QuizGamingApp.Core.EnitityModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGamingApp.Core.DAL
{
    class GameSubscriptionRepository : BaseRepository<GameSubscription>
    {
        public GameSubscriptionRepository() : base(typeof(GameSubscription).Name)
        {

        }
    }
}
