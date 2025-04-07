# Important

This document stores some important explanations of logic and code for the prozhekt as well as some guidlines and ideas for further development.

# Explanation of Database Tables Connections

### 1. **Tables Involved**

- **User Table**: This table stores basic information about each user (e.g., their name, username, etc.).
- **Workout Table**: This table stores information about different workouts (e.g., the name of the workout, description, etc.).
- **FavoriteWorkouts Table**: This table connects the **User** table and the **Workout** table. It stores records that represent which workouts a user has marked as their favorites.

### 2. **Storing the Information**

- Each user has a unique ID, and each workout also has a unique ID.
- When a user likes a workout, a record is added to the **FavoriteWorkouts** table. This record simply says:
  - "User with this ID likes this workout with this ID."

This means that the **FavoriteWorkouts** table doesn't store any workout details directly. Instead, it only stores references (IDs) to both the user and the workout.

### 3. **What Happens When You Want to Display a User's Data?**

- **User Data**: First, you retrieve the user's basic information from the **User Table**. For example, you fetch their name, username, and other profile information.
- **Favorite Workouts**: Then, to get the workouts that this user likes, you look in the **FavoriteWorkouts Table** to find all the records where the **User ID** matches the user you're interested in.

- These records in the **FavoriteWorkouts Table** will tell you which **Workout IDs** this user has marked as a favorite.
- Finally, for each **Workout ID** retrieved from the **FavoriteWorkouts Table**, you can use that ID to look up the full details of each workout in the **Workout Table**. For example, the **Workout Table** will tell you the name, description, and other details about each workout.

### 4. **How the Logic Works:**

- **Step 1**: You find the user in the **User Table**.
- **Step 2**: You find all records in the **FavoriteWorkouts Table** where the **User ID** matches the user you want.
- **Step 3**: For each record, you look up the **Workout ID** in the **Workout Table** to get the details of the workout.
- **Step 4**: Display the user's information and then display each workout they have marked as a favorite.

### 5. **The Relationship Between the Tables**

- The **User Table** and **Workout Table** are not directly connected. Instead, they are connected through the **FavoriteWorkouts Table**.
- The **FavoriteWorkouts Table** holds the **User ID** and **Workout ID**, which links a user to a workout. It acts like a bridge that connects the two tables (users and workouts).

### 6. **Summary of Logic**

To summarize:

- The **User Table** holds individual user data.
- The **Workout Table** holds workout data.
- The **FavoriteWorkouts Table** connects a user to their favorite workouts using references (IDs) to both users and workouts.

When you need to display a user's information along with their favorite workouts:

1. Retrieve the user's details from the **User Table**.
2. Retrieve the list of workouts they like from the **FavoriteWorkouts Table** (by matching their user ID).
3. For each favorite workout, retrieve full workout details from the **Workout Table**.
4. Display both the user's info and their favorite workouts.

This structure helps keep the data organized and ensures that each workout and user only needs to be stored once, minimizing redundancy.

---

# Real Database Creation (No FakeDb)

Creating a real database in an ASP.NET Core application using **Entity Framework Core (EF Core)** involves several steps. EF Core is an **Object-Relational Mapper (ORM)** that helps you interact with databases using .NET objects. You'll define your **models** (classes), create a **DbContext** class to manage these models, and then use **migrations** to create a real database.

Here's a high-level guide on how to create a real database instead of using a fake in-memory database like `FakeDb.cs`:

### 1. **Install Required NuGet Packages**

First, make sure that the required **Entity Framework Core** packages are installed. You can do this by running the following commands in your **Package Manager Console** or using **NuGet**:

- **For SQL Server** (common database for many ASP.NET Core projects):

  ```bash
  dotnet add package Microsoft.EntityFrameworkCore.SqlServer
  ```

- **For migrations and tools** (needed for generating and applying migrations):

  ```bash
  dotnet add package Microsoft.EntityFrameworkCore.Tools
  ```

If you're using another database, like **PostgreSQL** or **SQLite**, you would install the corresponding package.

### 2. **Define Your Models**

A model in EF Core represents a table in the database. You'll define **C# classes** that correspond to tables. For example, if you're building a **User** model, it might look like this:

```csharp
public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}
```

This class will map to a table in your database.

### 3. **Create a DbContext Class**

