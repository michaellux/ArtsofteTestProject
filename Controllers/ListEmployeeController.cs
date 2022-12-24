using ArtsofteTestProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ArtsofteTestProject.Controllers
{
    public class ListEmployeeController : Controller
    {
        public ListEmployeeController()
        {
            
        }

        public IActionResult Index()
        {
            return Content("List of Employees");
        }

        [Route("add")]
        public IActionResult Add()
        {
            return Content("Add");
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