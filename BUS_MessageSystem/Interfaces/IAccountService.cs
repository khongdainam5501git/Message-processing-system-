using DAL_MessageSystem.Entity.Accounts;

namespace BUS_MessageSystem.Interfaces
{
    public interface IAccountService : IService<Account>
    {
        public bool Login(string login, string password);
        public Account? GetAccountByLoginAndPassword(string login, string password);

    }
}
