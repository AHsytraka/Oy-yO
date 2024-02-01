using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Oy_yO.Models;
using Oy_yO.Repositories;
using Oy_yO.Service;

namespace Oy_yO.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessageController: ControllerBase
{
    private readonly IChatRepository _chatRepository;
    private readonly IHubContext<ChatHub> _hubContext;
    
    public MessageController(IChatRepository chatRepository, IHubContext<ChatHub> hubContext)
    {
        _chatRepository = chatRepository;
        _hubContext = hubContext;
    }

    [HttpGet("conversation/{senderId}/{receiverId}")]
    public async Task<IActionResult> GetConversation(int senderId, int receiverId)
    {
        var messages = await _chatRepository.GetConversation(senderId, receiverId);
        return Ok(messages);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMessage(Message message)
    {
        await _chatRepository.CreateMessage(message);

        //_HubContext for realtime communication
        await _hubContext.Clients.User(message.ReceiverId.ToString()).SendAsync("ReceiveMessage", message);
        return Ok();
    }
}
