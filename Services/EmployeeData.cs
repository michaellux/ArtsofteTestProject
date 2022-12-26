using ArtsofteTestProject.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        void AddDepartment(Department newDepartment);
        void AddProgrammingLanguage(ProgrammingLanguage programmingLanguage);
    }

    public class SqlEmployeeData : IEmployeeData
    {
        private readonly ArtsofteTestProjectContext _context;

        public SqlEmployeeData(ArtsofteTestProjectContext context)
        {
            _context = context;
        }

        public Employee GetEmployee(Guid? id)
        {
            string storedProcedure = "GetEmployee";
            SqlParameter paramId = new SqlParameter("@p_Id", id);
            var employee = _context.Employee.FromSqlRaw(
                $"{storedProcedure} @p_Id",
                paramId
            ).ToList().FirstOrDefault();
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            string storedProcedure = "GetAllEmployee";
            var employees = _context.Employee.FromSqlRaw(
                $"{storedProcedure}"
            ).ToList();
            return employees;
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
            string storedProcedure = "UpdateEmployee";
            SqlParameter paramId = new SqlParameter("@p_Id", employee.Id);
            SqlParameter paramName = new("@p_Name", employee.Name);
            SqlParameter paramSurname = new("@p_Surname", employee.Surname);
            SqlParameter paramAge = new("@p_Age", employee.Age);
            SqlParameter paramGender = new("@p_Gender", employee.Gender);

            _context.Database.ExecuteSqlRaw(
                $"EXEC {storedProcedure} @p_Id, @p_Name, @p_Surname, @p_Age, @p_Gender",
                paramId, paramName, paramSurname, paramAge, paramGender
            );
        }

        public EmployeePlace GetEmployeePlace(Guid? id)
        {
            string storedProcedure = "GetEmployeePlace";
            SqlParameter paramId = new SqlParameter("@p_Id", id);
            var employeePlace = _context.EmployeePlace.FromSqlRaw(
                $"{storedProcedure} @p_Id",
                paramId
            ).ToList().FirstOrDefault();
            return employeePlace;
        }

        public IEnumerable<EmployeePlace> GetAllEmployeePlaces()
        {
            return _context.EmployeePlace
                .Include(employeePlace => employeePlace.Employee)
                .Include(employeePlace => employeePlace.Department)
                .Include(employeePlace => employeePlace.ProgrammingLanguage).ToList();
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

        public void EditEmployeePlace(EmployeePlace employeePlace)
        {
            string storedProcedure = "UpdateEmployeePlace";
            SqlParameter paramId = new SqlParameter("@p_Id", employeePlace.Id);
            SqlParameter paramEmployeeId = new SqlParameter("@p_EmployeeId", employeePlace.EmployeeId);
            SqlParameter paramDepartmentId = new SqlParameter("@p_DepartmentId", employeePlace.DepartmentId);
            SqlParameter paramProgrammingLanguageId = new SqlParameter("@p_ProgrammingLanguageId", employeePlace.ProgrammingLanguageId);
            _context.Database.ExecuteSqlRaw(
                $"EXEC {storedProcedure} @p_Id, @p_EmployeeId, @p_DepartmentId, @p_ProgrammingLanguageId",
                paramId, paramEmployeeId, paramDepartmentId, paramProgrammingLanguageId
            );
        }

        public void DeleteEmployeePlace(EmployeePlace employeePlace)
        {
            string storedProcedure = "DeleteEmployeePlace";
            SqlParameter paramId = new SqlParameter("@p_Id", employeePlace.Id);
            _context.Database.ExecuteSqlRaw(
                $"EXEC {storedProcedure} @p_Id",
                paramId
            );
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            string storedProcedure = "GetAllDepartments";
            var departments = _context.Department.FromSqlRaw(
                $"{storedProcedure}"
            ).ToList();
            return departments;
        }

        public IEnumerable<ProgrammingLanguage> GetAllProgrammingLanguages()
        {
            string storedProcedure = "GetAllProgrammingLanguages";
            var programmingLanguages = _context.ProgrammingLanguage.FromSqlRaw(
                $"{storedProcedure}"
            ).ToList();
            return programmingLanguages;
        }

        public void AddDepartment(Department newDepartment)
        {
            _context.Department.Add(newDepartment);
            _context.SaveChanges();
        }

        public void AddProgrammingLanguage(ProgrammingLanguage programmingLanguage)
        {
            _context.ProgrammingLanguage.Add(programmingLanguage);
            _context.SaveChanges();
        }
    }
}
