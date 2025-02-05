using ShifaaAPI.Hubs;
using ShifaaAPI.Models;
using ShifaaAPI.Services;
using ShifaaAPI.ServicesImplementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ShifaaAPI.Controllers
{
    [ApiController]
    public class ChatController : ControllerBase
    {
        #region Constractor
        private readonly IChatService _chatService;
        private readonly IHubContext<ChatHub> _chatHub;
        public ChatController(IChatService chatService , IHubContext<ChatHub> chatHub)
        {
            _chatService = chatService;
            _chatHub = chatHub;
        }
        #endregion
        #region end point

        [HttpGet("{senderId}/{receiverId}")]
        public async Task<IActionResult> GetMessages(int senderId, int receiverId)
        {
            var messages = await _chatService.GetMessages(senderId, receiverId);
            if (messages == null) return BadRequest("There is not chat between them");
            return Ok(messages);
        }

        [HttpPost("send")]
        public async Task<IActionResult> SaveMessage([FromBody] Chat chat) 
        {
            var message = await _chatService.SaveMessage(chat);
            await _chatHub.Clients.User(chat.ReceiverId.ToString())
            .SendAsync("ReceiveMessage", chat.SenderId, chat.SenderType, chat.Message, chat.SendTime);
            return Ok(message); 
        }

        #endregion
    }
}
