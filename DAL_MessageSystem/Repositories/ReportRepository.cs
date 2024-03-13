using DAL_MessageSystem.Context;
using DAL_MessageSystem.Entity;
using DAL_MessageSystem.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DAL_MessageSystem.Repositories
{
    public class ReportRepository : IReportRepository
    {
        protected MessageSystemContext Db { get; set; }
        protected DbSet<Report> table;

        public ReportRepository()
        {
            Db = new MessageSystemContext();
            table = Db.Set<Report>();
        }
        public ReportRepository(MessageSystemContext db)
        {
            Db = db;
            table = Db.Set<Report>();
        }

        public void Add(Report entity)
        {
            table.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id)
        {
            Report? temp = table.Find(id);
            if (temp != null)
            {
                table.Remove(temp);
                Db.SaveChanges();
            }
        }

        public Report? GetById(int id)
        {
            return Db.Reports
                   .Include("MessagesList")
                   .Include("AccountCreated")
                   .Where(s => s.Id == id)
                   .FirstOrDefault<Report>();
        }

        public List<Report> GetAll()
        {
            return table.ToList();
        }

        public void Update(Report entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public List<Report> GetReportByDate(DateTime dateTime)
        {
            return Db.Reports
                    .Include("MessagesList")
                    .Include("AccountCreated")
                    .Where(mes => mes.TimeCreation == dateTime).ToList();
        }

        public List<Report> GetReportInPeriod(DateTime dateTimestart, DateTime dateTimeEnd)
        {
            return Db.Reports
                    .Include("MessagesList")
                    .Include("AccountCreated")
                    .Where(mes => (mes.TimeCreation >= dateTimestart) && (mes.TimeCreation <= dateTimeEnd)).ToList();
        }

        public void Save()
        {
            Db.SaveChanges();
        }
    }
}
