using DAL_MessageSystem.Context;
using DAL_MessageSystem.Entity.Accounts;
using DAL_MessageSystem.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DAL_MessageSystem.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        protected MessageSystemContext Db { get; set; }
        protected DbSet<Account> table;

        public AccountRepository()
        {
            Db = new MessageSystemContext();
            table = Db.Set<Account>();
        }
        public AccountRepository(MessageSystemContext db)
        {
            Db = db;
            table = Db.Set<Account>();
        }

        public void Add(Account entity)
        {
            table.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id)
        {
            Account? temp = table.Find(id);
            if (temp != null)
            {
                table.Remove(temp);
                Db.SaveChanges();
            }
        }

        public List<Account> GetAll()
        {
            return table.ToList();
        }

        public Account? GetById(int id)
        {
            return table.Find(id);
        }

        public void Save()
        {
            Db.SaveChanges();
        }

        public void Update(Account entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public bool AuthorizeAccount(string login, string password)
        {
            if (GetAccountByLoginAndPassword(login, password) != null)
                return true;
            else
                return false;
        }

        public Account? GetAccountByLoginAndPassword(string login, string password)
        {
            return Db.Accounts.FirstOrDefault(acc => ((acc.Login == login) && (acc.Password == password)));
        }
    }
}
