using Microsoft.AspNetCore.Mvc;
using MVCUsingAspDotnetCore.Models;
using MVCUsingAspDotnetCore.ViewModels;
using MVCUsingAspDotnetCore.RepositoryInterfaces;

namespace MVCUsingAspDotnetCore.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        #region "Private variables"
        private readonly IEmpoyeeRepository _employeeRepository;
        #endregion

        #region "Constructor" 
        /// <summary>Initializes a new instance of the <see cref="HomeController"/> class.</summary>
        /// <param name="employeeRepository">The employee repository.</param>
        public HomeController(IEmpoyeeRepository employeeRepository) => _employeeRepository = employeeRepository;
        #endregion

        #region "Hello World action"
        /// <summary>This is the Hello World method.</summary>
        [Route("HelloWorld")]
        public string HelloWorld() => "Hello World!";
        #endregion

        #region "Json action"
        /// <summary>Jsons the result method.</summary>
        [Route("JsonResultMethod")]
        public JsonResult JsonResultMethod() => Json(new { Name="Ankit Singh",Department="Development"});
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
        /// Using viewmodel
        [Route("Details")]
        public IActionResult Details(int? id)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel()
            {
                Employee = _employeeRepository.GetEmployee(id),
                Title = "Employee details"
            };

            return View(employeeViewModel);
        }
        #endregion

        #region "Save"
        [HttpGet]
        [Route("Save")]
        public IActionResult Save(int id)
        {
            var emp = _employeeRepository.GetEmployee(id);
            if(emp == null)
                emp = new Employee();
            return View(emp);
        } 

        [Route("Save")]
        [HttpPost]
        public IActionResult Save(Employee employee)
        {
            if(ModelState.IsValid)
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