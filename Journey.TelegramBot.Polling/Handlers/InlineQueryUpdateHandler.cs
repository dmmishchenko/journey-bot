using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;



namespace Journey.TelegramBot.Polling.Handlers
{
    /// <summary>
    /// Handler for user request to bot with '@' markings
    /// </summary>
    public class InlineQueryUpdateHandler : ITelegramUpdateHandler
    {
        private readonly ILogger<InlineQueryService> _logger;
        private readonly InlineQueryService _inlineQueryService;
        public InlineQueryUpdateHandler(InlineQueryService inlineQueryService, ILogger<InlineQueryService> logger)
        {
            _logger = logger;
            _inlineQueryService = inlineQueryService;
        }

        public async Task HandleUpdateAsync(Update update, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Received inline query from: {InlineQueryFromId}", update.InlineQuery.From.Id);

            await _inlineQueryService.HandleInlineQueryAsync(update.InlineQuery, cancellationToken);
        }
    }
}