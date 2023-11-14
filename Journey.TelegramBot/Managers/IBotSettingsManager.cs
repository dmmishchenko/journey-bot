namespace Journey.TelegramBot.Managers
{
    public interface IBotSettingsManager
    {
        void EnablePolling();
        void EnableWebHook();
        Task SwitchStrategy();
    }
}