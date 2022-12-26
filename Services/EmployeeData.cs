using ArtsofteTestProject.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Xml.Linq;
using static Azure.Core.HttpHeader;

namespace ArtsofteTestProject.Services
{
    public interface IEmployeeData
    {
        IEnumerable<Employee> GetAllEmployee();
        IEnumerable<EmployeePlace> GetAllEmployeePlaces();
        IEnumerable<Department> GetAllDepartments();
        IEnumerable<ProgrammingLanguage> GetAllProgrammingLanguages();
        void AddEmployee(Employee newEmployee);
        void EditEmployee(Employee employee);
        void AddEmployeePlace(EmployeePlace newEmployeePlace);
        void EditEmployeePlace(EmployeePlace employeePlace);
        void DeleteEmployeePlace(EmployeePlace employeePlace);
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
            string storedProcedure = "InsertEmployee";
            SqlParameter paramId = new SqlParameter("@p_Id", newEmployee.Id);
            SqlParameter paramName = new("@p_Name", newEmployee.Name);
            SqlParameter paramSurname = new("@p_Surname", newEmployee.Surname);
            SqlParameter paramAge = new("@p_Age", newEmployee.Age);
            SqlParameter paramGender = new("@p_Gender", newEmployee.Gender);

            _context.Database.ExecuteSqlRaw(
                $"EXEC {storedProcedure} @p_Id, @p_Name, @p_Surname, @p_Age, @p_Gender",
                paramId, paramName, paramSurname, paramAge, paramGender
            );
        }

        public void EditEmployee(Employee employee)
        {
            _context.Employee.Update(employee);
            _context.SaveChanges();
        }

        public void AddEmployeePlace(EmployeePlace newEmployeePlace)
        {
            string storedProcedure = "InsertEmployeePlace";
            SqlParameter paramId = new SqlParameter("@p_Id", newEmployeePlace.Id);
            SqlParameter paramEmployeeId = new SqlParameter("@p_EmployeeId", newEmployeePlace.EmployeeId);
            SqlParameter paramDepartmentId = new SqlParameter("@p_DepartmentId", newEmployeePlace.DepartmentId);
            SqlParameter paramProgrammingLanguageId = new SqlParameter("@p_ProgrammingLanguageId", newEmployeePlace.ProgrammingLanguageId);
            _context.Database.ExecuteSqlRaw(
                $"EXEC {storedProcedure} @p_Id, @p_EmployeeId, @p_DepartmentId, @p_ProgrammingLanguageId",
                paramId, paramEmployeeId, paramDepartmentId, paramProgrammingLanguageId
            );
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
