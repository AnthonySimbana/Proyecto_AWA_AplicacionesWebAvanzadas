namespace MicroServiceWCFChat.Models
{
    public class Chat
    {
        public int ID_CHAT { get; set; }
        public string ID_USER { get; set; }
        public DateTime DATETIME { get; set; }
        public string MESSAGE { get; set; }
    }
}
