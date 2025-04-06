using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProzhektAPI.Data;

namespace ProzhektAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        [HttpGet("GetUserById/{userId}")]
        public IActionResult GetUserById([FromRoute] int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

    }
}
