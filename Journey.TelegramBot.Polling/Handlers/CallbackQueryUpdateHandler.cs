using Telegram.Bot.Types;



namespace Journey.TelegramBot.Polling.Handlers
{
    public class CallbackQueryUpdateHandler : ITelegramUpdateHandler
    {
        private readonly CallbackQueryService _callbackQueryService;
        public CallbackQueryUpdateHandler(CallbackQueryService callbackQueryService)
        {
            _callbackQueryService = callbackQueryService;
        }

        public async Task HandleUpdateAsync(Update update, CancellationToken cancellationToken)
        {
            if (update.CallbackQuery is not null)
            {

                await _callbackQueryService.HandleCallbackQueryAsync(update.CallbackQuery, cancellationToken);
            }
        }


    }





}