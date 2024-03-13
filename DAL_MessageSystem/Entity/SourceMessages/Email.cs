using DAL_MessageSystem.Entity.MessageOutsideStorages;
using DAL_MessageSystem.Interfaces;

namespace DAL_MessageSystem.Entity.SourceMessages
{
    public class Email : ISourceMessage
    {
        public Email()
        {
            SourceMessageName = "Email";
        }

        public string SourceMessageName { get; }
        public void SendMessage(Message message, IMessageStorage storage)
        {
            message.SourceMessage = SourceMessageName;
            storage.MessagesStorage.Add(message);
        }
    }
}
