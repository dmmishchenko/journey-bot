using Hangfire;
using Journey.Common.Settings;
using Journey.TelegramBot.Polling.Listeners.Interfaces;

namespace Journey.TelegramBot.Polling.Listeners
{
    public interface ITelegramPollingListener : IListener
    {
        [AutomaticRetry(Attempts = 0)]
        [Queue(RecurrentTasksConsts.PollingQueueName)]
        Task StartPolling();
    }
}