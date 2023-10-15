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
            try
            {
                var receiverOptions = new ReceiverOptions()
                {
                    AllowedUpdates = new UpdateType[]
                    {
                        UpdateType.Message,
                        UpdateType.InlineQuery,
                        UpdateType.ChatJoinRequest,
                        UpdateType.PollAnswer
                    },
                    ThrowPendingUpdates = true
                };

                var me = await _client.GetMeAsync(CancellationToken.None);
                _logger.LogInformation($"Start receiving updates for {me.Username}");

                await _client.ReceiveAsync(
                    updateHandler: _updateHandler,
                    receiverOptions: receiverOptions,
                    cancellationToken: CancellationToken.None);
            }
            catch
            {
                var id = BackgroundJob.Enqueue<ITelegramPollingListener>(queue: RecurrentTasksConsts.PollingQueueName, u => u.StartPolling());
                _logger.LogInformation($"hangfire: Error in polling process, new process was enqueued, id: {id}");
            }
            finally
            {
                _logger.LogError($"Hangfire: {nameof(TelegramPollingListener)}.{nameof(StartPolling)} method was finished, see logs for information");
            }
            //TODO: mapping and updateType separation
        }
    }
}
