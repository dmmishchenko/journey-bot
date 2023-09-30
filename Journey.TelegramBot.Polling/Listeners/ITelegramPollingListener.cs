using Journey.TelegramBot.Polling.Listeners.Interfaces;

namespace Journey.TelegramBot.Polling.Listeners
{
    public interface ITelegramPollingListener : IListener
    {
        Task StartPolling();
    }
}