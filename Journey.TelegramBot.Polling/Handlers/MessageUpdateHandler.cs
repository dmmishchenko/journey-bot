using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;



namespace Journey.TelegramBot.Polling.Handlers
{
    public class MessageUpdateHandler : ITelegramUpdateHandler
    {
        private readonly ILogger<MessageUpdateHandler> _logger;
        private readonly MessageService _messageService;
        public MessageUpdateHandler(MessageService messageService, ILogger<MessageUpdateHandler> logger)
        {
            _logger = logger;
            _messageService = messageService;
        }

        public async Task HandleUpdateAsync(Update update, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Receive message type: {MessageType}", update.Type);
            
            await _messageService.BotOnMessageReceived(update.Message, cancellationToken);
        }
    }
}