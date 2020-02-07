using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace lab.QuizGameApp.Models
{
    public class AppDbContext : DbContext
    {
        #region Baby Boomers

        public DbSet<AspNetUser> AspNetUsers { get; set; }

        public DbSet<GameType> GameTypes { get; set; }

        public DbSet<GameMode> GameModes { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<GameCoupon> GameCoupons { get; set; }

        public DbSet<QuizGame> QuizGames { get; set; }

        public DbSet<QuizGameCouponDetail> QuizGameCouponDetails { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

    }

    #region Initial data

    // Change the base class as follows if you want to drop and create the database during development:
    //public class DbInitializer : DropCreateDatabaseAlways<AppDbContext>
    //public class DbInitializer : CreateDatabaseIfNotExists<AppDbContext>
    public class DbInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            // Create default GameType.
            var gameTypes = new List<GameType>
                            {
                                new GameType { Id = Guid.NewGuid().ToString(), GameTypeId = 1, GameTypeName = "GameType 1"},
                                new GameType { Id = Guid.NewGuid().ToString(), GameTypeId = 2, GameTypeName = "GameType 2"}
                            };

            gameTypes.ForEach(x => context.GameTypes.Add(x));
            context.SaveChanges();

            // Create default GameMode.
            var gameModes = new List<GameMode>
                            {
                                new GameMode { Id = Guid.NewGuid().ToString(), GameModeId = 1, GameModeName = "GameMode 1"},
                                new GameMode { Id = Guid.NewGuid().ToString(), GameModeId = 2, GameModeName = "GameMode 2"}
                            };

            gameModes.ForEach(x => context.GameModes.Add(x));
            context.SaveChanges();

            // Create default Game.
            var games = new List<Game>
                            {
                                new Game { Id = AppConstant.GameId, GameTypeId = 1, GameModeId = 1, MonthlyGamePrice = new Decimal(50.30), YearlyDiscount = new Decimal(5.20)},
                            };

            games.ForEach(x => context.Games.Add(x));
            context.SaveChanges();

            // Create default QuizGame.
            var quizGames = new List<QuizGame>
                            {
                                new QuizGame { Id = AppConstant.QuizGameId, ClientProfileId = AppConstant.ClientProfileId, MainBoardIntroText = "MainBoardIntroText", MainBoardFinalText = "MainBoardFinalText", MobileIntroText = "MobileIntroText", MobileFinalText = "MobileFinalText", WinnerMessage = "WinnerMessage", LoserMessage = "LoserMessage", PlayerLoginTypeId = 1},
                            };

            quizGames.ForEach(x => context.QuizGames.Add(x));
            context.SaveChanges();
        }
    }

    #endregion
}