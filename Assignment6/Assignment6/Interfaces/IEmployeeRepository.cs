using Assignment6.Models;
using System.Collections.Generic;

namespace Assignment6.Interfaces
{
    public interface IEmployeeRepository
    {
        #region "Methods"
        /// <summary>Gets the employees.</summary>
        IEnumerable<Employee> GetEmployees();

        /// <summary>Gets the employee.</summary>
        /// <param name="Id">The identifier.</param>
        Employee GetEmployee(int? Id);

        /// <summary>Saves the employee.</summary>
        /// <param name="employee">The employee.</param>
        Employee SaveEmployee(Employee employee);

        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        Employee Delete(int id);
        #endregion
    }
}
