using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Types;

public class ChosenInlineResultService
{
    private readonly ILogger<ChosenInlineResultService> _logger;
    private readonly ITelegramBotClient _client;

    public ChosenInlineResultService(ILogger<ChosenInlineResultService> logger, ITelegramBotClient client)
    {
        _logger = logger;
        _client = client;
    }

    // BotOnChosenInlineResultReceived
    public async Task HandleChosenInlineResultAsync(ChosenInlineResult chosenInlineResult, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Received inline result: {ChosenInlineResultId}", chosenInlineResult.ResultId);

        await _client.SendTextMessageAsync(
            chatId: chosenInlineResult.From.Id,
            text: $"You chose result with Id: {chosenInlineResult.ResultId}",
            cancellationToken: cancellationToken);
    }
}