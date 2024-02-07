using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Oy_yO.Data;
using Oy_yO.Repositories;
using Oy_yO.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
    { 
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "Oy-yO v1", Version = "v1" });
        options.AddSignalRSwaggerGen();
    });

builder.Services.AddScoped<IChatRepository, ChatRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
);

//Add SignalR
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHub<ChatHub>("/chatHub");

//define a route to access the hub
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
