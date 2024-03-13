using DAL_MessageSystem.Entity.MessageOutsideStorages;
using DAL_MessageSystem.Interfaces;

namespace DAL_MessageSystem.Entity.SourceMessages
{
    public class Telephone : ISourceMessage
    {
        public Telephone()
        {
            SourceMessageName = "Telephone";
        }

        public string SourceMessageName { get; }
        public void SendMessage(Message message, IMessageStorage storage)
        {
            message.SourceMessage = SourceMessageName;
            storage.MessagesStorage.Add(message);
        }
    }
}
