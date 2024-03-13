using DAL_MessageSystem.Entity;
using DAL_MessageSystem.Entity.MessageOutsideStorages;

namespace DAL_MessageSystem.Interfaces
{
    public interface ISourceMessage {
        public string SourceMessageName { get; }
        public void SendMessage(Message message, IMessageStorage storage);
    }
}
