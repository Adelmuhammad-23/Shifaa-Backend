using ShifaaAPI.DTO;
using ShifaaAPI.Models;
using System.Collections.Generic;

namespace ShifaaAPI.Services
{
    public interface IChatService
    {
        Task<List<Chat>> GetMessagesAsync(int senderId, int receiverId);
        Task<Chat> SaveMessageAsync(ChatDTO dto);
        Task<List<GetChatDTO>> GetAllChatsAsync(int userId , string userType);
        Task<(string UserName, byte[]? UserPhoto)> GetUserDetails(int userId, string userType);


    }
}
