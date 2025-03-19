using AutoMapper;
using ShifaaAPI.DbContext;
using ShifaaAPI.DTO;
using ShifaaAPI.Hubs;
using ShifaaAPI.Models;
using ShifaaAPI.Models.Identity;
using ShifaaAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;


namespace ShifaaAPI.ServicesImplementation
{
    public class ChatService(ApplicationDbContext dbContext, IHubContext<NotificationHub> hubContext, IMapper mapper) : IChatService
    {
        #region Constractor
        private readonly ApplicationDbContext _dbContext = dbContext;
        private readonly IHubContext<NotificationHub> _hubContext = hubContext;
        private readonly IMapper _mapper = mapper;
        #endregion

        #region chat 
        public async Task<List<Chat>> GetMessagesAsync(int senderId, int receiverId)
        {
            var messages = await _dbContext.Chats
                .Where(c => (c.SenderId == senderId && c.ReceiverId == receiverId) ||
                (c.SenderId == receiverId && c.ReceiverId == senderId))
                .OrderBy(c => c.SendTime)
                .ToListAsync();

            return messages;
        }
        public async Task<Chat> SaveMessageAsync(ChatDTO dto)
        {
            var chat = new Chat();
            if (dto.Image != null)
            {
                using var dataStream = new MemoryStream();
                await dto.Image.CopyToAsync(dataStream);
                chat.Image = dataStream.ToArray();
            }
            if (dto.Message != null)
                chat.Message = dto.Message;
            
            chat.SenderId = dto.SenderId;
            chat.ReceiverId = dto.ReceiverId;
            chat.SendTime = DateTime.Now;
            chat.ReceiverType = dto.ReceiverType;
            chat.SenderType = dto.SenderType;
            _dbContext.Chats.Add(chat);
            await _dbContext.SaveChangesAsync();
            return chat;
        }
        public async Task<(string UserName, byte[]? UserPhoto)> GetUserDetails(int userId, string userType)
        {
            if (userType == "Doctor")
            {
                var doctor = await _dbContext.Doctors.Where(d => d.Id == userId)
                    .Select(d => new { d.User.Name, d.User.Photo } ).FirstAsync();
                return(doctor.Name, doctor.Photo);  
            }
            else if (userType == "Patient")
            {
                var patient = await _dbContext.Patients.Where(p => p.Id == userId)
                    .Select(p => new { p.User.Name, p.User.Photo }).FirstAsync();
                return (patient.Name, patient.Photo);
            }
            return("Unknown" ,null);
        }


        public async Task<List<GetChatDTO>> GetAllChatsAsync(int userId, string userType)
        {
            var allChats = await _dbContext.Chats
                .Where(c => c.SenderId == userId || c.ReceiverId == userId)
                .OrderByDescending(c => c.SendTime) // Ensure latest messages come first
                .ToListAsync(); 

            var groupedChats = allChats
                .GroupBy(c => new
                {
                    User1 = Math.Min(c.SenderId, c.ReceiverId),
                    User2 = Math.Max(c.SenderId, c.ReceiverId)
                })
                .Select(g => g.First()) // Select the latest message per group
                .OrderByDescending(c => c.SendTime) // Keep latest messages first
                .ToList();

            var dto = new List<GetChatDTO>();
            foreach (var chat in groupedChats)
            {
                var otherUserId = chat.SenderId == userId ? chat.ReceiverId : chat.SenderId;
                var otherUserType = chat.SenderType == userType ? chat.ReceiverType : chat.SenderType;
                var (otherUserName, otherUserImage) = await GetUserDetails(otherUserId, otherUserType);


                dto.Add(new GetChatDTO
                {
                    Id = chat.Id,
                    Message = chat.Message,
                    SendTime = chat.SendTime,
                    OtherUserName = otherUserName,
                    OtherUserImage = otherUserImage != null ? $"data:image/png;base64,{Convert.ToBase64String(otherUserImage)}" : null,
                    OtherUserId = otherUserId,
                    Image =chat.Image != null ? $"data:image/png;base64,{Convert.ToBase64String(chat.Image)}" : null
                });
            }

            return dto;
        }



        #endregion
    }
}
