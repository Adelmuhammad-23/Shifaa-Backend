using AutoMapper;
using MediatR;
using ShifaaAPI.DbContext;
using ShifaaAPI.DTO;
using ShifaaAPI.Hubs;
using ShifaaAPI.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ShifaaAPI.ServicesImplementation
{
    public class NotificationService(ApplicationDbContext dbContext) : INotificationService
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task<List<NotificationDTO>> GetNotificationsAsync(int receiverId)
        {
            var notifications = await _dbContext.Notifications
                .Where(n => n.ReceiverId == receiverId)
                .OrderByDescending(n => n.Date)
                .Select(n => new NotificationDTO
                {
                    Date = n.Date,
                    Message = n.Message // string 
                }).ToListAsync();
            return notifications;
        }
    }
}
