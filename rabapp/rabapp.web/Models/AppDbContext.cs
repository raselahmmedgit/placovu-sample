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

        public System.Data.Entity.DbSet<rabapp.web.Models.RosterType> RosterTypes { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.ResidentType> ResidentTypes { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.EmployeeClassType> EmployeeClassTypes { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.BookType> BookTypes { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.FreedomFighterType> FreedomFighterTypes { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.FreedomFighterRelationshipType> FreedomFighterRelationshipTypes { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.Country> Countries { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.EmployeeInfo> EmployeeInfoes { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.BloodGroup> BloodGroups { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.District> Districts { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.BaseDocument> BaseDocuments { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.ReligionType> ReligionTypes { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.EmployeeJobInfo> EmployeeJobInfoes { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.EmployeeFamilyInfo> EmployeeFamilyInfoes { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.EmployeeChildInfo> EmployeeChildInfoes { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.EmployeeAcademicInfo> EmployeeAcademicInfoes { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.EmployeeTrainInfo> EmployeeTrainInfoes { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.EmployeeAwardHonorInfo> EmployeeAwardHonorInfoes { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.EmployeeResearchPublicationInfo> EmployeeResearchPublicationInfoes { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.EmployeeCurriculamActivitieInfo> EmployeeCurriculamActivitieInfoes { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.EmployeeContactInfo> EmployeeContactInfoes { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.EmployeeReferenceInfo> EmployeeReferenceInfoes { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.EmployeeNomineeInfo> EmployeeNomineeInfoes { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.EmployeeGovtServiceInfo> EmployeeGovtServiceInfoes { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.EmployeeOtherServiceInfo> EmployeeOtherServiceInfoes { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.EmployeeForeignTravelInfo> EmployeeForeignTravelInfoes { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.EmployeeTransferInfo> EmployeeTransferInfoes { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.EmployeeDisciplinaryActionCriminalProsecutionInfo> EmployeeDisciplinaryActionCriminalProsecutionInfoes { get; set; }

        public System.Data.Entity.DbSet<rabapp.web.Models.EmployeeSuspendedInfo> EmployeeSuspendedInfoes { get; set; }
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

            // Create EmployeeClassType.
            List<EmployeeClassType> employeeClassTypeList = new List<EmployeeClassType>
                            {
                                new EmployeeClassType {EmployeeClassTypeId = 1, EmployeeClassTypeName = "1st Class"},
                                new EmployeeClassType {EmployeeClassTypeId = 2, EmployeeClassTypeName = "2nd Class"},
                                new EmployeeClassType {EmployeeClassTypeId = 3, EmployeeClassTypeName = "3rd Class"},
                                new EmployeeClassType {EmployeeClassTypeId = 4, EmployeeClassTypeName = "4th Class"}
                            };
            employeeClassTypeList.ForEach(r => context.EmployeeClassTypes.Add(r));
            context.SaveChanges();

            // Create BookType.
            List<BookType> bookTypeList = new List<BookType>
                            {
                                new BookType {BookTypeId = 1, BookTypeName = "National"},
                                new BookType {BookTypeId = 2, BookTypeName = "International"}
                            };
            bookTypeList.ForEach(r => context.BookTypes.Add(r));
            context.SaveChanges();

            // Create ResidentType.
            List<ResidentType> residentTypeList = new List<ResidentType>
                            {
                                new ResidentType {ResidentTypeId = 1, ResidentTypeName = "Rented"},
                                new ResidentType {ResidentTypeId = 2, ResidentTypeName = "Owner"}
                            };
            residentTypeList.ForEach(r => context.ResidentTypes.Add(r));
            context.SaveChanges();

            // Create RosterType.
            List<RosterType> rosterTypeList = new List<RosterType>
                            {
                                new RosterType {RosterTypeId = 1, RosterTypeName = "Genaral"}
                            };
            rosterTypeList.ForEach(r => context.RosterTypes.Add(r));
            context.SaveChanges();

            // Create FreedomFighterType.
            List<FreedomFighterType> freedomFighterTypeList = new List<FreedomFighterType>
                            {
                                new FreedomFighterType {FreedomFighterTypeId = 1, FreedomFighterTypeName = "Yes"},
                                new FreedomFighterType {FreedomFighterTypeId = 2, FreedomFighterTypeName = "No"}
                            };
            freedomFighterTypeList.ForEach(r => context.FreedomFighterTypes.Add(r));
            context.SaveChanges();

            // Create FreedomFighterRelationshipType.
            List<FreedomFighterRelationshipType> freedomFighterRelationshipTypeList = new List<FreedomFighterRelationshipType>
                            {
                                new FreedomFighterRelationshipType {FreedomFighterRelationshipTypeId = 1, FreedomFighterRelationshipTypeName = "Self"},
                                new FreedomFighterRelationshipType {FreedomFighterRelationshipTypeId = 2, FreedomFighterRelationshipTypeName = "Son"},
                                new FreedomFighterRelationshipType {FreedomFighterRelationshipTypeId = 3, FreedomFighterRelationshipTypeName = "Daughter"},
                                new FreedomFighterRelationshipType {FreedomFighterRelationshipTypeId = 4, FreedomFighterRelationshipTypeName = "Grand Child"}
                            };
            freedomFighterRelationshipTypeList.ForEach(r => context.FreedomFighterRelationshipTypes.Add(r));
            context.SaveChanges();
        }
    }

    #endregion
}