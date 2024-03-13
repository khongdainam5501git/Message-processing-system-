using BUS_MessageSystem.Interfaces;
using DAL_MessageSystem.Entity;
using DAL_MessageSystem.Entity.Accounts;
using DAL_MessageSystem.Entity.MessageOutsideStorages;
using DAL_MessageSystem.Enum;
using DAL_MessageSystem.Interfaces;
using DAL_MessageSystem.UnitOfWork;

namespace BUS_MessageSystem.Services
{
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork _database;
        
        public MessageService(IUnitOfWork database)
        {
            _database = database;
        }

        public void Add(Message entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            entity.State = StateMessage.Received;
            _database.MessageRepository.Add(entity);
        }

        public void Delete(int id)
        {
            ArgumentNullException.ThrowIfNull(id);
            _database.MessageRepository.Delete(id);
        }

        public Message? GetById(int id)
        {
            ArgumentNullException.ThrowIfNull(id);
            return _database.MessageRepository.GetById(id);
        }

        public List<Message> GetAll()
        {
            return _database.MessageRepository.GetAll();
        }

        public void Save()
        {
            _database.MessageRepository.Save();
        }

        public void Update(Message entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            _database.MessageRepository.Update(entity);
        }

        public List<Message> ReceiveMessages(IMessageStorage messageStorage)
        {
            ArgumentNullException.ThrowIfNull(messageStorage);
            var clonedList = new List<Message>(messageStorage.MessagesStorage);
            clonedList.ForEach(mes =>
            {
                mes.State = StateMessage.Received;
                _database.MessageRepository.Add(mes);
            });
            messageStorage.ClearStorage();
            return clonedList;
        }

        public void ReceiveMessage(Message messages)
        {
            ArgumentNullException.ThrowIfNull(messages);
            _database.MessageRepository.Add(messages);
        }

        public List<Message> GetMessagesBySource(ISourceMessage sourceMessage)
        {
            ArgumentNullException.ThrowIfNull(sourceMessage);
            return _database.MessageRepository.GetMessagesBySource(sourceMessage);
        }

        public int GetQuantityMessage()
        {
            return _database.MessageRepository.GetAll().Count;
        }

        public int GetQuantityMessageBySouce(ISourceMessage sourceMessage)
        {
            ArgumentNullException.ThrowIfNull(sourceMessage);
            return _database.MessageRepository.GetMessagesBySource(sourceMessage).Count;
        }

        public List<Message> GetMessageByState(StateMessage stateMessage)
        {
            ArgumentNullException.ThrowIfNull(stateMessage);
            return _database.MessageRepository.GetMessageByState(stateMessage);
        }

        public int GetQuantityMessageByDate(DateTime dateTime)
        {   
            ArgumentNullException.ThrowIfNull(dateTime);
            return _database.MessageRepository.GetMessageByDate(dateTime).Count;
        }

        public int GetQuantityMessageByPeriod(DateTime dateTimeBegin, DateTime dateTimeEnd)
        {
            ArgumentNullException.ThrowIfNull(dateTimeBegin);
            ArgumentNullException.ThrowIfNull(dateTimeEnd );
            return _database.MessageRepository.GetMessagePeriod(dateTimeBegin, dateTimeEnd).Count;
        }

        public List<Message> GetMessageByDate(DateTime dateTime)
        {
            ArgumentNullException.ThrowIfNull(dateTime);
            return _database.MessageRepository.GetMessageByDate(dateTime);
        }

        public List<Message> GetMessagePeriod(DateTime dateTimeBegin, DateTime dateTimeEnd)
        {
            ArgumentNullException.ThrowIfNull(dateTimeBegin);
            ArgumentNullException.ThrowIfNull(dateTimeEnd);
            return _database.MessageRepository.GetMessagePeriod(dateTimeBegin, dateTimeEnd);
        }

        public void HandleMessage(Message message, Account account)
        {
            ArgumentNullException.ThrowIfNull(message);
            ArgumentNullException.ThrowIfNull(account);
            message.State = StateMessage.Processed;
            //message.AccountProcessed = account;
            _database.MessageRepository.Save();
        }

        public void HandleMessageList(List<Message> message, Account account)
        {
            ArgumentNullException.ThrowIfNull(message);
            ArgumentNullException.ThrowIfNull(account);
            message.ForEach(message => HandleMessage(message, account));
        }

        public int GetQuantityMessageByState(StateMessage stateMessage)
        {
            ArgumentNullException.ThrowIfNull(stateMessage);
            return _database.MessageRepository.GetMessageByState(stateMessage).Count;
        }
    }
}
