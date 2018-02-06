using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class EmployeeJobInfo
    {
        [Key]
        [Required]
        public int EmployeeJobInfoId { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeInfoId { get; set; }

        [ForeignKey("EmployeeInfoId")]
        public virtual EmployeeInfo EmployeeInfo { get; set; }

        [Display(Name = "Employee Job Type")]
        public int EmployeeJobTypeId { get; set; }

        [ForeignKey("EmployeeJobTypeId")]
        public virtual EmployeeJobType EmployeeJobType { get; set; }

        [Display(Name = "Employee Class")]
        public int EmployeeClassTypeId { get; set; }

        [ForeignKey("EmployeeClassTypeId")]
        public virtual EmployeeClassType EmployeeClassType { get; set; }

        [Display(Name = "Salary Grade")]
        public int SalaryGradeId { get; set; }

        [ForeignKey("SalaryGradeId")]
        public virtual SalaryGrade SalaryGrade { get; set; }

        [Display(Name = "Present Joining Date")]
        public DateTime PresentJoinDate { get; set; }

        [Display(Name = "House Rent")]
        public int HouseRent { get; set; }

        [Display(Name = "Joining Designation")]
        public int JoinDesignationId { get; set; }

        [ForeignKey("DesignationId")]
        public virtual Designation JoinDesignation { get; set; }

        [Display(Name = "Branch")]
        public int BranchId { get; set; }

        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [Display(Name = "Section")]
        public int SectionId { get; set; }

        [ForeignKey("SectionId")]
        public virtual Section Section { get; set; }

        [Display(Name = "Designation")]
        public int DesignationId { get; set; }

        [ForeignKey("DesignationId")]
        public virtual Designation Designation { get; set; }

    }
}