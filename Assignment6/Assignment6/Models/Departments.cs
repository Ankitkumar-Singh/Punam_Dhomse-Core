using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment6.Models
{
    public partial class Departments
    {
        #region "Department model"
        public Departments()
        {
            Employee = new HashSet<Employee>();
        }

        public short Id { get; set; }

        [Required(ErrorMessage ="Department can not be empty.")]
        public string Department { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
        #endregion
    }
}
