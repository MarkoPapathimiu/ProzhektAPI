To use **DTOs (Data Transfer Objects)** in your project, you'll essentially be creating specific models to transfer data between different parts of your application (e.g., between your API and the front end). DTOs are typically used to expose only the necessary data that should be shared with the client, without exposing internal database structures directly.

### Overview of What You Need
1. **Sign-up and Login** – You need a way to authenticate users.
2. **Favorite Workouts and Recipes** – Users should be able to save and retrieve their favorite workouts and recipes.
3. **DTOs** – These will help you transfer relevant data between your API and your front end.

Let's break it down into steps.

---

### Step 1: Define the DTOs

For your project, you would likely need a few DTOs for users, workouts, recipes, and favorites. 

#### Example DTOs:

1. **User DTO**: This DTO will be used for transferring user data (excluding sensitive information like passwords).
   ```csharp
   public class UserDto
   {
       public int Id { get; set; }
       public string Username { get; set; }
       public string Email { get; set; }
       // You may exclude sensitive data like password from this DTO
   }
   ```

2. **Login DTO**: When the user logs in, you will accept the login credentials in a DTO.
   ```csharp
   public class LoginDto
   {
       public string Username { get; set; }
       public string Password { get; set; }
   }
   ```

3. **FavoriteWorkout DTO**: This will be used to transfer favorite workouts.
   ```csharp
   public class FavoriteWorkoutDto
   {
       public int WorkoutId { get; set; }
       public int UserId { get; set; }
   }
   ```

4. **FavoriteRecipe DTO**: This will be used for favorite recipes.
   ```csharp
   public class FavoriteRecipeDto
   {
       public int RecipeId { get; set; }
       public int UserId { get; set; }
   }
   ```

5. **Workout DTO**: This DTO is used to transfer the details of a workout (excluding unnecessary internal details).
   ```csharp
   public class WorkoutDto
   {
       public int Id { get; set; }
       public string Name { get; set; }
       public string Description { get; set; }
   }
   ```

6. **Recipe DTO**: Similar to `WorkoutDto`, this is used to transfer details of a recipe.
   ```csharp
   public class RecipeDto
   {
       public int Id { get; set; }
       public string Name { get; set; }
       public string Instructions { get; set; }
   }
   ```

---

### Step 2: Mapping DTOs to Entities

You need to map between the DTOs and your database entities (models). You can do this manually or use a library like **AutoMapper**.

#### Example Manual Mapping:
Assuming you have a `User` model and `UserDto`, you would manually map like this:

```csharp
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("GetUserById/{userId}")]
    public IActionResult GetUserById([FromRoute] int userId)
    {
        var user = _context.Users.Find(userId);
        if (user == null)
        {
            return NotFound();
        }

        var userDto = new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email
        };

        return Ok(userDto);
    }
}
```

#### Using AutoMapper (Optional):
AutoMapper can help simplify the mapping process by automatically mapping properties from your entity to the DTO.

1. Install the AutoMapper package:
   ```bash
   dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
   ```

2. Set up AutoMapper:
   Create a `MappingProfile` class:
   ```csharp
   using AutoMapper;
   using ProzhektAPI.Models;
   using ProzhektAPI.DTOs;

   public class MappingProfile : Profile
   {
       public MappingProfile()
       {
           CreateMap<User, UserDto>();
           CreateMap<Workout, WorkoutDto>();
           CreateMap<Recipe, RecipeDto>();
           CreateMap<FavoriteWorkout, FavoriteWorkoutDto>();
           CreateMap<FavoriteRecipe, FavoriteRecipeDto>();
       }
   }
   ```

3. Register AutoMapper in `Startup.cs` or `Program.cs`:
   ```csharp
   builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
   ```

