using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.SecurityApp.Models
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
            DeletedDate = DateTime.Now;
            IsDelete = false;
        }

        //public int Id { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool IsDelete { get; set; }

        public int DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }

        #region NotMapped

        [NotMapped]
        public virtual string ActionLink { get; set; }
        [NotMapped]
        public virtual bool HasCreate { get; set; }
        [NotMapped]
        public virtual bool HasUpdate { get; set; }
        [NotMapped]
        public virtual bool HasDelete { get; set; }
        [NotMapped]
        public virtual string MessageType { get; set; }
        [NotMapped]
        public virtual string Message { get; set; }
        [NotMapped]
        public virtual int TotalRecord { get; set; }

        #endregion
    }
}
