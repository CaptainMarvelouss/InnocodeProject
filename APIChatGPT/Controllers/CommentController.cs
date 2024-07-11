using FPT.BusinessLogic;
using FPT.BusinessLogic.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace APIChatGPT;

[ApiController]
[Route("[controller]")]
public class CommentController : ControllerBase
{
    private readonly InnocodeDbContext _context;

    public CommentController(InnocodeDbContext context)
    {
        _context = context;
    }

    [HttpPost("CreateComment")]
    public async Task<ActionResult> CreateComment(CommentDto dto)
    {
        var UserComment = new Comment { 
            Content = dto.Content,
            UserId = dto.UserId,
            date =DateTime.Now,
            PostId = dto.PostId,
        };
        await _context.Comments.AddAsync(UserComment);
        await _context.SaveChangesAsync();
        return Ok("Comment Success");

    }
    [HttpDelete("DeleteComment")]
    public async Task<IActionResult> DeleteComment(int commentId)
    {
        var post = await _context.Comments.FirstOrDefaultAsync(p => p.Id == commentId);
        _context.Remove(post);
        await _context.SaveChangesAsync();
        return Ok();
    }
    [HttpGet("GetAllCommentByUserId")]
    public async Task<IActionResult> GetAllCommentByUserId(int UserId)
    {
        var list = await _context.Comments.Where(p => p.UserId == UserId).ToListAsync();
        return Ok(list);
    }
    [HttpPut("UpdateComment")]
    public async Task<IActionResult> UpdateComment(UpdateComment dto)
    {
        var post = await _context.Comments.FirstOrDefaultAsync(p => p.Id == dto.commentId);
        post.Content = dto.content;
        post.date = DateTime.Now;
        _context.Update(post);
        await _context.SaveChangesAsync();
        return Ok(post);
    }


}