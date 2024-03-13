using DAL_MessageSystem.Entity.Accounts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_MessageSystem.Entity
{
    [Table("Reports")]
    public class Report
    {
        public Report() { }
        public Report(List<Message> messages, Account accountCreated)
        {
            TimeCreation = DateTime.Today;
            MessagesList = messages;
            AccountCreated = accountCreated;
        }

        [Key]
        public int Id { get; set; }
        public virtual List<Message>? MessagesList { get; set; }
        public Account? AccountCreated { get; set; }
        public DateTime? TimeCreation { get; set; }
    }
}
