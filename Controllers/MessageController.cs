using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Oy_yO.Repositories.ChatHub;

namespace Oy_yO.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessageController: ControllerBase
{
    private IHubContext<MessageHub, IMessageHubClient> _messageHub;
    public MessageController(IHubContext<MessageHub, IMessageHubClient> messageHub)
    {
        _messageHub = messageHub;
    }

    [HttpPost]
    [Route("notify")]
    public string Get()
    {
        List<string> notifications = new List<string>
        {
            "Connected successfully",
            "Enjoy your journey"
        };

        _messageHub.Clients.All.SendMessageToClient(notifications);
        return "client notified";
    }
}
