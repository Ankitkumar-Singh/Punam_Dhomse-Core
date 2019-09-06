using Assignment6.Interfaces;
using Assignment6.Models;
using Assignment6.MyDbContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Assignment6.Repositories
{
    public class EmployeeRepoitory : IEmployeeRepository
    {
        #region "Private variables"
        private AppDBContext context;
        #endregion

        #region "Constructor"
        /// <summary>Initializes a new instance of the <see cref="EmployeeRepoitory"/> class.</summary>
        /// <param name="context">The context.</param>
        public EmployeeRepoitory(AppDBContext context) => this.context = context;
        #endregion

        #region "GetEmployees"
        /// <summary>Gets the employees list.</summary>
        public IEnumerable<Employee> GetEmployees() => context.Employee.Include(e=>e.Department);
        #endregion

        #region "GetEmployee"
        /// <summary>Get the  single employee.</summary>
        /// <param name="id">The identifier.</param>
        public Employee GetEmployee(int? id) => this.context.Employee.Include(e => e.Department).SingleOrDefault(x => x.Id == id);
        #endregion

        #region "Save"
        /// <summary>Saves the specified employee according to condition.</summary>
        /// <param name="employee">The employee.</param>
        public Employee SaveEmployee(Employee employee)
        {
            if (employee != null)
            {
                //Add employee if not exists.
                if (employee.Id == 0)
                    context.Employee.Add(employee);

                //Update employee if already exits.
                else
                {
                    Employee emp = context.Employee.Where(e => e.Id == employee.Id)?.SingleOrDefault();
                    emp.FirstName = employee.FirstName;
                    emp.LastName = employee.LastName;
                    emp.Email = employee.Email;
                    emp.DepartmentId = employee.DepartmentId;
                }
                context.SaveChanges();
            }
            return employee;
        }
        #endregion

        #region "Delete"
        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        public Employee Delete(int id)
        {
            Employee employee = context.Employee.Include(e => e.Department)?.SingleOrDefault(e => e.Id == id);

            if (employee != null)
            {
                context.Employee.Remove(employee);
                context.SaveChanges();
            } 
            return employee;
        }
        #endregion
    }
}
