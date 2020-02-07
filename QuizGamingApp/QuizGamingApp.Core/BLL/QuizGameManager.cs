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
    public class QuizGameManager
    {
        private QuizGameRepository _quizGameRepository;

        public QuizGameManager()
        {
            _quizGameRepository = new QuizGameRepository();
        }
        public async Task<IEnumerable<QuizGame>> IndexAsync()
        {
            var items = await _quizGameRepository.GetItemsAsync(d => !d.IsDeleted);
            return items;
        }

        public async Task CreateAsync(QuizGame quizGame)
        {

            Document document = await _quizGameRepository.CreateItemAsync(quizGame);
        }

        public async Task EditAsync(QuizGame quizGame)
        {
            await _quizGameRepository.UpdateItemAsync(quizGame.Id, quizGame);
        }

        public async Task DeleteConfirmedAsync(string id)
        {
            await _quizGameRepository.DeleteItemAsync(id);
        }

        public async Task<QuizGame> GetItemAsync(string id)
        {
            QuizGame quizGame = await _quizGameRepository.GetItemAsync(id);
            return quizGame;
        }
    }
}
