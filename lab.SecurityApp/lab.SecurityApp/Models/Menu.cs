using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace lab.SecurityApp.Models
{
    [Table("Menu", Schema = "App")]
    public class Menu //: BaseModel
    {
        [Key]
        public int MenuId { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Menu Name is required")]
        [MaxLength(256)]
        public string MenuName { get; set; }

        [DisplayName("Caption")]
        public string MenuCaption { get; set; }

        [DisplayName("Caption Image")]
        public string MenuCaptionBng { get; set; }

        [DisplayName("Icon")]
        public string MenuIcon { get; set; }

        [DisplayName("Page Url")]
        public string PageUrl { get; set; }

        [DisplayName("Serial No")]
        public int SerialNo { get; set; }

        [DisplayName("Order No: ")]
        public int OrderNo { get; set; }

        [Display(Name = "Area Name")]
        [StringLength(128)]
        public string AreaName { get; set; }

        [Display(Name = "Controller Name")]
        [StringLength(128)]
        public string ControllerName { get; set; }

        [Display(Name = "Action Name")]
        [StringLength(128)]
        public string ActionName { get; set; }

        [DisplayName("Parent Menu: ")]
        //[Required(ErrorMessage = "Please Select Parent Menu.")]
        //[Range(1, long.MaxValue, ErrorMessage = "Please Select Parent Menu.")]
        public int ParentMenuId { get; set; }
        [DisplayName("Parent Menu Name")]
        public string ParentMenuName { get; set; }
        [ForeignKey("ParentMenuId")]
        public virtual Menu ParentMenu { get; set; }

    }
}
