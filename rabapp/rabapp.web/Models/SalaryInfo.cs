using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class SalaryInfo
    {
        [Key]
        [Required]
        public int SalaryInfoId { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeInfoId { get; set; }

        [ForeignKey("EmployeeInfoId")]
        public virtual EmployeeInfo EmployeeInfo { get; set; }

        [Display(Name = "Basic Salary")]
        public double BasicSalary { get; set; }

        [Display(Name = "House Rent")]
        public double HouseRent { get; set; }

        [Display(Name = "Medical Allowance")]
        public double MedicalAllowance { get; set; }

        [Display(Name = "Educational Allowance")]
        public double EducationalAllowance { get; set; }

        [Display(Name = "Transport Allowance")]
        public double TransportAllowance { get; set; }

        [Display(Name = "Tiffin Allowance")]
        public double TiffinAllowance { get; set; }

        [Display(Name = "Mobile Bill Allowance")]
        public double MobileBillAllowance { get; set; }

        [Display(Name = "Extra Duty Allowance")]
        public double ExtraDutyAllowance { get; set; }

        [Display(Name = "Washing Allowance")]
        public double WashingAllowance { get; set; }

        [Display(Name = "Total Salary")]
        public double TotalSalary { get; set; }

        [Display(Name = "Deduction Percent")]
        public double DeductionPercent { get; set; }

        [Display(Name = "Deduction Gas & Electricity")]
        public double DeductionGasElectricity { get; set; }

        [Display(Name = "Deduction Water & Sanitation")]
        public double DeductionWaterSanitation { get; set; }

        [Display(Name = "Deduction Car Rent")]
        public double DeductionCarRent { get; set; }

        [Display(Name = "Income Tax")]
        public double IncomeTax { get; set; }

        [Display(Name = "Group Insurance")]
        public double GroupInsurance { get; set; }

        [Display(Name = "Social Security Organisational Welfare")]
        public double SocialSecurityOrganisationalWelfare { get; set; }

        [Display(Name = "Total Deduction")]
        public double TotalDeduction { get; set; }

        [Display(Name = "Net Salary")]
        public double TotalNetSalary { get; set; }

        [MaxLength(120)]
        [Display(Name = "Bank Name")]
        public string BankName { get; set; }

        [MaxLength(256)]
        [Display(Name = "Bank Address")]
        public string BankAddress { get; set; }

        [MaxLength(120)]
        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; }
    }
}