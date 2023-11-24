using Telegram.Bot.Types;



namespace Journey.TelegramBot.Polling.Handlers
{
    public class MessageUpdateHandler : ITelegramUpdateHandler
    {
        private readonly MessageService _messageService;

        public MessageUpdateHandler(MessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task HandleUpdateAsync(Update update, CancellationToken cancellationToken)
        {
            if (update.Message is not null)
            {
                await _messageService.BotOnMessageReceived(update.Message, cancellationToken);
            }
            if (update.EditedMessage is not null)
            {
                await _messageService.BotOnMessageReceived(update.EditedMessage, cancellationToken);
            }
        }

    }




}