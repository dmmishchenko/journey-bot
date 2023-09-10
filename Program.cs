using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

var token = Environment.GetEnvironmentVariable("TOKEN")!;

// start the bot
var bot = new TelegramBotClient(token);
var renderer = new TelegramMessageRenderer();
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
    var chatId = message.Chat.Id;

    if (message.Entities != null && message.Entities.Any(e => e.Type == MessageEntityType.Hashtag))
    {
      var hashTags = message.Entities
      .Where(entity => entity.Type == MessageEntityType.Hashtag)
      .Select(e => message.Text.Substring(e.Offset, e.Length))
      .ToArray();

      if (hashTags.Any())
      {
        var messageOptions = new InteractionOptions(message: message.Text, options: hashTags);
        var interactionMessage = renderer.RenderMessage(MessageType.Interaction, messageOptions);

        // Create inline keyboard markup
        var inlineKeyboard = new InlineKeyboardMarkup(interactionMessage.Buttons);

        // Create a message with the inline keyboard
        // var message = "Choose an option:";
        await bot.SendTextMessageAsync(chatId, interactionMessage.Message, replyMarkup: inlineKeyboard);
      }
    }

    else
    {
      var messageText = message.Text;
      // Echo the received message back to the user
      await bot.SendTextMessageAsync(chatId, "You said: " + messageText);
    }
  }
}
