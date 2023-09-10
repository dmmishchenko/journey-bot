using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

var token = Environment.GetEnvironmentVariable("TOKEN")!;


// start the bot
var bot = new TelegramBotClient(token);
var me = await bot.GetMeAsync();
using var cts = new CancellationTokenSource();
bot.StartReceiving(HandleUpdateAsync, PollingErrorHandler, null, cts.Token);

Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadLine();

// stop the bot
cts.Cancel();

Task PollingErrorHandler(ITelegramBotClient bot, Exception ex, CancellationToken ct)
{
  Console.WriteLine($"Exception while polling for updates: {ex}");
  return Task.CompletedTask;
}

async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken ct)
{
  try
  {
    await (update.Type switch
    {
      UpdateType.Message => BotMessageReceived(bot, update.Message),
      _ => Task.CompletedTask
    });
  }
#pragma warning disable CA1031
  catch (Exception ex)
  {
    Console.WriteLine($"Exception while handling {update.Type}: {ex}");
  }
#pragma warning restore CA1031
}

async Task BotMessageReceived(ITelegramBotClient bot, Message? message)
{
  if (message != null && message.Text != null)
  {
    if (message.Entities != null && message.Entities.Any(e => e.Type == MessageEntityType.Hashtag))
    {
      var hashTags = message.Entities
      .Where(entity => entity.Type == MessageEntityType.Hashtag)
      .Select(e => message.Text.Substring(e.Offset, e.Length));

      if(hashTags.Any()){
        // return 
      }


    }
    var chatId = message.Chat.Id;
    var messageText = message.Text;

    // Echo the received message back to the user
    await bot.SendTextMessageAsync(chatId, "You said: " + messageText);
  }
}