using DAL_MessageSystem.Interfaces.IRepositories;

namespace DAL_MessageSystem.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IMessageRepository messageRepository,
                          IAccountRepository accountRepository,
                          IEmployeeRepository employeeRepository,
                          IReportRepository reportRepository) {
            MessageRepository = messageRepository;
            AccountRepository = accountRepository;
            EmployeeRepository = employeeRepository;
            ReportRepository = reportRepository;
        }

        public IMessageRepository MessageRepository { get; set; }
        public IAccountRepository AccountRepository { get; set; }
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IReportRepository ReportRepository { get; set; }
    }
}
