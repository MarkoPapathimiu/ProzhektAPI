using Microsoft.EntityFrameworkCore;
using ProzhektAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Connection String
var connectionString = "Server=DESKTOP-BDSCUK9\\SQLEXPRESS;Database=FitnessTrackingDb;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;";

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(connectionString));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
