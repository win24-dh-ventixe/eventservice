using Microsoft.EntityFrameworkCore;
using Presentation.Data;
using Presentation.Models;
using Presentation.Services;

var builder = WebApplication.CreateBuilder(args);


// Register core services (controllers, database, business logic)
builder.Services.AddControllers();

builder.Services.AddDbContext<EventDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IEventService, EventService>();

// Enable Swagger for API documentation and testing
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});


var app = builder.Build();

// Seed one sample event if database is empty (used for testing/demo)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<EventDbContext>();

    if (!context.Events.Any())
    {
        context.Events.Add(new EventEntity
        {
            Title = "Initialdata",
            Description = "Läggs till en gång",
            Start = DateTime.UtcNow.AddDays(1),
            End = DateTime.UtcNow.AddDays(1).AddHours(2),
            Location = "Etern",
            Price = 299.00m
        });

        context.SaveChanges();
    }
}


// Enable Swagger UI in development mode
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();


app.Run();