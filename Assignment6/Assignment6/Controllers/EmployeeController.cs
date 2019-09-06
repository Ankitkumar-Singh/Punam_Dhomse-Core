using Assignment6.Interfaces;
using Assignment6.Models;
using Assignment6.MyDbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Assignment6.Controllers
{
    [Route("Employee")]
    public class EmployeeController : Controller
    {
        #region "Private variables"
        private AppDBContext _context;
        private IEmployeeRepository _employeeRepository;
        #endregion

        #region "Constructor"
        /// <summary>Initializes a new instance of the <see cref="EmployeeController"/> class.</summary>
        /// <param name="employeeRepository">The employee repository.</param>
        /// <param name="context">The context.</param>
        public EmployeeController(IEmployeeRepository employeeRepository, AppDBContext context)
        {
            _context = context;
            _employeeRepository = employeeRepository;
        }
        #endregion

        #region "Index"
        /// <summary>Indexes this instance.</summary>
        [Route("/")]
        [Route("Index")]
        public IActionResult Index() => View(_employeeRepository.GetEmployees());
        #endregion

        #region "Details"
        /// <summary>Detailses the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        [Route("Details")]
        public IActionResult Details(int id) => View(_employeeRepository.GetEmployee(id));
        #endregion

        #region "Save"
        /// <summary>Saves the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        [HttpGet]
        [Route("Save")]
        public IActionResult Save(int id)
        {
            var emp = _employeeRepository.GetEmployee(id);

            ViewBag.DepartmentId = _context.Department.Select(e => new SelectListItem()
            { 
                Text = e.Department.ToString(),
                Value = e.Id.ToString()
            });

            if (emp == null)
                emp = new Employee();

            return View(emp);
        }

        [Route("Save")]
        [HttpPost]
        public IActionResult Save(Employee employee)
        {
            if (ModelState.IsValid)
                return RedirectToAction("Index", _employeeRepository.SaveEmployee(employee));

            return View();
        }
        #endregion

        #region "Delete"
        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        [HttpGet]
        [Route("Delete")]
        public IActionResult Delete(int id) => View(_employeeRepository.GetEmployee(id)); 

        /// <summary>Deletes the confirm.</summary>
        /// <param name="id">The identifier.</param>
        [HttpPost, ActionName("Delete")]
        [Route("Delete")]
        public RedirectToActionResult DeleteConfirm(int id) => RedirectToAction("Index", _employeeRepository.Delete(id));
        #endregion
    }
}