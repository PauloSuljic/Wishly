using Microsoft.EntityFrameworkCore;
using WishlistService.Data;

var builder = WebApplication.CreateBuilder(args);

// Configure the DbContext for SQL Server (or any database you're using)
builder.Services.AddDbContext<WishlistDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllers();
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
