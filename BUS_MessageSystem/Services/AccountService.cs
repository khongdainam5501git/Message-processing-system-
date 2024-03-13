using BUS_MessageSystem.Interfaces;
using DAL_MessageSystem.Entity.Accounts;
using DAL_MessageSystem.UnitOfWork;

namespace BUS_MessageSystem.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _database;

        public AccountService(IUnitOfWork database)
        {
            _database = database;
        }

        public void Add(Account entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            _database.AccountRepository.Add(entity);
        }

        public void Delete(int id)
        {
            ArgumentNullException.ThrowIfNull(id);
            _database.AccountRepository.Delete(id);
        }

        public Account? GetAccountByLoginAndPassword(string login, string password)
        {
            ArgumentNullException.ThrowIfNull(login);
            ArgumentNullException.ThrowIfNull(password);

            return _database.AccountRepository.GetAccountByLoginAndPassword(login, password);
        }

        public List<Account> GetAll()
        {
            return _database.AccountRepository.GetAll();
        }

        public Account? GetById(int id)
        {
            ArgumentNullException.ThrowIfNull(id);
            return _database.AccountRepository.GetById(id);
        }

        public bool Login(string login, string password)
        {
            ArgumentNullException.ThrowIfNull(login, password);
            return _database.AccountRepository.AuthorizeAccount(login, password);
        }

        public void Save()
        {
            _database.AccountRepository.Save();
        }

        public void Update(Account entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            _database.AccountRepository.Update(entity);
        }
    }
}
