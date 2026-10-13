using System.ComponentModel.DataAnnotations;

namespace RealTimeChatAPI.Models;

public class Message
{
    public int Id { get; set; }

    [Required]
    [MaxLength(1000)]
    public string Content { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string SenderName { get; set; } = string.Empty;

    public DateTime SentAt { get; set; } = DateTime.UtcNow;
}