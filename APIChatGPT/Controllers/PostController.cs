using FPT.BusinessLogic;
using FPT.Domain;
using LLMSharp.Google.Palm;
using Microsoft.AspNetCore.Mvc;

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

       
    }
}
