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
    public class PlayerProfileManager
    {
        private PlayerProfileRepository _playerProfileRepository;

        public PlayerProfileManager()
        {
            _playerProfileRepository = new PlayerProfileRepository();
        }
        public async Task<IEnumerable<PlayerProfile>> IndexAsync()
        {
            var items = await _playerProfileRepository.GetItemsAsync(d => !d.IsDeleted);
            return items;
        }

        public async Task CreateAsync(PlayerProfile playerProfile)
        {

            Document document = await _playerProfileRepository.CreateItemAsync(playerProfile);
        }

        public async Task EditAsync(PlayerProfile playerProfile)
        {
            await _playerProfileRepository.UpdateItemAsync(playerProfile.Id, playerProfile);
        }

        public async Task DeleteConfirmedAsync(string id)
        {
            await _playerProfileRepository.DeleteItemAsync(id);
        }

        public async Task<PlayerProfile> GetItemAsync(string id)
        {
            PlayerProfile playerProfile = await _playerProfileRepository.GetItemAsync(id);
            return playerProfile;
        }
    }
    
}
