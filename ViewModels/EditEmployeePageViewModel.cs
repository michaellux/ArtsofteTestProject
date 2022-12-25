using ArtsofteTestProject.Models;

namespace ArtsofteTestProject.ViewModels
{
    public class EditEmployeePageViewModel
    {
        public Employee Employee { get; set; }
        public EmployeePlace EmployeePlace { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    }
}
