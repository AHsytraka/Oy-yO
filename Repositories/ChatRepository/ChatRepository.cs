using Microsoft.EntityFrameworkCore;
using Oy_yO.Data;
using Oy_yO.Models;

namespace Oy_yO.Repositories;

public class ChatRepository : IChatRepository
{
    private readonly AppDbContext _appDbContext;
    public ChatRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task CreateMessage(Message message)
    {
        await _appDbContext.Messages.AddAsync(message);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<List<Message>> GetConversation(int senderId, int receiverId)
    {
        return await _appDbContext.Messages.Where(
            m => m.SenderId == senderId && m.ReceiverId == receiverId 
            || m.SenderId == receiverId && m.ReceiverId == senderId).ToListAsync();
    }
}
