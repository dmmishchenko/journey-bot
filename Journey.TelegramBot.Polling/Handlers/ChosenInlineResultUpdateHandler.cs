using Telegram.Bot.Types;



namespace Journey.TelegramBot.Polling.Handlers
{
        public class ChosenInlineResultUpdateHandler : ITelegramUpdateHandler
    {
        private readonly ChosenInlineResultService _chosenInlineResultService;
        public ChosenInlineResultUpdateHandler(ChosenInlineResultService chosenInlineResultService)
        {
            _chosenInlineResultService = chosenInlineResultService;
        }

        public async Task HandleUpdateAsync(Update update, CancellationToken cancellationToken)
        {
            if (update.ChosenInlineResult is not null)
            {
                await _chosenInlineResultService.HandleChosenInlineResultAsync(update.ChosenInlineResult, cancellationToken);
            }
        }


    }
}