using BUS_MessageSystem.Interfaces;
using DAL_MessageSystem.Entity.Accounts;

namespace GUI_MessageSystem.Classes
{
    public class Login
    {
        public Login(IAccountService accountService)
        {
            AccountService = accountService;
        }

        public IAccountService AccountService { get; set; }
        private string? _login;
        private string? _password;
        private void ShowLoginPage()
        {
            Console.WriteLine("LoginPage:");
            Console.Write("Login: ");
            _login = Console.ReadLine();
            Console.Write("Password: ");
            _password = Console.ReadLine();
        }

        public Account? Dologin()
        {
            ShowLoginPage();
            if (_login is null || _password is null)
                return null;
            else
            {
                Account? acc = AccountService.GetAccountByLoginAndPassword(_login, _password);
                if (acc is not null)
                {
                    Console.WriteLine("Login successful!");
                    return acc;
                }
                else
                    Console.WriteLine("Login Failure!");
                return null;
            }    
        }
    }
}
