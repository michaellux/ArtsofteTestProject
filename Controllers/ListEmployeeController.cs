using ArtsofteTestProject.Models;
using ArtsofteTestProject.Services;
using ArtsofteTestProject.ViewModels;
using ItpdevelopmentTestProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace ArtsofteTestProject.Controllers
{
    public class ListEmployeeController : Controller
    {
        private readonly IEmployeeData _employeeData;

        public ListEmployeeController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("add")]
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.departmentList = _employeeData.GetAllDepartments();
            ViewBag.programmingLanguageList = _employeeData.GetAllProgrammingLanguages();
            return View();
        }

        [Route("add")]
        [HttpPost]
        public IActionResult Add(AddEmployeePageViewModel model)
        {
            var employee = new Employee();
            employee.Id = Guid.NewGuid();
            employee.Name = model.Employee.Name;
            employee.Surname = model.Employee.Surname;
            employee.Age = model.Employee.Age;
            employee.Gender = model.Employee.Gender;
            _employeeData.AddEmployee(employee);

            var employeePlace = new EmployeePlace();
            employeePlace.Id = Guid.NewGuid();
            employeePlace.EmployeeId = employee.Id;
            employeePlace.DepartmentId = model.Department.Id;
            employeePlace.ProgrammingLanguageId = model.ProgrammingLanguage.Id;
            _employeeData.AddEmployeePlace(employeePlace);

            return View();

        }

        [Route("edit")]
        public IActionResult Edit()
        {
            return Content("Edit");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}