using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;



namespace Journey.TelegramBot.Polling.Handlers
{
    /// <summary>
    /// Handler for result of users request to bot with '@' markings
    /// </summary>
    public class ChosenInlineResultUpdateHandler : ITelegramUpdateHandler
    {
        private readonly ILogger<ChosenInlineResultUpdateHandler> _logger;
        private readonly ChosenInlineResultService _chosenInlineResultService;
        public ChosenInlineResultUpdateHandler(ChosenInlineResultService chosenInlineResultService, ILogger<ChosenInlineResultUpdateHandler> logger)
        {
            _logger = logger;
            _chosenInlineResultService = chosenInlineResultService;
        }

        public async Task HandleUpdateAsync(Update update, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Received inline result: {ChosenInlineResultId}", update.ChosenInlineResult.ResultId);

            await _chosenInlineResultService.HandleChosenInlineResultAsync(update.ChosenInlineResult, cancellationToken);
        }
    }
}