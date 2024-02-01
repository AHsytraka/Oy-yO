using Microsoft.EntityFrameworkCore;
using Oy_yO.Models;

namespace Oy_yO.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<Message> Messages { get; set; }
}
