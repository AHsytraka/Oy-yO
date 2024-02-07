using Microsoft.AspNetCore.SignalR;
using SignalRSwaggerGen.Attributes;

namespace Oy_yO.Service;

[SignalRHub]
public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
