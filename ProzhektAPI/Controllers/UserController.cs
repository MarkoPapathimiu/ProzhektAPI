using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProzhektAPI.Data;
using ProzhektAPI.Data.Dtos;
using ProzhektAPI.Data.Mappers;

namespace ProzhektAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    [EnableCors("AllowAll")]
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
            var user = _context.Users.FirstOrDefault(thisId => thisId.Id == userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] PostUserDto payload)
        {
            var user = UserMappers.ToUser(payload);
            _context.Users.Add(user);

            _context.SaveChanges();
            return Ok(user);
        }

        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser([FromBody] PutUserDto payload)
        {
            var user = _context.Users.FirstOrDefault(thisId => thisId.Id == payload.Id);
            if (user == null)
            {
                return NotFound();
            }

            UserMappers.ToUpdateUserDto(user, payload);

            _context.Users.Update(user);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("DeleteUser/{userId}")]
        public IActionResult DeleteUser([FromRoute] int userId)
        {
            var user = _context.Users.FirstOrDefault(thisId => thisId.Id == userId);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return Ok();
        }

    }
}
