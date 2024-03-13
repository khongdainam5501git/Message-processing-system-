using BUS_MessageSystem.Services;
using DAL_MessageSystem.Context;
using DAL_MessageSystem.Entity;
using DAL_MessageSystem.Entity.Accounts;
using DAL_MessageSystem.Entity.MessageOutsideStorages;
using DAL_MessageSystem.Entity.SourceMessages;
using DAL_MessageSystem.Enum;
using DAL_MessageSystem.Repositories;
using DAL_MessageSystem.UnitOfWork;

namespace GUI_MessageSystem.Classes
{
    public class SystemProcessingMessage
    {
        public static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            var messageSystemContext = new MessageSystemContext();
            var messageRepository = new MessageRepository(messageSystemContext);
            var reportRepository = new ReportRepository(messageSystemContext);
            var accountRepository = new AccountRepository(messageSystemContext);
            var employeeRepository = new EmployeeRepository(messageSystemContext);

            var unitOfWork = new UnitOfWork(messageRepository, accountRepository, employeeRepository, reportRepository);

            var messageService = new MessageService(unitOfWork);
            var reportService = new ReportService(unitOfWork);
            var accountService = new AccountService(unitOfWork);
            var employeeService = new EmployeeService(unitOfWork);

            var messageOutsideStorage = new MessageOutsideStorage();

            //Prepare data
            var acc = new Account("login1", "pass", AccountType.Supervisor);
            var acc2 = new Account("login2", "pass", AccountType.Surbodinate);

            var telephone = new Telephone();
            var email = new Email();
            var mess1 = new Message("mesees3", "abcdd");
            var mess2 = new Message("asfdawqesdf", "abcdd");
            accountService.Add(acc);
            accountService.Add(acc2);
            telephone.SendMessage(mess1, messageOutsideStorage);
            email.SendMessage(mess2, messageOutsideStorage);


            //Run 
            var login = new Login(accountService);
            Account? account = login.Dologin();
            while (account is null)
            {
                Console.Clear();
                Console.WriteLine("Please enter again!");
                account = login.Dologin();
            }

            var subordinateMenu = new SubordinateMenu(messageService, messageOutsideStorage, account);
            var supervisorMenu = new SupervisorMenu(reportService, accountService, employeeService, account);
            Console.Clear();
            while(true)
            {
                System.Threading.Thread.Sleep(3000);
                Console.Clear();
                switch (account.AccountType)
                {
                    case AccountType.Supervisor:
                        supervisorMenu.Show();
                        break;
                    case AccountType.Surbodinate:
                        subordinateMenu.Show();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
