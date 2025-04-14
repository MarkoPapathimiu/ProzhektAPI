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

        // Get all Users from database
        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        // Get User by ID from database
        // Used in LogIn and TrackerPage
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
