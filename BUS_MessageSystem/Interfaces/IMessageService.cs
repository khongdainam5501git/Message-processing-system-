using DAL_MessageSystem.Entity;
using DAL_MessageSystem.Entity.Accounts;
using DAL_MessageSystem.Entity.MessageOutsideStorages;
using DAL_MessageSystem.Enum;
using DAL_MessageSystem.Interfaces;

namespace BUS_MessageSystem.Interfaces
{
    public interface IMessageService : IService<Message>
    {
        public List<Message> ReceiveMessages(IMessageStorage messageStorage);
        public void ReceiveMessage(Message messages);
        public List<Message> GetMessagesBySource(ISourceMessage sourceMessage);
        public int GetQuantityMessage();
        public int GetQuantityMessageBySouce(ISourceMessage sourceMessage);
        public List<Message> GetMessageByState(StateMessage stateMessage);
        public int GetQuantityMessageByState(StateMessage stateMessage);
        public int GetQuantityMessageByDate(DateTime dateTime);
        public int GetQuantityMessageByPeriod(DateTime dateTimeBegin, DateTime dateTimeEnd);
        public List<Message> GetMessageByDate(DateTime dateTime);
        public List<Message> GetMessagePeriod(DateTime dateTimeBegin, DateTime dateTimeEnd);
        public void HandleMessage(Message message, Account account);
        public void HandleMessageList(List<Message> message, Account account);

    }
}
