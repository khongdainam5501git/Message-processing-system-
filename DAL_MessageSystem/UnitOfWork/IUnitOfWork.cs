using DAL_MessageSystem.Interfaces.IRepositories;

namespace DAL_MessageSystem.UnitOfWork
{
    public interface IUnitOfWork
    {
        IMessageRepository MessageRepository { get; set; }
        IAccountRepository AccountRepository { get; set; }
        IEmployeeRepository EmployeeRepository { get; set; }
        IReportRepository ReportRepository { get; set; }
    }
}