4. Use AutoMapper in your controller:
   ```csharp
   private readonly IMapper _mapper;

   public UserController(AppDbContext context, IMapper mapper)
   {
       _context = context;
       _mapper = mapper;
   }

   [HttpGet("GetUserById/{userId}")]
   public IActionResult GetUserById([FromRoute] int userId)
   {
       var user = _context.Users.Find(userId);
       if (user == null)
       {
           return NotFound();
       }

       var userDto = _mapper.Map<UserDto>(user);

       return Ok(userDto);
   }
   ```

---

### Step 3: Creating the Endpoints for Sign-Up, Login, and Favorites

#### Sign-Up Endpoint:
For the **sign-up** functionality, you can use the `UserDto` for capturing the registration data.

```csharp
[HttpPost("signup")]
public async Task<IActionResult> SignUp([FromBody] UserDto userDto)
{
    var user = new User
    {
        Username = userDto.Username,
        Email = userDto.Email,
        PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password) // Hashing the password
    };

    _context.Users.Add(user);
    await _context.SaveChangesAsync();

    return Ok(new { message = "User created successfully" });
}
```

#### Login Endpoint:
For **login**, use the `LoginDto` to accept username and password.

```csharp
[HttpPost("login")]
public IActionResult Login([FromBody] LoginDto loginDto)
{
    var user = _context.Users.SingleOrDefault(u => u.Username == loginDto.Username);
    
    if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
    {
        return Unauthorized(new { message = "Invalid credentials" });
    }

    // Issue JWT token or similar authentication here (JWT is commonly used)
    return Ok(new { message = "Login successful", userId = user.Id });
}
```

#### Add Favorite Workout Endpoint:
When a user wants to save a favorite workout:

```csharp
[HttpPost("favorite-workout")]
public IActionResult AddFavoriteWorkout([FromBody] FavoriteWorkoutDto favoriteWorkoutDto)
{
    var favoriteWorkout = new FavoriteWorkout
    {
        UserId = favoriteWorkoutDto.UserId,
        WorkoutId = favoriteWorkoutDto.WorkoutId
    };

    _context.FavoriteWorkouts.Add(favoriteWorkout);
    _context.SaveChanges();

    return Ok(new { message = "Favorite workout added" });
}
```

#### Add Favorite Recipe Endpoint:
When a user wants to save a favorite recipe:

```csharp
[HttpPost("favorite-recipe")]
public IActionResult AddFavoriteRecipe([FromBody] FavoriteRecipeDto favoriteRecipeDto)
{
    var favoriteRecipe = new FavoriteRecipe
    {
        UserId = favoriteRecipeDto.UserId,
        RecipeId = favoriteRecipeDto.RecipeId
    };

    _context.FavoriteRecipes.Add(favoriteRecipe);
    _context.SaveChanges();

    return Ok(new { message = "Favorite recipe added" });
}
```

---

### Step 4: Test the API
- You can test the API endpoints using tools like **Postman** or **Insomnia**.
- For **sign-up** and **login**, ensure you're sending the correct payload as expected by your DTOs.
- For **favorite workouts** and **favorite recipes**, you’ll need to send the `UserId` and corresponding `WorkoutId` or `RecipeId` in the request body.

---

### Final Thoughts:
By introducing DTOs, you're keeping your API clean and allowing flexibility in how data is transferred. The key is to make sure that each controller action takes the correct DTO and transforms or processes that data as needed. The front-end will then interact with the API using these DTOs via HTTP requests (like `POST`, `GET`), and you’ll return appropriate data back to the user.

The flow is:
- **Sign Up/Log In:** Send `UserDto`/`LoginDto` from front-end to API for creating/logging in users.
- **Favorite Workouts/Recipes:** Send `FavoriteWorkoutDto`/`FavoriteRecipeDto` for saving favorites.



Sure! Based on the example you've provided for the **StudentController**, I can create a similar `UserController` for your project. The `UserController` will handle operations related to users, such as:

- Retrieving a list of users or a specific user by their ID.
- Adding a new user (sign-up).
- Updating user details.
- Deleting a user.
- Managing user favorites (like workouts and recipes).

