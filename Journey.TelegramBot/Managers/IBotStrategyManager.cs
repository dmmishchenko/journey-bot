namespace Journey.TelegramBot.Managers
{
    public interface IBotStrategyManager
    {
        void StartPolling();//move this out
        Task SwitchStrategy();
    }
}