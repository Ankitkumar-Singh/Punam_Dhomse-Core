using System.ComponentModel.DataAnnotations;

namespace Assignment6.Models
{
    public partial class Employee
    {
        #region "Employee model"
        public short Id { get; set; }

        [Required(ErrorMessage = "First name cannot be empty.")]
        [RegularExpression("^([a-zA-Z\\s]{2,50})$", ErrorMessage = "Name contains only alphabets(max size 50 character).")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name cannot be empty.")]
        [RegularExpression("^([a-zA-Z\\s]{2,50})$", ErrorMessage = "Name contains only alphabets(max size 50 character).")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email cannot be empty")]
        [RegularExpression(@"^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$", ErrorMessage = "Email address should be in the format abc@test.com")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Deprtment cannot be empty")]
        [Display(Name ="Department Name")]
        public short DepartmentId { get; set; }

        public virtual Departments Department { get; set; }
        #endregion
    }
}
