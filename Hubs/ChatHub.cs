using Microsoft.AspNetCore.SignalR;
using RealTimeChatAPI.Data;
using RealTimeChatAPI.Models;

namespace RealTimeChatAPI.Hubs;

public class ChatHub : Hub
{
    private readonly AppDbContext _context;

    public ChatHub(AppDbContext context)
    {
        _context = context;
    }

    public async Task SendMessage(string senderName, string content)
    {
        if (string.IsNullOrWhiteSpace(senderName) || senderName.Length > 100)
        {
            throw new HubException("Sender name is required and must be at most 100 characters.");
        }

        if (string.IsNullOrWhiteSpace(content) || content.Length > 1000)
        {
            throw new HubException("Message content is required and must be at most 1000 characters.");
        }

        var message = new Message
        {
            SenderName = senderName.Trim(),
            Content = content.Trim(),
            SentAt = DateTime.UtcNow
        };

        _context.Messages.Add(message);
        await _context.SaveChangesAsync();

        await Clients.All.SendAsync("ReceiveMessage", message);
    }
}