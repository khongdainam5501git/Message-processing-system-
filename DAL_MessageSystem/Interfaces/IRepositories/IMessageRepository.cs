using DAL_MessageSystem.Entity;
using DAL_MessageSystem.Enum;

namespace DAL_MessageSystem.Interfaces.IRepositories
{
    public interface IMessageRepository : IRepository<Message>
    {
        public List<Message> GetMessagesBySource(ISourceMessage sourceMessage);
        public List<Message> GetMessageByState(StateMessage stateMessage);
        public List<Message> GetMessageByDate(DateTime dateTime);
        public List<Message> GetMessagePeriod(DateTime dateTimeBegin, DateTime dateTimeEnd);
    }
}
