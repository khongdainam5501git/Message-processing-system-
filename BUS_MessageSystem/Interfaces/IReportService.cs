using DAL_MessageSystem.Entity;
using DAL_MessageSystem.Entity.Accounts;

namespace BUS_MessageSystem.Interfaces
{
    public interface IReportService : IService<Report>
    {
        public Report CreateReport(Account account);
        public List<Report> GetReportByDate(DateTime dateTime);
        public List<Report> GetReportInPeriod(DateTime dateTimestart, DateTime dateTimeEnd);
        public int GetQuantityMessageOfReport(int id);
        public void ShowReport(int id);
    }
}
