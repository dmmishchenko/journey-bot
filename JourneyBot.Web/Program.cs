using Journey.Users.Database.Extensions;
using JourneyBot.Database.Extensions;
using JourneyBot.Logic.Extensions;
using JourneyBot.Logic.Interfaces;
using JourneyBot.Logic.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

// Add services to the container.
var defaultConnection = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddJourneyBotDatabase(defaultConnection);
builder.Services.AddUsersDatabase(defaultConnection);
builder.Services.AddLogic();
builder.Services.AddRazorPages();

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
app.MapDefaultControllerRoute();

app.Run();
