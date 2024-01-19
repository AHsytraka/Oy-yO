namespace Oy_yO.Repositories.ChatHub
{
    public interface IMessageHubClient
    {
        Task SendMessageToClient(List<string> messages);
    }
}
