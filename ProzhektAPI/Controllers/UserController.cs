﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProzhektAPI.Data;
using ProzhektAPI.Data.Dtos;
using ProzhektAPI.Data.Mappers;
using ProzhektAPI.Data.Models;

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

        // Add favorite workout
        [HttpPost("AddFavoriteWorkout")]
        public IActionResult AddFavoriteWorkout([FromBody] FavoriteWorkout fav)
        {
            _context.FavoriteWorkouts.Add(fav); // Adds a new row in the FavoriteWorkout table
            _context.SaveChanges();            // Save it to the databse
            return Ok("Workout added to favorites");
        }

        // Get favorite workouts for a user
        [HttpGet("GetFavoriteWorkouts/{userId}")]
        public IActionResult GetFavoriteWorkouts(int userId)
        {
            var workouts = _context.FavoriteWorkouts
                .Where(f => f.UserId == userId)
                .Select(f => f.Workout) // Get the actual workout object
                .ToList();

            return Ok(workouts);
        }

        // Remove favorite workout
        [HttpDelete("RemoveFavoriteWorkout")]
        public IActionResult RemoveFavoriteWorkout([FromBody] FavoriteWorkout fav)
        {
            var favEntry = _context.FavoriteWorkouts
                .FirstOrDefault(f => f.UserId == fav.UserId && f.WorkoutId == fav.WorkoutId);

            if (favEntry == null) return NotFound("Favorite not found");

            _context.FavoriteWorkouts.Remove(favEntry);
            _context.SaveChanges();
            return Ok("Workout removed from favorites");
        }

        // Add favorite recipe
        [HttpPost("AddFavoriteRecipe")]
        public IActionResult AddFavoriteRecipe([FromBody] FavoriteRecipe fav)
        {
            _context.FavoriteRecipes.Add(fav);
            _context.SaveChanges();
            return Ok("Recipe added to favorites.");
        }

        // Get favorite recipes for a user
        [HttpGet("GetFavoriteRecipes/{userId}")]
        public IActionResult GetFavoriteRecipes(int userId)
        {
            var recipes = _context.FavoriteRecipes
                .Where(f => f.UserId == userId)
                .Select(f => f.Recipe) // Get the actual recipe object
                .ToList();

            return Ok(recipes);
        }

        // Remove favorite recipe
        [HttpDelete("RemoveFavoriteRecipe")]
        public IActionResult RemoveFavoriteRecipe([FromBody] FavoriteRecipe fav)
        {
            var favEntry = _context.FavoriteRecipes
                .FirstOrDefault(f => f.UserId == fav.UserId && f.RecipeId == fav.RecipeId);

            if (favEntry == null) return NotFound("Favorite not found.");

            _context.FavoriteRecipes.Remove(favEntry);
            _context.SaveChanges();
            return Ok("Recipe removed from favorites");
        }

    }
}
