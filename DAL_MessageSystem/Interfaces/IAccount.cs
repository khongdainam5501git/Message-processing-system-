namespace DAL_MessageSystem.Interfaces
{
    public interface IAccount
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
