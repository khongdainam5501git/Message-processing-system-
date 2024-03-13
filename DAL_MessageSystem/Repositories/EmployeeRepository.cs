using DAL_MessageSystem.Context;
using DAL_MessageSystem.Entity.Employees;
using DAL_MessageSystem.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DAL_MessageSystem.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        protected MessageSystemContext Db { get; set; }
        protected DbSet<Employee> table;

        public EmployeeRepository()
        {
            Db = new MessageSystemContext();
            table = Db.Set<Employee>();
        }
        public EmployeeRepository(MessageSystemContext db)
        {
            Db = db;
            table = Db.Set<Employee>();
        }

        public void Add(Employee entity)
        {
            table.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id)
        {
            Employee? temp = table.Find(id);
            if (temp != null)
            {
                table.Remove(temp);
                Db.SaveChanges();
            }
        }

        public List<Employee> GetAll()
        {
            return table.ToList();
        }

        public Employee? GetById(int id)
        {
            return table.Find(id);
        }

        public void Save()
        {
            Db.SaveChanges();
        }

        public void Update(Employee entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            Db.SaveChanges();
        }
    }
}