The **DbContext** class is the central class that manages your models (entities) and interacts with the database. It's similar to the `FakeDb.cs` class you mentioned but instead of holding fake data, it manages access to the real database.

Create a class like this:

```csharp
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}
```

Here, `DbSet<User>` represents the **Users** table in your database.

### 4. **Configure Database Connection (in `appsettings.json`)**

In your `appsettings.json` file, you need to specify the connection string to your real database. For example, if you're using **SQL Server**:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=MyAppDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

- This connection string specifies the **SQL Server LocalDB** instance.
- **Database=MyAppDb** will create a database named `MyAppDb` if it doesn't exist.

If you're using a different database, update the connection string accordingly.

### 5. **Configure `Startup.cs` or `Program.cs` (depending on ASP.NET version)**

Now, you need to tell your application to use this `DbContext` to connect to the real database.

If you're using **ASP.NET Core 5.0 or earlier** (with `Startup.cs`), you would do this in the `ConfigureServices` method of `Startup.cs`:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

    services.AddControllersWithViews();
}
```

If you're using **ASP.NET Core 6.0 or later** (with `Program.cs`), you can add this in the **builder** part of the `Program.cs` file:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
```

This makes the `ApplicationDbContext` available to the rest of your app, allowing you to interact with the database.

### 6. **Create and Apply Migrations**

Migrations are a way to update your database schema (create tables, add columns, etc.) based on your model classes. You can generate and apply migrations to create your real database.

1. **Generate a migration**:
   Open the **Package Manager Console** or use **dotnet CLI** to create a migration. For example:

   ```bash
   Add-Migration InitialCreate
   ```

   This will generate a migration that will create the database tables based on your models.

