
using DAL_MessageSystem.Entity.Accounts;

namespace DAL_MessageSystem.Interfaces.IRepositories
{
    public interface IAccountRepository : IRepository<Entity.Accounts.Account>
    {
        public bool AuthorizeAccount(string login, string password);
        public Account? GetAccountByLoginAndPassword(string login, string password);
    }
}
