using Microsoft.AspNetCore.SignalR;

namespace Oy_yO.Repositories.ChatHub
{
    public class MessageHub : Hub<IMessageHubClient>
    {
        public async Task SendMessageToClient(List<string> messages)
        {
            await Clients.All.SendMessageToClient(messages);
        }
    }
}
