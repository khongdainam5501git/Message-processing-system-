using BUS_MessageSystem.Interfaces;
using DAL_MessageSystem.Entity.Employees;
using DAL_MessageSystem.UnitOfWork;

namespace BUS_MessageSystem.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _database;

        public EmployeeService(IUnitOfWork database)
        {
            _database = database;
        }

        public void Add(Employee entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            _database.EmployeeRepository.Add(entity);
            _database.EmployeeRepository.Save();
        }

        public void Delete(int id)
        {
            ArgumentNullException.ThrowIfNull(id);
            _database.EmployeeRepository.Delete(id);
            _database.EmployeeRepository.Save();
        }

        public List<Employee> GetAll()
        {
            return _database.EmployeeRepository.GetAll();
        }

        public Employee? GetById(int id)
        {
            ArgumentNullException.ThrowIfNull(id);
            return _database.EmployeeRepository.GetById(id);
        }

        public void Save()
        {
            _database.EmployeeRepository.Save();
        }

        public void Update(Employee entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            _database.EmployeeRepository.Update(entity);
            _database.EmployeeRepository.Save();
        }
    }
}
