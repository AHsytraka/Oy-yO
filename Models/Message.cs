namespace Oy_yO.Models;

public class Message
{
    public int MessageId { get; set; }
    public required int SenderId { get; set; }
    public required int ReceiverId { get; set; }
    public required string MessageText { get; set; }
    public DateTime MessageDate { get; set; }
}
