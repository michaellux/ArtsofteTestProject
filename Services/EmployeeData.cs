using ArtsofteTestProject.Models;

namespace ArtsofteTestProject.Services
{
    public interface IEmployeeData
    {
        IEnumerable<EmployeePlace> GetAll();
        void Add(EmployeePlace newEmployeePlace);
        void Edit(EmployeePlace employeePlace);
    }

    public class SqlEmployeeData : IEmployeeData
    {
        private readonly ArtsofteTestProjectContext _context;

        public SqlEmployeeData(ArtsofteTestProjectContext context)
        {
            _context = context;
        }

        public void Add(EmployeePlace newEmployeePlace)
        {
            _context.Add(newEmployeePlace);
            _context.SaveChanges();
        }

        public void Edit(EmployeePlace employeePlace)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeePlace> GetAll()
        {
            return _context.EmployeePlace.ToList();
        }
    }
}
