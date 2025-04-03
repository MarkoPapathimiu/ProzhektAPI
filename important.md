#Important
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
4. Display both the user�s info and their favorite workouts.

This structure helps keep the data organized and ensures that each workout and user only needs to be stored once, minimizing redundancy.

---

# Real Database Creation (No FakeDb)

Creating a real database in an ASP.NET Core application using **Entity Framework Core (EF Core)** involves several steps. EF Core is an **Object-Relational Mapper (ORM)** that helps you interact with databases using .NET objects. You�ll define your **models** (classes), create a **DbContext** class to manage these models, and then use **migrations** to create a real database.

Here�s a high-level guide on how to create a real database instead of using a fake in-memory database like `FakeDb.cs`:

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

If you�re using another database, like **PostgreSQL** or **SQLite**, you would install the corresponding package.

### 2. **Define Your Models**

A model in EF Core represents a table in the database. You�ll define **C# classes** that correspond to tables. For example, if you're building a **User** model, it might look like this:

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

The **DbContext** class is the central class that manages your models (entities) and interacts with the database. It�s similar to the `FakeDb.cs` class you mentioned but instead of holding fake data, it manages access to the real database.

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

In your `appsettings.json` file, you need to specify the connection string to your real database. For example, if you�re using **SQL Server**:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=MyAppDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

- This connection string specifies the **SQL Server LocalDB** instance.
- **Database=MyAppDb** will create a database named `MyAppDb` if it doesn�t exist.

If you're using a different database, update the connection string accordingly.

### 5. **Configure `Startup.cs` or `Program.cs` (depending on ASP.NET version)**

Now, you need to tell your application to use this `DbContext` to connect to the real database.

If you�re using **ASP.NET Core 5.0 or earlier** (with `Startup.cs`), you would do this in the `ConfigureServices` method of `Startup.cs`:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

    services.AddControllersWithViews();
}
```

If you�re using **ASP.NET Core 6.0 or later** (with `Program.cs`), you can add this in the **builder** part of the `Program.cs` file:

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
   dotnet ef migrations add InitialCreate
   ```

   This will generate a migration that will create the database tables based on your models.

2. **Apply the migration**:
   After creating the migration, apply it to the database:

   ```bash
   dotnet ef database update
   ```

   This will create the database (if it doesn�t already exist) and create the necessary tables according to the models and migrations.

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

- **Seeding Data**: If you want to pre-populate the database with some initial data (like your `FakeDb.cs`), you can seed data during the `Configure` method in `Startup.cs` (or `Program.cs`):

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

- **Database Providers**: If you�re using a database other than SQL Server (like PostgreSQL or SQLite), you�ll need to install the appropriate EF Core provider (e.g., `Microsoft.EntityFrameworkCore.PostgreSQL`) and update your connection string and options accordingly.

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

1. **Convert the image to binary**: When a user uploads a profile picture, it�s converted into a binary format (e.g., using base64 encoding).
2. **Store the binary data**: This binary data is then saved into a **BLOB** column in the database.
3. **Retrieve and display the image**: When the image is needed, the binary data is retrieved from the database, and the image is converted back to a usable format for display.

#### Pros:

- Simple if you need to handle a small number of images and want everything in one place.
- It can be secure if stored with access controls, as it�s contained within the database.

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
3. **Retrieve file path**: When the user�s profile is displayed, the application retrieves the file path from the database and loads the image from the server.

#### Pros:

- **More efficient** and keeps the database size manageable.
- Storing images on file servers or cloud storage (like AWS S3, Google Cloud Storage, etc.) can offer scalability and better performance.
- **Faster** to retrieve and display images, as file systems are optimized for file storage.

#### Cons:

- You need to manage the file storage and ensure it's properly backed up and secured.
- **File paths** could potentially be exposed if the application is not properly secured.

---

### How to Choose Between These Methods:

1. **Storing in the database (BLOB)**: This method is good for small-scale applications where you don�t expect many images to be stored, and you want everything in one place. However, it can lead to database bloat and slower performance if used at scale.

2. **Storing as files with file paths in the database**: This is the most common and scalable approach, especially for production environments. It helps keep your database lean and allows for more flexible and efficient image storage. If you use cloud storage like AWS S3 or Google Cloud Storage, you can also make your images easily accessible and scalable.

---
