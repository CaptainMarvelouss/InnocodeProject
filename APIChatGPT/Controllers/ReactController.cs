using FPT.BusinessLogic;
using FPT.BusinessLogic.Enums;
using FPT.Domain;
using LLMSharp.Google.Palm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace APIChatGPT
{
    [ApiController]
    [Route("[controller]")]
    public class ReactController : ControllerBase
    {
        private readonly InnocodeDbContext _context;

        public ReactController(InnocodeDbContext context)
        {
            _context = context;
        }


        [HttpPost("React")]
        public async Task<ActionResult> React(ReactDto dto)
        {
            if (dto.CommentReplyId == 0) {
                dto.CommentReplyId = null;
            }
            if (dto.CommentId == 0)
            {
                dto.CommentId = null;
            }
            if (dto.PostID == 0)
            {
                dto.PostID = null;
            }
            var Ureact = new React
            {
                Emotion = dto.Emotion,
                CommentId = dto.CommentId,
                PostId = dto.PostID,
                UserId = dto.UserId,
                CommentReplyId = dto.CommentReplyId
            };
            await _context.Reacts.AddAsync(Ureact);
            await _context.SaveChangesAsync();
            return Ok("Send Success");

        }
        [HttpPost("GetAllReactByPost")]
        public async Task<ActionResult> GetAllReactPost(Emotion emotion,int id)
        {
            var CountReact = await _context.Posts.Where(x => x.Id == id).Select(p => p.Reacts.Where(r => r.Emotion == emotion).Count()).FirstOrDefaultAsync();
            return Ok(CountReact);
        }
        [HttpPost("GetAllReactByComment")]
        public async Task<ActionResult> GetAllReactComment(Emotion emotion, int id)
        {
            var CountReact = await _context.Comments.Where(x => x.Id == id).Select(p => p.Reacts.Where(r => r.Emotion == emotion).Count()).FirstOrDefaultAsync();
            return Ok(CountReact);
        }
        [HttpPost("GetAllReactByCommentReply")]
        public async Task<ActionResult> GetAllReactCommentReply(Emotion emotion, int id)
        {
            var CountReact = await _context.CommentsReply.Where(x => x.Id == id).Select(p => p.Reacts.Where(r => r.Emotion == emotion).Count()).FirstOrDefaultAsync();
            return Ok(CountReact);
        }
    }
}