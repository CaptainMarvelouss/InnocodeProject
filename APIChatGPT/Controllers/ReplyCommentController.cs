using FPT.BusinessLogic;
using FPT.Domain;
using LLMSharp.Google.Palm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
namespace APIChatGPT
{
    [ApiController]
    [Route("[controller]")]
    public class ReplyCommentController : ControllerBase
    {
        private readonly InnocodeDbContext _context;

        public ReplyCommentController(InnocodeDbContext context)
        {
            _context = context;
        }
        [HttpPost("CreateReplyComment")]
        public async Task<ActionResult> CreateReplyComment(ReplyCommentDto dto) {
            var UserReply = new CommentReply
            {
                CommentId = dto.CommenId,
                UserId = dto.UserId,
                Content = dto.Content,
                date = DateTime.Now,
                
            };
            await _context.CommentsReply.AddAsync(UserReply);
            await _context.SaveChangesAsync();
            return Ok("Reply Success");
        }
        [HttpPut("UpdateReplyComment")]
        public async Task<IActionResult> UpdateReplyComment(UpdateComment dto)
        {
            var post = await _context.CommentsReply.FirstOrDefaultAsync(p => p.Id == dto.commentId);
            post.Content = dto.content;
            post.date = DateTime.Now;
            
            _context.Update(post);
            await _context.SaveChangesAsync();
            return Ok(post);
        }
        [HttpDelete("DeleteReplyComment")]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            var post = await _context.CommentsReply.FirstOrDefaultAsync(p => p.Id == commentId);
            _context.Remove(post);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("GetAllReplyCommentByCmtId")]
        public async Task<IActionResult> GetAllReplyCommentByCmtId(int id)
        {
            var list = await _context.CommentsReply.Include(p => p.User).Where(p => p.CommentId == id).ToListAsync();
            

            return Ok(list);
        }

    }
}