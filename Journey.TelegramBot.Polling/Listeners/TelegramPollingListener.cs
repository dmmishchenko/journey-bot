using Hangfire;
using Journey.Common.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

namespace Journey.TelegramBot.Polling.Listeners
{
    //pre-alpha, all-in for tests
    public class TelegramPollingListener : ITelegramPollingListener
    {
        private readonly ITelegramBotClient _client;
        private readonly IOptionsMonitor<TelegramReceiverSettings> _recSettings;
        private readonly ILogger<ITelegramPollingListener> _logger;
        private readonly IUpdateHandler _updateHandler;

        public TelegramPollingListener(ITelegramBotClient client,
            IOptionsMonitor<TelegramReceiverSettings> recSettings,
            ILogger<ITelegramPollingListener> logger,
            IUpdateHandler updateHandler)
        {
            _client = client;
            _recSettings = recSettings;
            _logger = logger;
            _updateHandler = updateHandler;
        }

        [AutomaticRetry(Attempts = 0)]
        [Queue(RecurrentTasksConsts.PollingQueueName)]
        public async Task StartPolling()
        {
            //TODO: mapping and updateType separation
            var receiverOptions = new ReceiverOptions()
            {
                AllowedUpdates = Array.Empty<UpdateType>(),
                ThrowPendingUpdates = true,
            };

            var me = await _client.GetMeAsync(CancellationToken.None);
            _logger.LogInformation($"Start receiving updates for {me.Username}");

            await _client.ReceiveAsync(
                updateHandler: _updateHandler,
                receiverOptions: receiverOptions,
                cancellationToken: CancellationToken.None);
        }
    }
}
