using DAL_MessageSystem.Entity;

namespace DAL_MessageSystem.Interfaces.IRepositories
{
    public interface IReportRepository : IRepository<Report>
    {
        public List<Report> GetReportByDate(DateTime dateTime);
        public List<Report> GetReportInPeriod(DateTime dateTimestart, DateTime dateTimeEnd);
    }
}
