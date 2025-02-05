using ShifaaAPI.DbContext;
using ShifaaAPI.Models;
using ShifaaAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace ShifaaAPI.ServicesImplementation
{
    public class ChatService : IChatService
    {
        #region Constractor
        private readonly ApplicationDbContext _dbContext;
        public ChatService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion
        #region Services
        public async Task<List<Chat>> GetMessages(int senderId, int receiverId)
        {
            var messages = await _dbContext.Chats
                .Where(c => (c.SenderId == senderId && c.ReceiverId == receiverId) ||
                (c.SenderId == receiverId && c.ReceiverId == senderId))
                .OrderBy(c => c.SendTime)
                .ToListAsync();

            return messages;
        }
        public async Task<Chat> SaveMessage(Chat chat)
        {
             _dbContext.Chats.Add(chat);
            await _dbContext.SaveChangesAsync();    
            return chat;
        }
        #endregion
    }
}
