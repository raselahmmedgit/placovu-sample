using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizGamingApp.Core.EnitityModel;
using System.Configuration;

namespace QuizGamingApp.Core.DAL
{
    public class GameModeRepository : BaseRepository<GameMode>
    {
        public GameModeRepository() : base(typeof(GameMode).Name)
        {

        }
    }
}
