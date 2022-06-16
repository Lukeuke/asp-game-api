using Application.Models;
using Application.PlayerData;
using Application.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var settings = new Settings();
builder.Configuration.Bind("Settings", settings);
builder.Services.AddSingleton(settings);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<GameService>();

builder.Services.AddDbContextPool<PlayerContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("GuessWordConnectionString")));

builder.Services.AddScoped<IPlayerData, PlayerData>();

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