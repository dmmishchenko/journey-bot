using JourneyBot.Logic.Interfaces;
using JourneyBot.Logic.Services;
using Microsoft.Extensions.Configuration;
using JourneyBot.Database.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

// Add services to the container.
var defaultConnection = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddJourneyBotDatabase(defaultConnection);
builder.Services.AddRazorPages();
builder.Services.AddScoped<IMessageRenderer, TelegramMessageRenderer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
