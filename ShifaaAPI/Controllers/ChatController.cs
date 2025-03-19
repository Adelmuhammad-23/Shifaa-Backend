using ShifaaAPI.AppMetaData;
using ShifaaAPI.DTO;
using ShifaaAPI.Hubs;
using ShifaaAPI.Models;
using ShifaaAPI.Services;
using ShifaaAPI.ServicesImplementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ShifaaAPI.Controllers
{
    [ApiController]
    public class ChatController : ControllerBase
    {
        #region Constractor
        private readonly IChatService _chatService;
        private readonly IHubContext<ChatHub> _chatHub;
        public ChatController(IChatService chatService, IHubContext<ChatHub> chatHub)
        {
            _chatService = chatService;
            _chatHub = chatHub;
        }
        #endregion
        #region chat

        [HttpGet(Router.ChatRouting.GetMessage)]
        public async Task<IActionResult> GetMessages(int senderId, int receiverId)
        {
            var messages = await _chatService.GetMessagesAsync(senderId, receiverId);
            if (messages == null) return BadRequest("There is not chat between them");
            return Ok(messages);
        }
        [HttpGet(Router.ChatRouting.GetAllChats)]
        public async Task<IActionResult> GetAllChats(int userId, string userType)
        {
            var chats = await _chatService.GetAllChatsAsync(userId, userType);
            if (chats == null) return BadRequest("There are not chats for you ");
            return Ok(chats);
        }

        [HttpPost(Router.ChatRouting.SaveMessage)]
        public async Task<IActionResult> SaveMessage([FromForm] ChatDTO dto)
        {
            try
            {
                var chat = await _chatService.SaveMessageAsync(dto);
                await _chatHub.Clients.User(chat.ReceiverId.ToString())
                .SendAsync("ReceiveMessage", chat.SenderId, chat.SenderType, chat.Message, chat.SendTime);
                return Ok(chat);
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }

        }
        #endregion
       
    }
}
