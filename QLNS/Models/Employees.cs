using System;
using System.Collections.Generic;

namespace QLNS.Models
{
    public partial class Employees
    {
        public Employees()
        {
            Blogs = new HashSet<Blogs>();
            ChildComments = new HashSet<ChildComments>();
            Comments = new HashSet<Comments>();
            PositionHistory = new HashSet<PositionHistory>();
            RefreshToken = new HashSet<RefreshToken>();
            RequestApprovals = new HashSet<RequestApprovals>();
            TimeSheets = new HashSet<TimeSheets>();
        }

        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateCreateNewPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string Addresses { get; set; }
        public string Gender { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string AvatarUrl { get; set; }
        public string ProfileUrl { get; set; }
        public bool? Status { get; set; }
        public int? RoleId { get; set; }
        public int DepartmentId { get; set; }
        public int? ShiftWorkId { get; set; }
        //public string BlogsFollow { get; set; }
        public int ManagerId { get; set; }

        public virtual Departments Department { get; set; }
        public virtual Roles Role { get; set; }
        public virtual ShiftWorks ShiftWork { get; set; }
        public virtual ICollection<Blogs> Blogs { get; set; }
        public virtual ICollection<ChildComments> ChildComments { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<PositionHistory> PositionHistory { get; set; }
        public virtual ICollection<RefreshToken> RefreshToken { get; set; }
        public virtual ICollection<RequestApprovals> RequestApprovals { get; set; }
        public virtual ICollection<TimeSheets> TimeSheets { get; set; }
    }
}
