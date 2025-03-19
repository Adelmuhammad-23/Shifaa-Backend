using Microsoft.AspNetCore.SignalR;

namespace ShifaaAPI.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendNotification (string message, int userId)
        {
            await Clients.User(userId.ToString()).SendAsync("ReceiveNotification", message);
        }
    }
}
