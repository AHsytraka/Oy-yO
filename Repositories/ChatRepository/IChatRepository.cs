using Oy_yO.Models;

namespace Oy_yO.Repositories;

public interface IChatRepository
{
    Task CreateMessage(Message message);
    Task<List<Message>> GetConversation(int senderId, int receiverId);
}
