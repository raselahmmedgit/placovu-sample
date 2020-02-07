using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace lab.QuizGameApp.Models
{
    public class Base
    {
        public Base()
        {
            CreatedBy = AppConstant.UserId;
            UpdatedBy = AppConstant.UserId;
            DeletedBy = AppConstant.UserId;
            CreatedDate = DateTime.UtcNow;
            UpdatedDate = DateTime.UtcNow;
            DeletedDate = DateTime.UtcNow;
        }
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        public void SetEntityStateInfo(EntityState entityState, string userId)
        {
            if (entityState == EntityState.Added)
            {
                CreatedDate = DateTime.UtcNow;
                CreatedBy = userId;
            }
            else if (entityState == EntityState.Modified)
            {
                UpdatedDate = DateTime.UtcNow;
                UpdatedBy = userId;
            }
            else if (entityState == EntityState.Deleted)
            {
                DeletedDate = DateTime.UtcNow;
                DeletedBy = userId;
            }
        }

    }

    [Table("AspNetUser")]
    public class AspNetUser
    {
        [StringLength(450)]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public int BusinessUnitId { get; set; }
        public string BusinessUnitName { get; set; }
        public int CompanyId { get; set; }
        public bool IsSystemAdmin { get; set; }

    }

    [Table("GameType")]
    public class GameType
    {
        public string Id { get; set; }
        public int GameTypeId { get; set; }
        public string GameTypeName { get; set; }
    }

    [Table("GameMode")]
    public class GameMode
    {
        public string Id { get; set; }
        public int GameModeId { get; set; }
        public string GameModeName { get; set; }
    }

    [Table("Game")]
    public class Game : Base
    {
        public string GameTitle { get; set; }
        public int GameTypeId { get; set; }
        public int GameModeId { get; set; }
        public decimal MonthlyGamePrice { get; set; }
        public decimal YearlyDiscount { get; set; }
    }

    [Table("GameCoupon")]
    public class GameCoupon : Base
    {
        public string CouponTitle { get; set; }
        public decimal PrizeMoney { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }

    [Table("QuizGame")]
    public class QuizGame : Base
    {
        public string ClientProfileId { get; set; }
        public string GameId { get; set; }
        public string MainBoardIntroText { get; set; }
        public string MainBoardFinalText { get; set; }
        public string MobileIntroText { get; set; }
        public string MobileFinalText { get; set; }
        public string WinnerMessage { get; set; }
        public string LoserMessage { get; set; }
        public int PlayerLoginTypeId { get; set; }
    }

    [Table("QuizGameCouponDetail")]
    public class QuizGameCouponDetail
    {
        public string Id { get; set; }
        public string QuizGameId { get; set; }
        public int RewardingPlayerTypeId { get; set; }
        public int RewardDistributionTypeId { get; set; }
        public int NumberOfCouponReward { get; set; }

    }
}