namespace DAL_MessageSystem.Entity.MessageOutsideStorages
{
    public interface IMessageStorage
    {
        public List<Message> MessagesStorage { get; set; }
        public void ClearStorage();
    }
}
