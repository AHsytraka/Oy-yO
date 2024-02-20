using System.ComponentModel.DataAnnotations;

namespace Oy_yO.Models;

public class Message
{
    public int MessageId { get; set; }
    public required int SenderId { get; set; }
    public required int ReceiverId { get; set; }
    [MaxLength(1000)]
    public required string MessageText { get; set; }
    public DateTime MessageDate { get; set; }
}
