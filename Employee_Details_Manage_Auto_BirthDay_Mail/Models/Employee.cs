using System.ComponentModel.DataAnnotations;

namespace Employee_Details_Manage_Auto_BirthDay_Mail.Models
{
    public class Employee
    {
        [Key] 
        public int Emp_ID { get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "BirthDate is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "BirthDate")]
        public DateOnly BirthDate { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{3,}$", ErrorMessage = "Invalid Email Address")]
        public string? Email_ID { get; set; }
    }
}
