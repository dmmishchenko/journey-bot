using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Types;



public class CallbackQueryService
{
    private readonly ILogger<CallbackQueryService> _logger;
    private readonly ITelegramBotClient _client;

    public CallbackQueryService(ILogger<CallbackQueryService> logger, ITelegramBotClient client)
    {
        _logger = logger;
        _client = client;
    }

// BotOnCallbackQueryReceived
    public async Task HandleCallbackQueryAsync(CallbackQuery callbackQuery, CancellationToken cancellationToken)
    {
        await _client.AnswerCallbackQueryAsync(
            callbackQueryId: callbackQuery.Id,
            text: $"Received {callbackQuery.Data}",
            cancellationToken: cancellationToken);

        await _client.SendTextMessageAsync(
            chatId: callbackQuery.Message!.Chat.Id,
            text: $"Received {callbackQuery.Data}",
            cancellationToken: cancellationToken);
    }
}

