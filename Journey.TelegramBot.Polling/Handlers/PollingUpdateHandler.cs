using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;

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


        public PollingUpdateHandler(
        ILogger<PollingUpdateHandler> logger,
        ITelegramBotClient client,
        MessageUpdateHandler messageUpdateHandler,
        CallbackQueryUpdateHandler callbackQueryUpdateHandler,
        InlineQueryUpdateHandler inlineQueryUpdateHandler,
        ChosenInlineResultUpdateHandler chosenInlineResultUpdateHandler
        )
        {
            _logger = logger;
            _client = client;
            _messageUpdateHandler = messageUpdateHandler;
            _callbackQueryUpdateHandler = callbackQueryUpdateHandler;
            _inlineQueryUpdateHandler = inlineQueryUpdateHandler;
            _chosenInlineResultUpdateHandler = chosenInlineResultUpdateHandler;
        }

        public async Task HandleUpdateAsync(ITelegramBotClient _, Update update, CancellationToken cancellationToken)
        {
            await _messageUpdateHandler.HandleUpdateAsync(update, cancellationToken);
            await _callbackQueryUpdateHandler.HandleUpdateAsync(update, cancellationToken);
            await _inlineQueryUpdateHandler.HandleUpdateAsync(update, cancellationToken);
            await _chosenInlineResultUpdateHandler.HandleUpdateAsync(update, cancellationToken);
            await UnknownUpdateHandlerAsync(update, cancellationToken);
        }

        private async Task BotOnChosenInlineResultReceived(ChosenInlineResult chosenInlineResult, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Received inline result: {ChosenInlineResultId}", chosenInlineResult.ResultId);

            await _client.SendTextMessageAsync(
                chatId: chosenInlineResult.From.Id,
                text: $"You chose result with Id: {chosenInlineResult.ResultId}",
                cancellationToken: cancellationToken);
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
