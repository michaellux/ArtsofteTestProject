using ArtsofteTestProject.Models;
using ArtsofteTestProject.Services;
using ArtsofteTestProject.ViewModels;
using ItpdevelopmentTestProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Reflection;

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
            var model = new ListEmployeePageViewModel
            {
                EmployeePlaces = _employeeData.GetAllEmployeePlaces()
            };
            return View(model);
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
            var form = Request.Form;
            string departmentId = form["Department"]!;
            string programmingLanguageId = form["ProgrammingLanguage"]!;

            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                Name = model.Employee.Name,
                Surname = model.Employee.Surname,
                Age = model.Employee.Age,
                Gender = model.Employee.Gender
            };
            _employeeData.AddEmployee(employee);

            var employeePlace = new EmployeePlace
            {
                Id = Guid.NewGuid(),
                EmployeeId = employee.Id,
                DepartmentId = new Guid(departmentId),
                ProgrammingLanguageId = new Guid(programmingLanguageId)
            };
            _employeeData.AddEmployeePlace(employeePlace);

            return RedirectToAction("Index");
        }

        [Route("edit")]
        [HttpGet]
        public IActionResult Edit(Guid? id)
        {
            if (id != null)
            {
                var model = new EditEmployeePageViewModel
                {
                    EmployeePlace = _employeeData.GetEmployeePlace(id)
                };
                model.Employee = _employeeData.GetEmployee(model.EmployeePlace.EmployeeId);
                model.Departments = _employeeData.GetAllDepartments();
                model.ProgrammingLanguages = _employeeData.GetAllProgrammingLanguages();

                if (model == null)
                {
                    return NotFound($"Employee place with id = {id} not found");
                }

                return View(model);
            }
            return NotFound();
        }

        [Route("edit")]
        [HttpPost]
        public IActionResult Edit(EditEmployeePageViewModel model)
        {
            var employee = _employeeData.GetEmployee(model.Employee.Id);
            employee.Name = model.Employee.Name;
            employee.Surname = model.Employee.Surname;
            employee.Age = model.Employee.Age;
            employee.Gender = model.Employee.Gender;
            _employeeData.EditEmployee(employee);

            var employeePlace = _employeeData.GetEmployeePlace(model.EmployeePlace.Id);
            employeePlace.EmployeeId = employee.Id;
            employeePlace.DepartmentId = model.EmployeePlace.DepartmentId;
            employeePlace.ProgrammingLanguageId = model.EmployeePlace.ProgrammingLanguageId;
            _employeeData.EditEmployeePlace(employeePlace);

            return RedirectToAction("Index");
        }


            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}