### **UserController Example for Your Project**

Here's a breakdown of the **UserController** similar to your **StudentController**:

```csharp
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProzhektAPI.Data;
using ProzhektAPI.Models;
using ProzhektAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ProzhektAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Constructor
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        #region Get Users

        // Endpoint to get a list of all users
        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        // Endpoint to get a user by ID
        [HttpGet("GetUserById/{userId}")]
        public IActionResult GetUserById(int userId)
        {
            var user = _context.Users.FirstOrDefault(n => n.Id == userId);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        #endregion

        #region User Registration (Sign-Up)

        // Endpoint to register a new user (Sign-Up)
        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody] PostUserDto payload)
        {
            // Check if the username already exists
            var existingUser = _context.Users.FirstOrDefault(u => u.Username == payload.Username);
            if (existingUser != null)
            {
                return BadRequest("Username already exists.");
            }

            // Create a new user object
            var newUser = new User
            {
                Username = payload.Username,
                FullName = payload.FullName,
                Password = payload.Password // Password should be hashed in a real application
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUserById), new { userId = newUser.Id }, newUser);
        }

        #endregion

        #region Update User

        // Endpoint to update an existing user's details
        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser([FromBody] PutUserDto payload)
        {
            var user = _context.Users.FirstOrDefault(n => n.Id == payload.Id);
            if (user == null)
            {
                return NotFound();
            }

            // Update user details
            user.FullName = payload.FullName;
            user.Username = payload.Username; // This can be left out if you don't want users changing their usernames
            _context.Users.Update(user);
            _context.SaveChanges();

            return Ok(user);
        }

        #endregion

        #region Delete User

        // Endpoint to delete a user
        [HttpDelete("DeleteUser/{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            var user = _context.Users.FirstOrDefault(n => n.Id == userId);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return Ok();
        }

        #endregion

        #region Manage Favorite Workouts & Recipes

        // Endpoint to add a workout to the user's favorite workouts list
        [HttpPost("AddFavoriteWorkout/{userId}")]
        public IActionResult AddFavoriteWorkout(int userId, [FromBody] int workoutId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return NotFound();
            }

            var favoriteWorkout = new FavoriteWorkout
            {
                UserId = userId,
                WorkoutId = workoutId
            };

            _context.FavoriteWorkouts.Add(favoriteWorkout);
            _context.SaveChanges();

            return Ok();
        }

        // Endpoint to add a recipe to the user's favorite recipes list
        [HttpPost("AddFavoriteRecipe/{userId}")]
        public IActionResult AddFavoriteRecipe(int userId, [FromBody] int recipeId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return NotFound();
            }

            var favoriteRecipe = new FavoriteRecipe
            {
                UserId = userId,
                RecipeId = recipeId
            };

            _context.FavoriteRecipes.Add(favoriteRecipe);
            _context.SaveChanges();

            return Ok();
        }

        #endregion
    }
}
```

### Explanation of the Methods:

#### 1. **GetUsers & GetUserById**
- These two methods retrieve a list of users or a specific user by ID. The `GetUserById` method takes the `userId` parameter from the URL and returns the user data if it exists.

#### 2. **AddUser (Sign-Up)**
- This method allows you to add a new user. It checks if the `Username` already exists to avoid duplicates. If not, a new `User` is created and saved in the database. The `PostUserDto` is used to receive data from the client.

#### 3. **UpdateUser**
- This method updates the user's details, such as the full name and username. It checks if the user exists before attempting to update the record.

#### 4. **DeleteUser**
- This method deletes a user by their `userId`. It first checks if the user exists, and if they do, removes the record from the database.

#### 5. **Manage Favorite Workouts & Recipes**
- These methods allow the user to add workouts and recipes to their "favorites" list. When a user sends a `POST` request with a `userId` and `workoutId` or `recipeId`, it adds the corresponding entry to the `FavoriteWorkouts` or `FavoriteRecipes` table.

