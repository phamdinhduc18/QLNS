using QLNS.Helpers.CustomValidationAttribute;
using System;
using System.ComponentModel.DataAnnotations;

namespace QLNS.DTOs
{
    public class CreateEmployeeDTO
    {
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Full name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailUnique]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Addresses { get; set; }
        public string ProfileUrl { get; set; }
        //[Required(ErrorMessage = "This field is required")]
        //[Display(Name = "Position")]
        //public string Position { get; set; }
        public int RoleId { get; set; }
        public int? ShiftworkId { get; set; }
        public bool Status { get; set; }
        public int? DepartmentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } = null;
        public int ManagerId { get; set; }

        // public IFormFile Avatar { set; get; }
    }
}