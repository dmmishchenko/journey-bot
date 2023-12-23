using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;



namespace Journey.TelegramBot.Polling.Handlers
{
    public class CallbackQueryUpdateHandler : ITelegramUpdateHandler
    {
        private readonly ILogger<CallbackQueryService> _logger;
        private readonly CallbackQueryService _callbackQueryService;
        public CallbackQueryUpdateHandler(ILogger<CallbackQueryService> logger, CallbackQueryService callbackQueryService)
        {
            _logger = logger;
            _callbackQueryService = callbackQueryService;
        }

        public async Task HandleUpdateAsync(Update update, CancellationToken cancellationToken)
        {
                _logger.LogInformation("Received inline keyboard callback from: {CallbackQueryId}", update.CallbackQuery.Id);
                
                await _callbackQueryService.HandleCallbackQueryAsync(update.CallbackQuery, cancellationToken);
        }
    }
}