2. **Apply the migration**:
   After creating the migration, apply it to the database:

   ```bash
   Update-Database
   ```

   This will create the database (if it doesn't already exist) and create the necessary tables according to the models and migrations.

### 7. **Using the Database**

Once the database is created and the tables are in place, you can use the `ApplicationDbContext` to interact with the database, such as querying and saving data.

For example:

```csharp
public class UserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task AddUserAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
}
```

### 8. **Additional Considerations**

- **Seeding Data**: If you want to pre-populate the database with some initial data (like your `FakeDb.cs`), you can seed data during the `Configure` method in `Program.cs`:

  ```csharp
  public static class SeedData
  {
      public static void Initialize(IServiceProvider serviceProvider, ApplicationDbContext context)
      {
          if (!context.Users.Any())
          {
              context.Users.AddRange(
                  new User { Username = "Alice", Password = "password123", Email = "alice@example.com" },
                  new User { Username = "Bob", Password = "password456", Email = "bob@example.com" }
              );
              context.SaveChanges();
          }
      }
  }
  ```

  And call this in `Configure`:

  ```csharp
  SeedData.Initialize(serviceProvider, context);
  ```

- **Database Providers**: If you're using a database other than SQL Server (like PostgreSQL or SQLite), you'll need to install the appropriate EF Core provider (e.g., `Microsoft.EntityFrameworkCore.PostgreSQL`) and update your connection string and options accordingly.

### Summary:

1. Define your models and DbContext class.
2. Configure the connection string in `appsettings.json`.
3. Set up the DbContext in `Startup.cs` or `Program.cs`.
4. Use **EF Core migrations** to create the real database and tables.
5. Use the DbContext in your application to interact with the database.

# Storing Photos in Database (optional)

### 1. **Storing Photos as Binary Data in the Database (BLOB)**

You can save images directly in the database by storing them as **Binary Large Objects (BLOBs)**. A **BLOB** is a data type that allows you to store binary data such as images, videos, or other multimedia files.

#### How it works:

- The image is read as a binary stream (e.g., a byte array) and saved into a field in a table, typically in a column with the BLOB data type.
- When you need to display the image, the binary data is retrieved and converted back into an image format.

#### Example flow:

1. **Convert the image to binary**: When a user uploads a profile picture, it's converted into a binary format (e.g., using base64 encoding).
2. **Store the binary data**: This binary data is then saved into a **BLOB** column in the database.
3. **Retrieve and display the image**: When the image is needed, the binary data is retrieved from the database, and the image is converted back to a usable format for display.

#### Pros:

- Simple if you need to handle a small number of images and want everything in one place.
- It can be secure if stored with access controls, as it's contained within the database.

#### Cons:

- **Database size** can increase significantly, especially if you have a lot of images. This could affect performance.
- **Retrieving images can be slower** compared to retrieving them from a file server.

---

### 2. **Storing Photos as Files and Saving File Paths in the Database**

The more common and efficient approach is to store the images as files on the file system (either on the server or cloud storage) and store **file paths or URLs** in the database. This avoids bloating the database with large binary data.

#### How it works:

1. **Save the image as a file**: When a user uploads a photo (for example, a profile picture), the image is saved in a specific folder or storage location (on the server or in the cloud).
2. **Store the file path or URL**: Instead of saving the image itself in the database, you store the path or URL where the image is located (e.g., `"uploads/profile_pics/john_doe.jpg"`).
3. **Retrieve and display the image**: When you need to show the image, you retrieve the file path or URL from the database and display the image from the file system or cloud storage.

#### Example flow:

1. **User uploads an image**: The system saves the image to a folder on the server (e.g., `uploads/profile_pics/john_doe.jpg`).
2. **Store file path**: The file path (`uploads/profile_pics/john_doe.jpg`) is saved in the **User Table** under the **profile_picture_path** column.
3. **Retrieve file path**: When the user's profile is displayed, the application retrieves the file path from the database and loads the image from the server.

#### Pros:

- **More efficient** and keeps the database size manageable.
- Storing images on file servers or cloud storage (like AWS S3, Google Cloud Storage, etc.) can offer scalability and better performance.
- **Faster** to retrieve and display images, as file systems are optimized for file storage.

#### Cons:

- You need to manage the file storage and ensure it's properly backed up and secured.
- **File paths** could potentially be exposed if the application is not properly secured.

---

### How to Choose Between These Methods:

1. **Storing in the database (BLOB)**: This method is good for small-scale applications where you don't expect many images to be stored, and you want everything in one place. However, it can lead to database bloat and slower performance if used at scale.

2. **Storing as files with file paths in the database**: This is the most common and scalable approach, especially for production environments. It helps keep your database lean and allows for more flexible and efficient image storage. If you use cloud storage like AWS S3 or Google Cloud Storage, you can also make your images easily accessible and scalable.

---

# Asking ChatGPT for Connection between Website and API

### **Key Terminology to Know**

1. **User Authentication (Login System)**

   - **Authentication** is the process of verifying the user's identity. You will need to create a login system where the user provides a username and password.
   - Common terms: **JWT (JSON Web Token)**, **Login Endpoint**, **Password Hashing**, **Token-based Authentication**, **Bearer Token**.

2. **User Authorization (Securing Routes)**

   - **Authorization** ensures that only authenticated users can access certain data or actions.
   - In the context of Web APIs, you might need to use attributes like `[Authorize]` to ensure that only users with valid authentication (a token) can access certain endpoints.
   - Common terms: **Bearer Token Authentication**, **Authorization Header**, **[Authorize] Attribute**, **Role-based Authorization**.

3. **JWT (JSON Web Token)**

   - **JWT** is a compact, URL-safe way to represent claims between two parties. In this case, it’s commonly used to authenticate users after they log in.
   - Common terms: **JWT Token**, **Token Expiry**, **Token Validation**, **Claims** (User information in the token).

4. **Create User (Register New User)**

   - This involves creating a new user in your database with a unique username, email, password, etc.
   - Common terms: **User Registration**, **User Entity**, **Password Hashing** (never store raw passwords).

5. **CRUD Operations for Users**

   - **CRUD** stands for Create, Read, Update, Delete. These are the basic operations that your API will perform on user data.
   - Common terms: **Create User**, **Read User (GetUserById)**, **Update User**, **Delete User**.

6. **Get User Data by ID**

   - After a successful login, you’ll want to retrieve the user’s data by their unique ID, which can be fetched from the **JWT token** or passed as part of the URL.
   - Common terms: **User Profile**, **GetUserById**, **Fetch Data by User ID**.

7. **Password Hashing**

   - You should **never store passwords in plain text**. **Password Hashing** ensures that passwords are securely stored as hashed values, making it difficult for attackers to retrieve the original password.
   - Common terms: **Password Hashing**, **Salt**, **bcrypt**, **Password Hashing Algorithms**.

8. **API Security (Token Verification)**
   - Once the user is authenticated, you’ll verify the token they send in each request to ensure the request is valid.
   - Common terms: **Token Validation**, **Token Expiry**, **Claims Extraction**.

### **What You Need to Achieve**

Here’s a summary of what you’ll likely need to achieve, along with the right terminology for each step:

1. **User Login (Authentication):**

   - Create a **login endpoint** (`POST /api/auth/login`) where the user submits their **username** and **password**.
   - The backend will validate the credentials and return a **JWT token** if they’re correct.
   - Keywords: **Authentication**, **Login Endpoint**, **JWT**, **Bearer Token**.

2. **Secure Routes with Authorization:**

   - After logging in, you’ll need to make further requests to protected endpoints.
   - These endpoints should be **secured** so only authenticated users can access them. This is typically done using **JWT tokens** that the client sends in the `Authorization` header.
   - Keywords: **Authorization Header**, **Bearer Token**, **[Authorize] Attribute**, **Secured API Routes**.

3. **Get User Data by ID (with token verification):**

   - When the authenticated user wants to fetch their profile, you will use the ID (which may be extracted from the **JWT token** or passed in the URL).
   - Keywords: **GetUserById**, **Token Extraction**, **User Profile**, **Get User Data from JWT**.

4. **User Registration (Create New User):**

   - If your app allows users to register (sign up), you’ll need an endpoint like `POST /api/auth/register` where users provide their **username**, **email**, and **password**.
   - After successful registration, they can log in with the credentials they just created.
   - Keywords: **User Registration**, **Create User**, **Password Hashing**, **User Entity**.

5. **Password Hashing:**

   - You need to hash user passwords before saving them in your database.
   - Use a hashing library like **bcrypt** to hash and salt passwords to make them secure.
   - Keywords: **Password Hashing**, **bcrypt**, **Salt**.

6. **Token Expiry & Refresh:**
   - **JWT tokens** can expire after a certain period. You might need to handle **token refreshing** if you want to allow the user to stay logged in beyond the initial token expiry.
   - Keywords: **JWT Expiry**, **Token Refreshing**.

### **How I Can Help**

If the tutorial leaves you stuck or doesn’t go into detail, here are the things you can ask or ask for guidance on:

1. **How to implement user authentication using JWT in ASP.NET Core.**
2. **How to create a login system with username/password and return a JWT token.**
3. **How to secure API routes using JWT tokens and the `[Authorize]` attribute.**
4. **How to extract user data (like the user ID) from a JWT token and use it to get user-specific data.**
5. **How to implement password hashing using libraries like bcrypt in ASP.NET Core.**
6. **How to verify a user’s identity and fetch their data with a `GetUserById` endpoint that requires authentication.**

### Example of What You Might Need

Here’s a simplified code flow of how to structure the logic:

#### 1. **Login Endpoint** (`POST /api/auth/login`)

- **Request**: Username and password from the user.
- **Response**: A JWT token if authentication is successful.

```csharp
[HttpPost("login")]
public IActionResult Login([FromBody] LoginDto loginDto)
{
    var user = _context.Users.SingleOrDefault(u => u.Username == loginDto.Username);
    if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
        return Unauthorized();

    var token = GenerateJwtToken(user);
    return Ok(new { token });
}
```

#### 2. **Secure Profile Endpoint** (`GET /api/users/profile`)

- This route requires the user to be authenticated via the **JWT token**.

```csharp
[HttpGet("profile")]
[Authorize]
public IActionResult GetProfile()
{
    var userId = GetUserIdFromToken(); // Extract ID from JWT token
    var user = _context.Users.Find(userId);
    if (user == null)
        return NotFound();
    return Ok(user);
}
```

### **When You Need Help, Ask About These Topics**:

- **JWT Authentication in ASP.NET Core**
- **Token-based Authentication with JWT**
- **Securing Routes in ASP.NET Core with JWT**
- **Hashing and Salting Passwords in ASP.NET Core**
- **Bearer Token Authentication in Web APIs**
- **Extracting Claims from JWT Token in ASP.NET Core**

### In Summary

Feel free to reach out any time you get stuck. I can guide you step-by-step, provide code snippets, explain concepts, and help troubleshoot. The terminology above should help you frame your questions when you need assistance with **JWT**, **user authentication**, and **secure API routes**.
