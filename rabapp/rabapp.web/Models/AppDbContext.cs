using rabapp.Helpers;
using rabapp.web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace rabapp.Models
{
    public class AppDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ContactJobTiteRatingStaffingRate>()
            //        .Map(e => e.ToTable("ContactJobTiteRatingStaffingRate"));
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }

        public System.Data.Entity.DbSet<rabapp.web.Models.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.Branch> Branches { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.Shift> Shifts { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.LeaveType> LeaveTypes { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.GenderType> GenderTypes { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.LoanType> LoanTypes { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.LeaveStep> LeaveSteps { get; set; }

        public System.Data.Entity.DbSet<rabapp.Models.Role> Roles { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.LeaveOpenBalance> LeaveOpenBalances { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.EmployeeJobType> EmployeeJobTypes { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.Department> Departments { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.AssignDepartment> AssignDepartments { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.Section> Sections { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.AssignSection> AssignSections { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.Designation> Designations { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.AssignDesignation> AssignDesignations { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.Holiday> Holidays { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.WeekDay> WeekDays { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.WeekEndType> WeekEndTypes { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.WeekEnd> WeekEnds { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.JobDuration> JobDurations { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.SalaryGrade> SalaryGrades { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.LoanStep> LoanSteps { get; set; }

        public System.Data.Entity.DbSet<rabapp.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<rabapp.Models.UserRole> UserRoles { get; set; }
    }

    #region Initial data

    // Change the base class as follows if you want to drop and create the database during development:
    //public class DbInitializer : DropCreateDatabaseAlways<AppDbContext>
    //public class DbInitializer : CreateDatabaseIfNotExists<AppDbContext>
    public class DbInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        private static void CreateUserWithRole(string username, string password, string email, int roleId, AppDbContext context)
        {
            var user = new User { UserName = username, Password = password, Email = email, IsApproved = true, LastLoginDate = DateTime.UtcNow, LastActivityDate = DateTime.UtcNow, LastPasswordChangeDate = DateTime.UtcNow };
            context.Users.Add(user);
            context.SaveChanges();

            // Add the role.
            var existUser = context.Users.Find(user.UserId);
            var existRole = context.Roles.Find(roleId);

            var userRole = new UserRole { UserId = existUser.UserId, RoleId = existRole.RoleId };
            context.UserRoles.Add(userRole);
            context.SaveChanges();
        }

        protected override void Seed(AppDbContext context)
        {
            // Create default roles.
            var roles = new List<Role>
                            {
                                new Role {RoleName = "Admin"},
                                new Role {RoleName = "Employee"},
                                new Role {RoleName = "User"}
                            };

            roles.ForEach(r => context.Roles.Add(r));
            context.SaveChanges();

            // Create some users.
            CreateUserWithRole("Admin", "@123456", "admin@gmail.com", Convert.ToInt32(AppRoles.Admin), context);
            CreateUserWithRole("Employee", "@123456", "employee@gmail.com", Convert.ToInt32(AppRoles.Employee), context);
            CreateUserWithRole("User", "@123456", "user@gmail.com", Convert.ToInt32(AppRoles.User), context);
            CreateUserWithRole("Rasel", "@123456", "raselahmmed@gmail.com", Convert.ToInt32(AppRoles.User), context);

            // Create Company.
            List<Company> companyList = new List<Company>
                            {
                                new Company {CompanyId = 1, CompanyName = "RAB", Email = "raselahmmed@gmail.com", Address = "Dhaka", MobileNo = "01911-045573", PhoneNo = "01911-045573"},
                            };
            companyList.ForEach(r => context.Companies.Add(r));
            context.SaveChanges();

            // Create Branch.
            List<Branch> branchList = new List<Branch>
                            {
                                new Branch {BranchId = 1, BranchName = "RAB", Email = "raselahmmed@gmail.com", Address = "Dhaka", MobileNo = "01911-045573", PhoneNo = "01911-045573", CompanyId = 1},
                            };
            branchList.ForEach(r => context.Branches.Add(r));
            context.SaveChanges();

            // Create GenderType.
            List<GenderType> genderTypeList = new List<GenderType>
                            {
                                new GenderType {GenderTypeId = 1, GenderTypeName = "Male"},
                                new GenderType {GenderTypeId = 2, GenderTypeName = "Female"}
                            };
            genderTypeList.ForEach(r => context.GenderTypes.Add(r));
            context.SaveChanges();

            // Create Shift.
            List<Shift> shiftList = new List<Shift>
                            {
                                new Shift {ShiftId = 1, ShiftName = "Genaral"},
                                new Shift {ShiftId = 2, ShiftName = "Day"},
                                new Shift {ShiftId = 3, ShiftName = "Night"}
                            };
            shiftList.ForEach(r => context.Shifts.Add(r));
            context.SaveChanges();

            // Create LeaveType.
            List<LeaveType> leaveTypeList = new List<LeaveType>
                            {
                                new LeaveType {LeaveTypeId = 1, LeaveTypeName = "Maternity Leave", LeaveDays = 120, GenderTypeId = 2, LeaveCountWorkDayForOneDayLeave = 1},
                                new LeaveType {LeaveTypeId = 2, LeaveTypeName = "Earned Leave", LeaveDays = 11, GenderTypeId = null, LeaveCountWorkDayForOneDayLeave = 11},
                                new LeaveType {LeaveTypeId = 3, LeaveTypeName = "Casual Leave", LeaveDays = 20, GenderTypeId = null, LeaveCountWorkDayForOneDayLeave = 1}
                            };
            leaveTypeList.ForEach(r => context.LeaveTypes.Add(r));
            context.SaveChanges();

            // Create LoanType.
            List<LoanType> loanTypeList = new List<LoanType>
                            {
                                new LoanType {LoanTypeId = 1, LoanTypeName = "HBL"},
                                new LoanType {LoanTypeId = 2, LoanTypeName = "M/Car"},
                                new LoanType {LoanTypeId = 3, LoanTypeName = "GPF"}
                            };
            loanTypeList.ForEach(r => context.LoanTypes.Add(r));
            context.SaveChanges();

            // Create EmployeeJobType.
            List<EmployeeJobType> employeeJobTypeList = new List<EmployeeJobType>
                            {
                                new EmployeeJobType {EmployeeJobTypeId = 1, EmployeeJobTypeName = "Probationary"},
                                new EmployeeJobType {EmployeeJobTypeId = 2, EmployeeJobTypeName = "Internship"},
                                new EmployeeJobType {EmployeeJobTypeId = 3, EmployeeJobTypeName = "Master Roll"},
                                new EmployeeJobType {EmployeeJobTypeId = 4, EmployeeJobTypeName = "Deputed"},
                                new EmployeeJobType {EmployeeJobTypeId = 5, EmployeeJobTypeName = "Contractual"},
                                new EmployeeJobType {EmployeeJobTypeId = 6, EmployeeJobTypeName = "Permanent"},
                                new EmployeeJobType {EmployeeJobTypeId = 7, EmployeeJobTypeName = "Daily Basis"},
                                new EmployeeJobType {EmployeeJobTypeId = 8, EmployeeJobTypeName = "Others"}
                            };
            employeeJobTypeList.ForEach(r => context.EmployeeJobTypes.Add(r));
            context.SaveChanges();

            // Create JobDuration.
            List<JobDuration> jobDurationList = new List<JobDuration>
                            {
                                new JobDuration {JobDurationId = 1, JobDurationName = "Genaral", JobDurationYear = 58}
                            };
            jobDurationList.ForEach(r => context.JobDurations.Add(r));
            context.SaveChanges();
        }
    }

    #endregion
}