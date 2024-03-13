using BUS_MessageSystem.Interfaces;
using DAL_MessageSystem.Entity;
using DAL_MessageSystem.Entity.Accounts;
using DAL_MessageSystem.Entity.MessageOutsideStorages;
using DAL_MessageSystem.Entity.SourceMessages;
using DAL_MessageSystem.Enum;

namespace GUI_MessageSystem.Classes
{
    public class SubordinateMenu : IMenu
    {
        public SubordinateMenu(IMessageService messageService, IMessageStorage messageStorage, Account account)
        {
            MessageService = messageService;
            Account = account;
            MessageStorage = messageStorage;
        }

        public IMessageService MessageService { get; set; }
        public Account Account { get; set; }
        public List<Message>? MessagesProcessing { get; set; }
        public IMessageStorage MessageStorage { get; set; }
        public void Show()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1: Receive Messages");
            Console.WriteLine("2: Handle Messages");
            Console.WriteLine("3: Get Quantity Message By Souce");
            Console.WriteLine("4: Get Quantity Message By State");
            Console.WriteLine("5: Get Quantit Message By Date");
            Console.WriteLine("6: Get Quantity Message By Period");
            Console.WriteLine("7: Exit");
            Console.Write("Enter your choice: ");


            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    MessagesProcessing = MessageService.ReceiveMessages(MessageStorage);
                    Console.WriteLine("Received Messages!");
                    break;
                case "2":
                    MessageService.HandleMessageList(MessageService.GetMessageByState(StateMessage.Received), Account);
                    Console.WriteLine("2: Handled Messages!");
                    break;
                case "3":
                    Console.WriteLine("Get Quantity Message By Souce");
                    Console.WriteLine("1: Telephone");
                    Console.WriteLine("2: Email");
                    Console.WriteLine("3: Messenger");
                    string? choice_3 = Console.ReadLine();
                    switch(choice_3) 
                    { 
                        case "1":
                            Console.WriteLine(MessageService.GetQuantityMessageBySouce(new Telephone()));
                            break;
                        case "2":
                            Console.WriteLine(MessageService.GetQuantityMessageBySouce(new Email()));
                            break;
                        case "3":
                            Console.WriteLine(MessageService.GetQuantityMessageBySouce(new Mesenger()));
                            break;
                    }
                    break;
                case "4":
                    Console.WriteLine("Get Quantity Message By State");
                    Console.WriteLine("1: New");
                    Console.WriteLine("2: Received");
                    Console.WriteLine("3: Processed");
                    string? choice_4 = Console.ReadLine();
                    switch (choice_4)
                    {
                        case "1":
                            Console.WriteLine(MessageService.GetQuantityMessageByState(StateMessage.New));
                            break;
                        case "2":
                            Console.WriteLine(MessageService.GetQuantityMessageByState(StateMessage.Received));
                            break;
                        case "3":
                            Console.WriteLine(MessageService.GetQuantityMessageByState(StateMessage.Processed));
                            break;
                    }
                    break;
                case "5":
                    Console.WriteLine("Get Quantity Message By Date");
                    Console.Write("Enter Date:");
                    string? dateString = Console.ReadLine();
                    if (dateString is null)
                        break;
                    var myDate = DateTime.Parse(dateString);
                    Console.WriteLine(MessageService.GetQuantityMessageByDate(myDate));
                    break;
                case "6":
                    Console.WriteLine("Get Quantity Message By Period");
                    Console.Write("Enter begining Date:");
                    string? dateStringStart = Console.ReadLine();
                    Console.Write("Enter ending Date:");
                    string? dateStringEnd = Console.ReadLine();
                    if (dateStringStart is null || dateStringEnd is null)
                        break;
                    var myDateStart = DateTime.Parse(dateStringStart);
                    var myDateEnd = DateTime.Parse(dateStringEnd);
                    Console.WriteLine(MessageService.GetQuantityMessageByPeriod(myDateStart, myDateEnd));
                    break;
                case "7":
                    break;
                default:
                    Console.WriteLine("Enter again");
                    break;
            }
        }
    }
}
