using ArtsofteTestProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace ArtsofteTestProject.Services
{
    public interface IEmployeeData
    {
        IEnumerable<Employee> GetAllEmployee();
        IEnumerable<EmployeePlace> GetAllEmployeePlaces();
        IEnumerable<Department> GetAllDepartments();
        IEnumerable<ProgrammingLanguage> GetAllProgrammingLanguages();
        void EditEmployeePlace(EmployeePlace employeePlace);
        void EditEmployee(Employee employee);
        void AddEmployee(Employee newEmployee);
        void DeleteEmployeePlace(EmployeePlace employeePlace);
        void AddEmployeePlace(EmployeePlace newEmployeePlace);
        EmployeePlace GetEmployeePlace(Guid? id);
        Employee GetEmployee(Guid? id);
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

        public EmployeePlace GetEmployeePlace(Guid? id)
        {
            return _context.EmployeePlace.FirstOrDefault(employeePlace => employeePlace.Id == id);
        }

        public void EditEmployeePlace(EmployeePlace employeePlace)
        {
            _context.EmployeePlace.Update(employeePlace);
            _context.SaveChanges();
        }

        public void EditEmployee(Employee employee)
        {
            _context.Employee.Update(employee);
            _context.SaveChanges();
        }

        public IEnumerable<EmployeePlace> GetAllEmployeePlaces()
        {
            return _context.EmployeePlace
                .Include(employeePlace => employeePlace.Employee)
                .Include(employeePlace => employeePlace.Department)
                .Include(employeePlace => employeePlace.ProgrammingLanguage).ToList();
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _context.Department.ToList();
        }

        public IEnumerable<ProgrammingLanguage> GetAllProgrammingLanguages()
        {
            return _context.ProgrammingLanguage.ToList();
        }

        public Employee GetEmployee(Guid? id)
        {
            return _context.Employee.FirstOrDefault(employee => employee.Id == id);
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _context.Employee.ToList();
        }

        public void DeleteEmployeePlace(EmployeePlace employeePlace)
        {
            _context.EmployeePlace.Remove(employeePlace);
            _context.SaveChanges();
        }
    }
}
