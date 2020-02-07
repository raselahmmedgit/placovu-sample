using Microsoft.Azure.Documents;
using QuizGamingApp.Core.DAL;
using QuizGamingApp.Core.EnitityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGamingApp.Core.BLL
{
    public class GameCouponManager
    {
        private GameCouponRepository _gameCouponRepository;

        public GameCouponManager()
        {
            _gameCouponRepository = new GameCouponRepository();
        }
        public async Task<IEnumerable<GameCoupon>> IndexAsync()
        {
            var items = await _gameCouponRepository.GetItemsAsync(d => !d.IsDeleted);
            return items;
        }

        public async Task CreateAsync(GameCoupon gameCoupon)
        {

            Document document = await _gameCouponRepository.CreateItemAsync(gameCoupon);
        }

        public async Task EditAsync(GameCoupon gameCoupon)
        {
            await _gameCouponRepository.UpdateItemAsync(gameCoupon.Id, gameCoupon);
        }

        public async Task DeleteConfirmedAsync(string id)
        {
            await _gameCouponRepository.DeleteItemAsync(id);
        }

        public async Task<GameCoupon> GetItemAsync(string id)
        {
            GameCoupon gameCoupon = await _gameCouponRepository.GetItemAsync(id);
            return gameCoupon;
        }
    }
}
