namespace Journey.TelegramBot.Strategies
{
    public interface IBotStrategy
    {
        void Init();
        void Stop();//move both init and stop usage to activation and deactivation services respectivly
    }
}
