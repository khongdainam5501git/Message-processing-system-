using BUS_MessageSystem.Services;
using DAL_MessageSystem.Context;
using DAL_MessageSystem.Entity;
using DAL_MessageSystem.Entity.Accounts;
using DAL_MessageSystem.Entity.Employees;
using DAL_MessageSystem.Entity.MessageOutsideStorages;
using DAL_MessageSystem.Entity.SourceMessages;
using DAL_MessageSystem.Enum;
using DAL_MessageSystem.Repositories;
using DAL_MessageSystem.UnitOfWork;

namespace MessageProcessingSystem.Test
{
    public class MessageSystemProcessingTest
    {
        public MessageSystemProcessingTest()
        {
        }

        [Fact]
        public void Test_Adding_Getting_Deleting()
        {
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

            var account = new Account("login", "pass", AccountType.Surbodinate);
            var message = new Message("asfdawqesdf", "abcdd");
            var rp = new Report(new List<Message>() { message}, account);
            var employee = new Employee("Vladimir hehe",EmployeeType.Subordinate, account);

            accountService.Add(account);
            messageService.Add(message);
            reportService.Add(rp);
            employeeService.Add(employee);

            Message? messageGot = messageService.GetById(message.Id);
            Account? accountGot = accountService.GetById(account.Id);
            Report? reportGot = reportService.GetById(rp.Id);
            Employee? employeeGot = employeeService.GetById(employee.Id);

            Assert.Equal(message, messageGot);
            Assert.Equal(account, accountGot);
            Assert.Equal(rp, reportGot);
            Assert.Equal(employee, employeeGot);

            int messId = message.Id;
            int accId = account.Id;
            int rpId = rp.Id;
            int emId = employee.Id;

            messageService.Delete(messId);
            accountService.Delete(accId);
            reportService.Delete(rpId);
            employeeService.Delete(emId);

            Assert.Null(messageService.GetById(message.Id));
            Assert.Null(reportService.GetById(rp.Id));
            Assert.Null(accountService.GetById(account.Id));
            Assert.Null(employeeService.GetById(employee.Id));

        }

        [Fact]
        public void Test_SourceMessage()
        {
            var message = new Message("asfdawqesdf", "abcdd");
            var messageOutsideStorage = new MessageOutsideStorage();
            var telephone = new Telephone();
            telephone.SendMessage(message, messageOutsideStorage);
            int size = messageOutsideStorage.MessagesStorage.Count;
            Assert.Equal(1, size);
        }
    }
}