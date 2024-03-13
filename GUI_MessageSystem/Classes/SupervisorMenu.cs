using BUS_MessageSystem.Interfaces;
using DAL_MessageSystem.Entity;
using DAL_MessageSystem.Entity.Accounts;
using DAL_MessageSystem.Entity.Employees;
using DAL_MessageSystem.Enum;

namespace GUI_MessageSystem.Classes
{
    public class SupervisorMenu : IMenu
    {
        public SupervisorMenu(IReportService reportService, IAccountService accountService, IEmployeeService employeeService, Account account)
        {
            ReportService = reportService;
            AccountService = accountService;
            EmployeeService = employeeService;
            Account = account;
        }

        public IReportService ReportService { get; set; }
        public IAccountService AccountService { get; set; }
        public IEmployeeService EmployeeService { get; set; }
        public Account Account { get; set; }

        public void Show()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1: Create Report");
            Console.WriteLine("2: Open Report");
            Console.WriteLine("3: Get Quantity of report in period");
            Console.WriteLine("4: Add an Employee and his/her account");
            Console.WriteLine("5: Get Report By Date");
            Console.WriteLine("6: Get Quantity Message Of Report");
            Console.WriteLine("7: Exit");
            Console.Write("Enter your choice: ");

            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ReportService.CreateReport(Account);
                    Console.WriteLine("Report is created!");
                    break;
                case "2":
                    Console.Write("Enter Report id: ");
                    string? id = Console.ReadLine();
                    if (id is null)
                        break;
                    ReportService.ShowReport(int.Parse(id));
                    break;
                case "3":
                    Console.WriteLine("Get Quantity Message By Period");
                    Console.Write("Enter begining Date:");
                    string? dateStringStart = Console.ReadLine();
                    Console.Write("Enter ending Date:");
                    string? dateStringEnd = Console.ReadLine();
                    if (dateStringStart is null || dateStringEnd is null)
                        break;
                    var myDateStart = DateTime.Parse(dateStringStart);
                    var myDateEnd = DateTime.Parse(dateStringEnd);
                    Console.WriteLine(ReportService.GetReportInPeriod(myDateStart, myDateEnd).Count);
                    break;
                case "4":
                    Console.WriteLine("Enter the information of subordinate employee to register:");
                    Console.Write("Enter Name:");
                    string? nameEm = Console.ReadLine();
                    Console.Write("Enter login:");
                    string? login = Console.ReadLine();
                    Console.Write("Enter password:");
                    string? pass = Console.ReadLine();
                    if (nameEm is null || login is null || pass is null)
                        break;
                    var accNew = new Account(login, pass, AccountType.Surbodinate);
                    var emNew = new Employee(nameEm, EmployeeType.Subordinate, accNew);
                    AccountService.Add(accNew);
                    EmployeeService.Add(emNew);
                    break;
                case "5":
                    Console.WriteLine("Get Report By Date");
                    Console.Write("Enter Date:");
                    string? dateString = Console.ReadLine();
                    if (dateString is null)
                        break;
                    var myDate = DateTime.Parse(dateString);
                    List<Report> reportList5 = ReportService.GetReportByDate(myDate);
                    reportList5.ForEach(rp => ReportService.ShowReport(rp.Id));
                    break;
                case "6":
                    Console.Write("Enter report id:");
                    string? rpId = Console.ReadLine();
                    if (rpId is null)
                        break;
                    Console.WriteLine(ReportService.GetQuantityMessageOfReport(int.Parse(rpId)));
                    break;
                case "7":
                    break;
                default:
                    Console.WriteLine("Enter again");
                    break;
            }
        }
    }
}
