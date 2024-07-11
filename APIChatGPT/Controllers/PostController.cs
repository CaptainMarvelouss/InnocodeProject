using FPT.BusinessLogic;
using FPT.BusinessLogic.Enums;
using FPT.Domain;
using LLMSharp.Google.Palm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FPT.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly InnocodeDbContext _context;

        public PostController(InnocodeDbContext context)
        {
            _context = context;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateNewPost(CreateNewPostDto dto)
        {
            var post = new Post
            {
                Category = dto.Category,
                Content = dto.Content,
                Image = dto.Image,
                Title = dto.Title,
                UserId = dto.UserId,
                State = dto.state,
            };
            await _context.AddAsync(post);
            await _context.SaveChangesAsync();
            return Ok(post);
        }

        [HttpPut("UpdatePostState")]
        public async Task<IActionResult> UpdatePostState(UpdatePostStateDto dto)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == dto.PostId);
            post.State = dto.State;
            _context.Update(post);
            await _context.SaveChangesAsync();
            return Ok(post);
        }

        [HttpPut("UpdatePost")]
        public async Task<IActionResult> UpdatePost(UpdatePostDto dto)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == dto.PostId);
            post.Content = dto.Content;
            post.Title = dto.Title;
            post.Category = dto.Category;
            post.Image = dto.Image;

            _context.Update(post);
            await _context.SaveChangesAsync();
            return Ok(post);
        }
        [HttpGet("GetAllPostById")]
        public async Task<IActionResult> GetAllPostByUserId(int UserId)
        {
            var list =await _context.Posts.Where(p => p.UserId == UserId).ToListAsync();
            return Ok(list);
        }
        [HttpDelete("DeletePost")]
        public async Task<IActionResult> DeletePost (int postId)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId);
            _context.Remove(post);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("SortAllPost")]
        public async Task<IActionResult> SortAllPost (SortEnum sortEnum)
        {
            List<Post> list = new List<Post>();
            if (sortEnum == SortEnum.ReactAscending)
            {
                list = await _context.Posts.OrderByDescending(x => -x.Reacts.Count).ToListAsync();
            }
            if (sortEnum == SortEnum.ReactDescending)
            {
                list = await _context.Posts.OrderByDescending(x => x.Reacts.Count).ToListAsync();
            }
            if (sortEnum == SortEnum.TimeDescending)
            {
                list = await _context.Posts.OrderByDescending(x => x.date).ToListAsync();
            }
            if (sortEnum == SortEnum.TimeAscending)
            {
                list = await _context.Posts.OrderByDescending(x => x.date).Reverse().ToListAsync();
            }
            return Ok(list);
        }
        [HttpPost("SearchPost")]
        public async Task<IActionResult> SearchPost(SearchPostDto dto)
        {
            List<Post> list = new List<Post>();
            if (dto.Category == Category.All)
            {
                list = await _context.Posts.Where(p => (p.Content.Contains(dto.searchString) || p.Title.Contains(dto.searchString)) && p.State == dto.State).ToListAsync();
            }
            else
            {
                 list = await _context.Posts.Where(p => (p.Content.Contains(dto.searchString) || p.Title.Contains(dto.searchString))&& p.Category == dto.Category && p.State == dto.State).ToListAsync();
            }
            if (dto.SortEnum == SortEnum.ReactAscending)
            {
                list =  list.OrderByDescending(x => -x.Reacts.Count).ToList();
            }
            if (dto.SortEnum == SortEnum.ReactDescending)
            {
                list =  list.OrderByDescending(x => x.Reacts.Count).ToList();
            }
            if (dto.SortEnum == SortEnum.TimeDescending)
            {
                list = list.OrderByDescending(x => x.date).ToList();
            }
            if (dto.SortEnum == SortEnum.TimeAscending)
            {
                list =  list.OrderByDescending(x => x.date).Reverse().ToList();
            }
            return Ok(list);
        }
    }
}
