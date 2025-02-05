using ShifaaAPI.Models;
using System.Collections.Generic;

namespace ShifaaAPI.Services
{
    public interface IChatService
    {
        public Task<List<Chat>> GetMessages(int senderId, int receiverId);
        public Task<Chat> SaveMessage(Chat chat);
    }
}
