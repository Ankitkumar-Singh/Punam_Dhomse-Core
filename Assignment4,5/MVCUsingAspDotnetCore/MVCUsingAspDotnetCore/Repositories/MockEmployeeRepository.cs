using MVCUsingAspDotnetCore.Models;
using MVCUsingAspDotnetCore.RepositoryInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace MVCUsingAspDotnetCore.Repositories
{
    public class MockEmployeeRepository : IEmpoyeeRepository
    {
        #region "Private variables"
        private readonly List<Employee> _employee;
        #endregion

        #region "Constructor"
        /// <summary>Initializes a new instance of the <see cref="MockEmployeeRepository"/> class.</summary>
        public MockEmployeeRepository()
        {
            _employee = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Punam Dhomse", Department = Department.ENGINEERING, Gender="Female", Address="Sinnar" },
                new Employee() { Id = 2, Name = "Prerna Chachare", Department = Department.FINANCE, Gender="Female", Address="Nashik" },
                new Employee() { Id = 3, Name = "Nikhil Patil", Department = Department.MARKETING , Gender="Male", Address="Nashik"}
            };
        }
        #endregion

        #region "GetEmployee"
        /// <summary>Gets the employee.</summary>
        /// <param name="id">The identifier.</param>
        public Employee GetEmployee(int? id) => this._employee.FirstOrDefault(x => x.Id == id);
        #endregion

        #region "GetEmployees"
        /// <summary>Gets the list of employees.</summary>
        public IEnumerable<Employee> GetEmployees() => _employee;
        #endregion

        #region "Delete"
        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        public Employee Delete(int id)
        {
            Employee employee = _employee.Find(e => e.Id == id);

            if (employee != null)
                _employee.Remove(employee);

            return employee;
        }
        #endregion

        #region "Save"
        /// <summary>Saves the specified employee according to condition.</summary>
        /// <param name="employee">The employee.</param>
        public Employee SaveEmployee(Employee employee)
        {
            if (employee != null)
            {
                //Add employee if not exists.
                if(employee.Id == 0)
                {
                    employee.Id = _employee.Max(e => e.Id) + 1;
                    _employee.Add(employee);
                }
                //Update employee if already exits.
                else
                {
                    Employee emp = _employee.FirstOrDefault(e => e.Id == employee.Id);
                    emp.Name = employee.Name;
                    emp.Department = employee.Department;
                    emp.Gender = employee.Gender;
                    emp.Address = employee.Address;
                    emp.AcceptsTerms = employee.AcceptsTerms;
                }
            }
            return employee;
        }
        #endregion
    }
}
