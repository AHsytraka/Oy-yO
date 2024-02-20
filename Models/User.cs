using System.ComponentModel.DataAnnotations;

namespace Oy_yO.Models;

public class User
{
    public int UserId { get; set; }
    [MaxLength(250)]
    public required string UserName { get; set; }
}
