using DAL_MessageSystem.Context;
using DAL_MessageSystem.Entity;
using DAL_MessageSystem.Enum;
using DAL_MessageSystem.Interfaces;
using DAL_MessageSystem.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DAL_MessageSystem.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        protected MessageSystemContext Db { get; set; }
        protected DbSet<Message> table;

        public MessageRepository()
        {
            Db = new MessageSystemContext();
            table = Db.Set<Message>();
        }
        public MessageRepository(MessageSystemContext db)
        {
            Db = db;
            table = Db.Set<Message>();
        }

        public void Add(Message entity)
        {
            table.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id)
        {
            Message? temp = table.Find(id);
            if (temp != null)
            {
                table.Remove(temp);
                Db.SaveChanges();
            }
        }

        public Message? GetById(int id)
        {
            return Db.Messages
                   .FirstOrDefault<Message>(mess => mess.Id == id);
        }

        public List<Message> GetAll()
        {
            return table.ToList();
        }

        public void Save()
        {
            Db.SaveChanges();
        }

        public void Update(Message entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public List<Message> GetMessagesBySource(ISourceMessage sourceMessage)
        {
            return Db.Messages.Where(mes => mes.SourceMessage == sourceMessage.SourceMessageName).ToList();
        }

        public List<Message> GetMessageByState(StateMessage stateMessage)
        {
            return Db.Messages.Where(mes => mes.State == stateMessage).ToList();
        }

        public int GetQuantityMessageByDate(DateTime dateTime)
        {
            return Db.Messages.Where(mes => mes.TimeCreated == dateTime).ToList().Count;
        }

        public int GetQuantityMessageByPeriod(DateTime dateTimeBegin, DateTime dateTimeEnd)
        {
            return Db.Messages.Where(mes => (mes.TimeCreated >= dateTimeBegin) && (mes.TimeCreated <= dateTimeEnd)).ToList().Count;
        }

        public List<Message> GetMessageByDate(DateTime dateTime)
        {
            return Db.Messages.Where(mes => mes.TimeCreated == dateTime).ToList();
        }

        public List<Message> GetMessagePeriod(DateTime dateTimeBegin, DateTime dateTimeEnd)
        {
            return Db.Messages.Where(mes => (mes.TimeCreated >= dateTimeBegin) && (mes.TimeCreated <= dateTimeEnd)).ToList();
        }
    }
}
