using MVCUsingAspDotnetCore.Models;
using System.Collections.Generic;

namespace MVCUsingAspDotnetCore.RepositoryInterfaces
{
    public interface IEmpoyeeRepository
    {
        #region "Methods"
        /// <summary>Gets the employee.</summary>
        /// <param name="Id">The identifier.</param>
        Employee GetEmployee(int? Id);

        /// <summary>Gets the employees.</summary>
        IEnumerable<Employee> GetEmployees();

        /// <summary>Saves the specified employee.</summary>
        /// <param name="employee">The employee.</param>
        Employee SaveEmployee(Employee employee);

        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        Employee Delete(int id);
        #endregion
    }
}
