using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace lab.SecurityApp.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            this.CreatedDate = DateTime.Now;
            this.UpdatedDate = DateTime.Now;
            this.DeletedDate = DateTime.Now;
            this.IsDelete = false;
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

        #endregion

    }

    public class BaseNotMapModel
    {
        public BaseNotMapModel()
        {
            this.CreatedDate = DateTime.Now;
            this.UpdatedDate = DateTime.Now;
            this.DeletedDate = DateTime.Now;
            this.IsDelete = false;
        }

        //public int Id { get; set; }
        [NotMapped]
        public int CreatedBy { get; set; }
        [NotMapped]
        public DateTime CreatedDate { get; set; }
        [NotMapped]
        public int UpdatedBy { get; set; }
        [NotMapped]
        public DateTime UpdatedDate { get; set; }
        [NotMapped]
        public bool IsDelete { get; set; }
        [NotMapped]
        public int DeletedBy { get; set; }
        [NotMapped]
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

        #endregion

    }
}
