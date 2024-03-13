using BUS_MessageSystem.Interfaces;
using DAL_MessageSystem.Entity;
using DAL_MessageSystem.Entity.Accounts;
using DAL_MessageSystem.UnitOfWork;
using System.Diagnostics.CodeAnalysis;

namespace BUS_MessageSystem.Services
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _database;

        public ReportService(IUnitOfWork database)
        {
            _database = database;
        }
        public void Add(Report entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            _database.ReportRepository.Add(entity);
            _database.ReportRepository.Save();
        }

        public Report CreateReport(Account account)
        {
            List<Message> messages = _database.MessageRepository.GetMessageByDate(DateTime.Today);
            var newRp = new Report(messages, account);
            _database.ReportRepository.Add(newRp);
            _database.ReportRepository.Save();
            return newRp;
        }

        public void Delete(int id)
        {
            ArgumentNullException.ThrowIfNull(id);
            _database.ReportRepository.Delete(id);
            _database.ReportRepository.Save();
        }

        public List<Report> GetAll()
        {
            return _database.ReportRepository.GetAll();
        }

        public Report? GetById(int id)
        {   
            ArgumentNullException.ThrowIfNull(id);
            return _database.ReportRepository.GetById(id);
        }

        public int GetQuantityMessageOfReport(int id)
        {
            ArgumentNullException.ThrowIfNull(id);
            Report? rp = _database.ReportRepository.GetById(id);
            if (IsNotNull(rp) && IsNotNull(rp.MessagesList))
                return rp.MessagesList.Count;
            else
                return 0;
        }

        public List<Report> GetReportByDate(DateTime dateTime)
        {
            ArgumentNullException.ThrowIfNull(dateTime);
            return _database.ReportRepository.GetReportByDate(dateTime);
        }

        public List<Report> GetReportInPeriod(DateTime dateTimestart, DateTime dateTimeEnd)
        {
            ArgumentNullException.ThrowIfNull(dateTimestart);
            ArgumentNullException.ThrowIfNull(dateTimeEnd);
            return _database.ReportRepository.GetReportInPeriod(dateTimestart, dateTimeEnd);
        }

        public void Save()
        {
            _database.ReportRepository.Save();
        }

        public void ShowReport(int id)
        {
            ArgumentNullException.ThrowIfNull(id);
            Report? rp = _database.ReportRepository.GetById(id);
            if (!IsNotNull(rp))
            {
                Console.WriteLine("Report with id = " + id + " is not Exist");
                return;
            }

            Console.WriteLine("ID: " + rp.Id);
            Console.WriteLine("Time Creation: " + rp.TimeCreation);
        }

        public void Update(Report entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            _database.ReportRepository.Update(entity);
        }
        private static bool IsNotNull([NotNullWhen(true)] object? obj) => obj != null;
    }
}
