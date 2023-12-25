namespace Shopfloor.EventBus.Models.Message
{
    public class ChatMessage
    {
        public string User { get; set; }
        public string Message { get; set; }

        public ChatMessage(string user, string message)
        {
            User = user;
            Message = message;
        }
    }
}
