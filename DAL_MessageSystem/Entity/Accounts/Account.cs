using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DAL_MessageSystem.Enum;

namespace DAL_MessageSystem.Entity.Accounts
{
    [Table("Accounts")]
    public class Account
    {
        public Account() { }
        public Account(string login, string password, AccountType accountType)
        {
            Login = login;
            Password = password;
            AccountType = accountType;
        }

        [Key]
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public AccountType AccountType { get; set; }
    }
}
