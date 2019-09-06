using System.ComponentModel.DataAnnotations;

namespace MVCUsingAspDotnetCore.Models
{
    #region "enum"
    public enum Department
    {
        SALES,
        FINANCE,
        ENGINEERING,
        MARKETING
    }
    #endregion

    #region "Employee model"
    public class Employee
    {
        [Display(Name = "Employee Id")]
        public int Id { get; set; }

        [Required(ErrorMessage ="Name cannot be empty.")]
        [RegularExpression("^([a-zA-Z\\s]{2,50})$", ErrorMessage = "Name contains only alphabets(max size 50 character).")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Gender cannot be empty.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Address cannot be empty.")]
        [RegularExpression("^([0-9a-zA-Z\\s]{2,50})$", ErrorMessage = "Name contains only alphabets and digits (max size 50 character).")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Department cannot be empty.")]
        public Department Department { get; set; }

        [Required]
        public bool AcceptsTerms { get; set; }
    }
    #endregion
}
