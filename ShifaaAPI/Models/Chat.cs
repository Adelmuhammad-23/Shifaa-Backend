using ShifaaAPI.Models.Identity;

namespace ShifaaAPI.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public DateTime SendTime { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string SenderType { get; set; }
        public string ReceiverType { get; set; }
        public byte[]? Image { get; set; }



    }
}
