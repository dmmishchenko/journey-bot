using Microsoft.Extensions.Logging;

namespace Journey.TelegramBot.Managers
{
    public class BotStrategyManager : IBotStrategyManager
    {
        private readonly ILogger<IBotSettingsManager> _logger;
        private readonly IBotSettingsManager _settingsManager;

        public BotStrategyManager(ILogger<IBotSettingsManager> logger, IBotSettingsManager settingsManager)
        {
            _logger = logger;
            _settingsManager = settingsManager;
        }

        public Task SwitchStrategy()
        {
            return Task.CompletedTask;
        }
    }
}
