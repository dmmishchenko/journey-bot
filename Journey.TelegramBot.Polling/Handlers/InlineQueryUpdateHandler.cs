using Telegram.Bot.Types;



namespace Journey.TelegramBot.Polling.Handlers
{
    public class InlineQueryUpdateHandler : ITelegramUpdateHandler
    {
        private readonly InlineQueryService _inlineQueryService;
        public InlineQueryUpdateHandler(InlineQueryService inlineQueryService)
        {
            _inlineQueryService = inlineQueryService;
        }

        public async Task HandleUpdateAsync(Update update, CancellationToken cancellationToken)
        {
            if (update.InlineQuery is not null)
            {
                await _inlineQueryService.HandleInlineQueryAsync(update.InlineQuery, cancellationToken);
            }
        }


    }





}