---

### DTOs (Data Transfer Objects)

The **DTOs** that the above controller uses are:

- `PostUserDto` (used in the `AddUser` method)
- `PutUserDto` (used in the `UpdateUser` method)

Here's an example of what the `PostUserDto` and `PutUserDto` could look like:

```csharp
public class PostUserDto
{
    public string Username { get; set; }
    public string FullName { get; set; }
    public string Password { get; set; }
}

public class PutUserDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Username { get; set; }
}
```

### Summary:
This controller enables you to:
- Add, update, and delete users.
- Retrieve user information by ID.
- Manage a user's favorite workouts and recipes.

### Connecting to Frontend
Once your API is up and running, you can connect it to the frontend using **AJAX**, **Fetch API**, or any HTTP client (like Axios in React). The frontend will call these API endpoints (like `/api/users/AddUser`, `/api/users/GetUserById`, etc.) to interact with the user data.

Let me know if you'd like to expand or change anything in the controller or if you need assistance integrating the API with the frontend!



Sure! Here's a breakdown of **when each API method would be called** from the frontend of your website. Each method is tied to a specific user action, like signing up, logging in, updating a profile, or adding/removing favorite workouts or recipes.

### 1. **`AddUser` (Sign-Up)**

- **When it's called:**  
  This method would be called **when the user submits the sign-up form** on the frontend website. It takes the user’s input (like **username**, **full name**, and **password**) and sends a `POST` request to the API.
  
- **Frontend Connection:**
  When the user clicks the **sign-up button**, the frontend sends the user details in the request body to the `AddUser` endpoint (`POST /api/user/AddUser`).
  
  **Example in JavaScript (using `fetch`):**
  ```javascript
  const signUp = async (username, fullName, password) => {
    const response = await fetch('http://localhost:5000/api/user/AddUser', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ username, fullName, password })
    });
    
    if (response.ok) {
      // Handle success, like redirecting to login page
    } else {
      // Handle error (e.g., username already exists)
    }
  };
  ```

---

### 2. **`UpdateUser` (Profile Update)**

- **When it's called:**  
  This method is called **when the user updates their profile** (e.g., changes their full name, username, etc.). 

- **Frontend Connection:**
  When the user clicks the **update profile button**, the frontend sends the updated information (e.g., **new full name**, **new username**) in the request body to the `UpdateUser` endpoint (`PUT /api/user/UpdateUser`).

  **Example in JavaScript:**
  ```javascript
  const updateUser = async (userId, fullName, username) => {
    const response = await fetch('http://localhost:5000/api/user/UpdateUser', {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ id: userId, fullName, username })
    });

    if (response.ok) {
      // Handle success (e.g., update UI with new user info)
    } else {
      // Handle error
    }
  };
  ```

---

### 3. **`GetUsers` (Get All Users)**

- **When it's called:**  
  This method could be called in **admin panels** or **admin dashboards** to fetch and display a list of all users.

- **Frontend Connection:**
  When the admin clicks a **button to view all users** or when the page loads and needs to display a list of all users, the frontend sends a `GET` request to the `GetUsers` endpoint (`GET /api/user/GetUsers`).
  
  **Example in JavaScript:**
  ```javascript
  const getUsers = async () => {
    const response = await fetch('http://localhost:5000/api/user/GetUsers');
    const users = await response.json();
    
    if (response.ok) {
      // Display the users in a list on the admin page
    } else {
      // Handle error
    }
  };
  ```

---

### 4. **`GetUserById` (Get User by ID)**

- **When it's called:**  
  This method is called **when you need to fetch a user's details by their ID**. This could happen after the user logs in, or when viewing a user's profile or settings.

