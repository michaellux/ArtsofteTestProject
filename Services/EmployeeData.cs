using ArtsofteTestProject.Models;
using System.Collections;

namespace ArtsofteTestProject.Services
{
    public interface IEmployeeData
    {
        IEnumerable<EmployeePlace> GetAllEmployeePlaces();

        IEnumerable<Department> GetAllDepartments();
        IEnumerable<ProgrammingLanguage> GetAllProgrammingLanguages();
        //void Add(EmployeePlace newEmployeePlace);
        void Edit(EmployeePlace employeePlace);
        void AddEmployee(Employee newEmployee);

        void AddEmployeePlace(EmployeePlace newEmployeePlace);
    }

    public class SqlEmployeeData : IEmployeeData
    {
        private readonly ArtsofteTestProjectContext _context;

        public SqlEmployeeData(ArtsofteTestProjectContext context)
        {
            _context = context;
        }

        public void AddEmployee(Employee newEmployee)
        {
            _context.Employee.Add(newEmployee);
            _context.SaveChanges();
        }

        public void AddEmployeePlace(EmployeePlace newEmployeePlace)
        {
            _context.EmployeePlace.Add(newEmployeePlace);
            _context.SaveChanges();
        }

        public void Edit(EmployeePlace employeePlace)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeePlace> GetAllEmployeePlaces()
        {
            return _context.EmployeePlace.ToList();
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _context.Department.ToList();
        }

        public IEnumerable<ProgrammingLanguage> GetAllProgrammingLanguages()
        {
            return _context.ProgrammingLanguage.ToList();
        }
    }
}
