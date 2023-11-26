using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;



namespace Journey.TelegramBot.Polling.Handlers
{
    public class EditedMessageUpdateHandler : ITelegramUpdateHandler
    {
        private readonly ILogger<EditedMessageUpdateHandler> _logger;
        private readonly MessageService _messageService;
        public EditedMessageUpdateHandler(MessageService messageService, ILogger<EditedMessageUpdateHandler> logger)
        {
            _logger = logger;
            _messageService = messageService;
        }

        public async Task HandleUpdateAsync(Update update, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Receive message type: {MessageType}", update.Type);

            await _messageService.BotOnMessageReceived(update.EditedMessage, cancellationToken);
        }
    }
}