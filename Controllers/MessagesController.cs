using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealTimeChatAPI.Data;
using RealTimeChatAPI.Models;

namespace RealTimeChatAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessagesController : ControllerBase
{
    private readonly AppDbContext _context;

    public MessagesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetMessages()
    {
        var messages = await _context.Messages
            .OrderBy(m => m.SentAt)
            .ToListAsync();

        return Ok(messages);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMessage(Message message)
    {
        if (string.IsNullOrWhiteSpace(message.SenderName) ||
            string.IsNullOrWhiteSpace(message.Content))
        {
            return BadRequest("SenderName and Content are required.");
        }

        message.Id = 0;
        message.SenderName = message.SenderName.Trim();
        message.Content = message.Content.Trim();
        message.SentAt = DateTime.UtcNow;

        _context.Messages.Add(message);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMessages), new { id = message.Id }, message);
    }
}