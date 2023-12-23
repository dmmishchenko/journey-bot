using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;



namespace Journey.TelegramBot.Polling.Handlers
{
    public class PollingUpdateHandler : IUpdateHandler
    {
        private readonly ILogger<PollingUpdateHandler> _logger;
        private readonly ITelegramBotClient _client;
        private readonly MessageUpdateHandler _messageUpdateHandler;
        private readonly CallbackQueryUpdateHandler _callbackQueryUpdateHandler;
        private readonly InlineQueryUpdateHandler _inlineQueryUpdateHandler;
        private readonly ChosenInlineResultUpdateHandler _chosenInlineResultUpdateHandler;
        private readonly EditedMessageUpdateHandler _editMessageUpdateHandler;


        public PollingUpdateHandler(
        ILogger<PollingUpdateHandler> logger,
        ITelegramBotClient client,
        MessageUpdateHandler messageUpdateHandler,
        EditedMessageUpdateHandler editedMessageUpdateHandler,
        CallbackQueryUpdateHandler callbackQueryUpdateHandler,
        InlineQueryUpdateHandler inlineQueryUpdateHandler,
        ChosenInlineResultUpdateHandler chosenInlineResultUpdateHandler
        )
        {
            _logger = logger;
            _client = client;
            _messageUpdateHandler = messageUpdateHandler;
            _editMessageUpdateHandler = editedMessageUpdateHandler;
            _callbackQueryUpdateHandler = callbackQueryUpdateHandler;
            _inlineQueryUpdateHandler = inlineQueryUpdateHandler;
            _chosenInlineResultUpdateHandler = chosenInlineResultUpdateHandler;
        }

        public async Task HandleUpdateAsync(ITelegramBotClient _, Update update, CancellationToken cancellationToken)
        {
            switch (update.Type)
            {
                case UpdateType.Message:
                    await _messageUpdateHandler.HandleUpdateAsync(update, cancellationToken);
                    break;
                case UpdateType.EditedMessage:
                    await _editMessageUpdateHandler.HandleUpdateAsync(update, cancellationToken);
                    break;
                case UpdateType.CallbackQuery:
                    await _callbackQueryUpdateHandler.HandleUpdateAsync(update, cancellationToken);
                    break;
                case UpdateType.InlineQuery:
                    await _inlineQueryUpdateHandler.HandleUpdateAsync(update, cancellationToken);
                    break;
                case UpdateType.ChosenInlineResult:
                    await _chosenInlineResultUpdateHandler.HandleUpdateAsync(update, cancellationToken);
                    break;
                default:
                    await UnknownUpdateHandlerAsync(update, cancellationToken);
                    break;
            }

        }

        private Task UnknownUpdateHandlerAsync(Update update, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Unknown update type: {UpdateType}", update.Type);
            return Task.CompletedTask;
        }

        public async Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            _logger.LogInformation("HandleError: {ErrorMessage}", ErrorMessage);

            // Cooldown in case of network connection error
            if (exception is RequestException)
                await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
        }
    }
}
