using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using QuizGamingApp.Core.EnitityModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGamingApp.Core.DAL
{
    public class QuizGamingAppDBRepository
    {
        private static readonly string DatabaseId = ConfigurationManager.AppSettings["IdDocDb_Database"];
        private static DocumentClient QuizGamingAppClient;
        private static void Initialize()
        {
            QuizGamingAppClient = new DocumentClient(new Uri(ConfigurationManager.AppSettings["IdDocDb_Uri"]), ConfigurationManager.AppSettings["IdDocDb_AuthKey"]);
            CreateDatabaseIfNotExistsAsync().Wait();
            CreateTablesIfNotExists().Wait();
            InsertMasterDataAsync().Wait();
        }
        public static DocumentClient GetDocumentClient()
        {
            if (QuizGamingAppClient == null)
                Initialize();
            return QuizGamingAppClient;
        }
        public static void CreateDocumentClient()
        {
            if (QuizGamingAppClient == null)
                Initialize();
        }
        public static string GetDatabaseId()
        {
            return DatabaseId;
        }
        private static async Task CreateDatabaseIfNotExistsAsync()
        {
            try
            {
                bool IsCreateDatabase = ConfigurationManager.AppSettings["IsCreateDatabase"] != null ? bool.Parse(ConfigurationManager.AppSettings["IsCreateDatabase"]) : false;
                try
                {
                    if (IsCreateDatabase)
                    {
                        await QuizGamingAppClient.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(DatabaseId));
                    }
                }
                catch (DocumentClientException e)
                {
                    if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        await QuizGamingAppClient.CreateDatabaseAsync(new Database { Id = DatabaseId });
                    }
               
                }
            }
            catch (Exception)
            {

            }
           
        }

        private static async Task CreateTablesIfNotExists()
        {
            try
            {
                bool IsCreateTable = ConfigurationManager.AppSettings["IsCreateTable"] != null ? bool.Parse(ConfigurationManager.AppSettings["IsCreateTable"]) : false;
                if (!IsCreateTable)
                {
                    return;
                }
                new ClientProfileRepository().Initialize();
                new PlayerProfileRepository().Initialize();
                new QuizGameRepository().Initialize();
                new QuizQuestionRepository().Initialize();
                new QuestionAnswerRepository().Initialize();
                new QuizGameAnswerRepository().Initialize();

                new GameRepository().Initialize();
                new GameCouponRepository().Initialize();
                new GameModeRepository().Initialize();
                new GameSubscriptionRepository().Initialize();
                new GameSubscriptionTypeRepository().Initialize();
                new GameTypeRepository().Initialize();
                new PlayerLoginTypeRepository().Initialize();
                new RewardDistributionTypeRepository().Initialize();
                new RewardingPlayerTypeRepository().Initialize();
            }
            catch (Exception)
            {

            }
            
        }

        private static async Task InsertMasterDataAsync()
        {

            try
            {
                bool IsInsertMasterData = ConfigurationManager.AppSettings["IsInsertMasterData"] != null ? bool.Parse(ConfigurationManager.AppSettings["IsInsertMasterData"]) : false;
                if (!IsInsertMasterData)
                {
                    return;
                }
                GameTypeRepository gameTypeRepository = new GameTypeRepository();
                GameModeRepository gameModeRepository = new GameModeRepository();
                PlayerLoginTypeRepository playerLoginTypeRepository = new PlayerLoginTypeRepository();
                RewardDistributionTypeRepository rewardDistributionTypeRepository = new RewardDistributionTypeRepository();
                GameSubscriptionTypeRepository gameSubscriptionTypeRepository = new GameSubscriptionTypeRepository();
                RewardingPlayerTypeRepository rewardingPlayerTypeRepository = new RewardingPlayerTypeRepository();

                GameType gameType = new GameType()
                {
                    GameTypeId = 1,
                    GameTypeName = "Trivia",
                };
                await gameTypeRepository.CreateItemAsync(gameType);

                PlayerLoginType playerLoginType = new PlayerLoginType()
                {
                    PlayerLoginTypeId = 1,
                    PlayerLoginTypeName = "Anonymous"
                };
                await playerLoginTypeRepository.CreateItemAsync(playerLoginType);

                playerLoginType = new PlayerLoginType()
                {
                    PlayerLoginTypeId = 2,
                    PlayerLoginTypeName = "Registration"
                };
                await playerLoginTypeRepository.CreateItemAsync(playerLoginType);

                RewardDistributionType rewardDistributionType = new RewardDistributionType()
                {
                    RewardDistributionTypeId = 1,
                    RewardDistributionTypeName = "Winners"
                };
                await rewardDistributionTypeRepository.CreateItemAsync(rewardDistributionType);
                rewardDistributionType = new RewardDistributionType()
                {
                    RewardDistributionTypeId = 2,
                    RewardDistributionTypeName = "Losers"
                };
                await rewardDistributionTypeRepository.CreateItemAsync(rewardDistributionType);

                rewardDistributionType = new RewardDistributionType()
                {
                    RewardDistributionTypeId = 3,
                    RewardDistributionTypeName = "Everyone"
                };
                await rewardDistributionTypeRepository.CreateItemAsync(rewardDistributionType);

                RewardingPlayerType rewardingPlayerType = new RewardingPlayerType()
                {
                    RewardingPlayerTypeId = 1,
                    RewardingPlayerTypeName = "Lottery"
                };
                await rewardingPlayerTypeRepository.CreateItemAsync(rewardingPlayerType);

                rewardingPlayerType = new RewardingPlayerType()
                {
                    RewardingPlayerTypeId = 2,
                    RewardingPlayerTypeName = "Leaderboard"
                };
                await rewardingPlayerTypeRepository.CreateItemAsync(rewardingPlayerType);

                rewardingPlayerType = new RewardingPlayerType()
                {
                    RewardingPlayerTypeId = 3,
                    RewardingPlayerTypeName = "For all"
                };
                await rewardingPlayerTypeRepository.CreateItemAsync(rewardingPlayerType);

                GameSubscriptionType gameSubscriptionType = new GameSubscriptionType()
                {
                    GameSubscriptionTypeId = 1,
                    GameSubscriptionTypeName = "Daily"
                };

                await gameSubscriptionTypeRepository.CreateItemAsync(gameSubscriptionType);

                gameSubscriptionType = new GameSubscriptionType()
                {
                    GameSubscriptionTypeId = 2,
                    GameSubscriptionTypeName = "1 Month"
                };
                await gameSubscriptionTypeRepository.CreateItemAsync(gameSubscriptionType);

                gameSubscriptionType = new GameSubscriptionType()
                {
                    GameSubscriptionTypeId = 3,
                    GameSubscriptionTypeName = "3 Month"
                };
                await gameSubscriptionTypeRepository.CreateItemAsync(gameSubscriptionType);

                gameSubscriptionType = new GameSubscriptionType()
                {
                    GameSubscriptionTypeId = 4,
                    GameSubscriptionTypeName = "1 Year"
                };
                await gameSubscriptionTypeRepository.CreateItemAsync(gameSubscriptionType);

                GameMode gameMode = new GameMode()
                {
                    GameModeId = 1,
                    GameModeName = "Timer countdown"
                };
                await gameModeRepository.CreateItemAsync(gameMode);

                gameMode = new GameMode()
                {
                    GameModeId = 2,
                    GameModeName = "Points countdown"
                };
                await gameModeRepository.CreateItemAsync(gameMode);

                gameMode = new GameMode()
                {
                    GameModeId = 3,
                    GameModeName = "Round based"
                };
                await gameModeRepository.CreateItemAsync(gameMode);
            }
            catch(Exception)
            {

            }
            
        }

    }
}
