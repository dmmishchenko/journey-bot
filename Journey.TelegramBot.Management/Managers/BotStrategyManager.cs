using Journey.TelegramBot.Management.Strategies;
using Journey.TelegramBot.Managers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.ComponentModel.Design;

namespace Journey.TelegramBot.Management.Managers
{
    public class BotStrategyManager : IBotStrategyManager
    {
        private readonly ILogger<IBotSettingsManager> _logger;
        private readonly IBotSettingsManager _settingsManager;
        private readonly IServiceContainer _serviceContainer;

        public BotStrategyManager(ILogger<IBotSettingsManager> logger,
            IBotSettingsManager settingsManager,
            IServiceContainer serviceContainer)
        {
            _logger = logger;
            _settingsManager = settingsManager;
            _serviceContainer = serviceContainer;
        }

        public void StartPolling()
        {
            using var scope = _serviceContainer.CreateScope();
            var service = scope.ServiceProvider.GetService<PollingStrategy>();
            _logger.LogTrace($"Start polling");
            service.Init();
        }
    }
}