- **Frontend Connection:**
  After a user logs in, the frontend needs to fetch the user’s data (e.g., when showing their profile page). The frontend sends a `GET` request to the `GetUserById` endpoint (`GET /api/user/GetUserById/{userId}`), where `userId` is the logged-in user's ID.

  **Example in JavaScript:**
  ```javascript
  const getUserById = async (userId) => {
    const response = await fetch(`http://localhost:5000/api/user/GetUserById/${userId}`);
    const user = await response.json();

    if (response.ok) {
      // Display user details on the profile page
    } else {
      // Handle error
    }
  };
  ```

---

### 5. **`DeleteUser` (Delete Profile)**

- **When it's called:**  
  This method would be called **when the user clicks on the delete account button** in their settings or profile page.

- **Frontend Connection:**
  When the user clicks the **delete account** button, the frontend sends a `DELETE` request to the `DeleteUser` endpoint (`DELETE /api/user/DeleteUser/{userId}`), where `userId` is the ID of the user who wants to delete their account.

  **Example in JavaScript:**
  ```javascript
  const deleteUser = async (userId) => {
    const response = await fetch(`http://localhost:5000/api/user/DeleteUser/${userId}`, {
      method: 'DELETE',
    });

    if (response.ok) {
      // Handle success, e.g., log the user out and redirect to home page
    } else {
      // Handle error (e.g., user not found)
    }
  };
  ```

---

### 6. **`AddFavoriteWorkout` (Add a Favorite Workout)**

- **When it's called:**  
  This method is called **when the user adds a workout to their favorites** (e.g., from a list of available workouts).

- **Frontend Connection:**
  When the user clicks the **favorite button** on a workout, the frontend sends a `POST` request to the `AddFavoriteWorkout` endpoint (`POST /api/user/AddFavoriteWorkout/{userId}`), passing the workout ID in the request body.

  **Example in JavaScript:**
  ```javascript
  const addFavoriteWorkout = async (userId, workoutId) => {
    const response = await fetch(`http://localhost:5000/api/user/AddFavoriteWorkout/${userId}`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ workoutId }),
    });

    if (response.ok) {
      // Handle success (e.g., show a success message or update UI)
    } else {
      // Handle error
    }
  };
  ```

---

### 7. **`AddFavoriteRecipe` (Add a Favorite Recipe)**

- **When it's called:**  
  This method is called **when the user adds a recipe to their favorites** (e.g., from a list of available recipes).

- **Frontend Connection:**
  When the user clicks the **favorite button** on a recipe, the frontend sends a `POST` request to the `AddFavoriteRecipe` endpoint (`POST /api/user/AddFavoriteRecipe/{userId}`), passing the recipe ID in the request body.

  **Example in JavaScript:**
  ```javascript
  const addFavoriteRecipe = async (userId, recipeId) => {
    const response = await fetch(`http://localhost:5000/api/user/AddFavoriteRecipe/${userId}`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ recipeId }),
    });

    if (response.ok) {
      // Handle success (e.g., show a success message or update UI)
    } else {
      // Handle error
    }
  };
  ```

---

### **Summary of Connections:**

1. **AddUser (Sign-Up)**: Called when the user submits the sign-up form.
2. **UpdateUser (Profile Update)**: Called when the user updates their profile details.
3. **GetUsers (All Users)**: Called by an admin or other users to fetch the list of all users (for example, in an admin panel).
4. **GetUserById (User Profile)**: Called when displaying a specific user's profile or personal details.
5. **DeleteUser (Delete Account)**: Called when the user wants to delete their account.
6. **AddFavoriteWorkout (Add Workout to Favorites)**: Called when the user adds a workout to their list of favorites.
7. **AddFavoriteRecipe (Add Recipe to Favorites)**: Called when the user adds a recipe to their list of favorites.

### Final Thoughts:
By calling these API endpoints from your frontend, you can easily connect your UI (buttons, forms, etc.) to the backend logic in your **UserController**. Each of these actions happens based on specific user interactions, like submitting a form or clicking a button.

Let me know if you'd like further clarification on any part!