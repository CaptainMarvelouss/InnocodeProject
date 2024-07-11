using FPT.BusinessLogic;
using FPT.Domain;
using LLMSharp.Google.Palm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace APIChatGPT
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly InnocodeDbContext _context;

        public AuthController(InnocodeDbContext context)
        {
            _context = context;
        }

        [HttpPost("Sign Up")]
        public async Task<ActionResult> SignUp(SignUpDto dto)
        {
            var EmailExist = await _context.Users.Where(x=>x.Email==dto.Email).Select(x => x.Email).FirstOrDefaultAsync();
            if (EmailExist != null)
            {
                throw new Exception("Email already register!!");

            }
            var UserNameExist = await _context.Users.Where(x => x.UserName == dto.UserName).Select(x => x.UserName).FirstOrDefaultAsync();
            if (UserNameExist != null)
            {
                throw new Exception("User Name already register!!");

            }
            var NewUser = new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                DisplayName = dto.DisplayName,
                Password = dto.Password,
            };
            await _context.Users.AddAsync(NewUser);
            await _context.SaveChangesAsync();
            return Ok("Sign Up succcess");
        }
        [HttpPost("Sign In")]
        public async Task<User> SignIn(SignInDto dto) {
            var user = await _context.Users.Where(p=>p.UserName == dto.UserName && p.Password ==dto.Password ).FirstOrDefaultAsync();
            if (user == null) {
                throw new Exception("Login Fail");
            }
            return user;
        }

    }
}