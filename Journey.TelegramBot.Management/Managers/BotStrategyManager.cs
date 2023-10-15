using Journey.TelegramBot.Management.Strategies;
using Journey.TelegramBot.Managers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Journey.TelegramBot.Management.Managers
{
    public class BotStrategyManager : IBotStrategyManager
    {
        private readonly ILogger<IBotSettingsManager> _logger;
        private readonly IBotSettingsManager _settingsManager;
        private readonly IServiceProvider _serviceContainer;

        public BotStrategyManager(ILogger<IBotSettingsManager> logger,
            IBotSettingsManager settingsManager,
            IServiceProvider serviceContainer)
        {
            _logger = logger;
            _settingsManager = settingsManager;
            _serviceContainer = serviceContainer;
        }

        public void StartPolling()
        {
            using var scope = _serviceContainer.CreateScope();
            var service = scope.ServiceProvider.GetService<PollingStrategy>();
            service.Init();
            _logger.LogTrace($"{nameof(BotSettingsManager)}: Start polling");
        }
    }
}
