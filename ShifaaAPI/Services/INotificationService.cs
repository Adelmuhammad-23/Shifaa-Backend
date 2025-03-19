using ShifaaAPI.DTO;
using ShifaaAPI.Models;

namespace ShifaaAPI.Services
{
    public interface INotificationService
    {
        Task<List<NotificationDTO>> GetNotificationsAsync(int receiverId);
    }
}
