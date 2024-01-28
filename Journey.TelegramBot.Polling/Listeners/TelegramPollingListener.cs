using Hangfire;
using Hangfire.Server;
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

        public async Task RemovePolling()
        {
            RecurringJob.RemoveIfExists(RecurrentTasksConsts.PollingTaskJobId);
        }

        public async Task StartPolling(CancellationToken token, PerformContext context)
        {
            try
            {
                var receiverOptions = new ReceiverOptions()
                {
                    AllowedUpdates = new UpdateType[]
                    {
                        UpdateType.Message,
                        UpdateType.ChatJoinRequest,
                        UpdateType.MyChatMember,
                        UpdateType.EditedMessage,
                        UpdateType.InlineQuery,
                        UpdateType.ChatJoinRequest,
                        UpdateType.PollAnswer
                    },
                    ThrowPendingUpdates = true
                };

                var me = await _client.GetMeAsync(token);
                _logger.LogInformation($"Start receiving updates for {me.Username}");

                await _client.ReceiveAsync(
                    updateHandler: _updateHandler,
                    receiverOptions: receiverOptions,
                    cancellationToken: token);
            }
            catch(Exception ex)
            {
                _logger.LogInformation($"Hangfire: Error in polling process, process restart will be enqueued. Exception: {ex}");
            }
            finally
            {
                _logger.LogError($"Hangfire: {nameof(TelegramPollingListener)}.{nameof(StartPolling)} method was finished, see logs for information");
                BackgroundJob.Delete(context.BackgroundJob.Id);
                BackgroundJob.Enqueue<ITelegramPollingListener>(u => u.StartPolling(CancellationToken.None, null));
            }
        }
    }
}
