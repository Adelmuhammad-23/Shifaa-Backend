using Microsoft.AspNetCore.SignalR;

namespace ShifaaAPI.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message , int senderId, int receiverId, string senderType, string receiverType)
        {
            // broadcast the message to the receiver
            await Clients.User(receiverId.ToString()).SendAsync("Receive Message", message, senderId, senderType, receiverType);
        }
    }
}
