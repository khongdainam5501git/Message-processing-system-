namespace DAL_MessageSystem.Entity.MessageOutsideStorages
{
    public class MessageOutsideStorage : IMessageStorage
    {
        public MessageOutsideStorage()
        {
            MessagesStorage = new List<Message>();
        }

        public List<Message> MessagesStorage { get; set; }

        public void ClearStorage()
        {
            MessagesStorage.Clear();
        }
    }
}
