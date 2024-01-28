using Hangfire;
using Journey.Common.Extensions;
using Journey.Common.Settings;
using Journey.TelegramBot.Management.Extensions;
using Journey.TelegramBot.Managers;
using Journey.TelegramBot.Polling.Extensions;
using Journey.Users.Database.Extensions;
using JourneyBot.Database.Extensions;
using JourneyBot.Logic.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

// Add services to the container.
var defaultConnection = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddSettings(builder.Configuration);
builder.Services.AddJourneyBotDatabase(defaultConnection);
builder.Services.AddUsersDatabase(defaultConnection);
builder.Services.AddTelegramBotPolling();
builder.Services.AddBotManagers();
builder.Services.AddHangfireServer(optionsAction =>
{
    optionsAction.WorkerCount = RecurrentTasksConsts.MainAppWorkersCount;

    optionsAction.Queues = new[]
    {
        RecurrentTasksConsts.PollingQueueName
    };
    optionsAction.ServerName = "Main";
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLogic(builder.Configuration);
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseHangfireDashboard();

app.MapDefaultControllerRoute();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

var manager = app.Services.GetService<IBotStrategyManager>();

manager.StartPolling();
//manager with listeners by type!

app.Run();

