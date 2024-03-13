using DAL_MessageSystem.Entity.Accounts;
using DAL_MessageSystem.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_MessageSystem.Entity
{
    [Table("Messages")]
    public class Message
    {
        public Message() { }
        public Message(string title, string content)
        {
            Title = title;
            Content = content;
            State = StateMessage.New;
            TimeCreated = DateTime.Today;
            SourceMessage = "NaN";
        }

        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime? TimeCreated { get; set; }
        public StateMessage? State { get; set; }
        public string? SourceMessage { get; set; }
        public Account? AccountProcessed { get; set; }
    }
}
