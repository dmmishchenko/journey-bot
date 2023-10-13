using Journey.Common.Settings;
using Journey.TelegramBot.Managers;
using Microsoft.Extensions.Options;

namespace Journey.TelegramBot.Management.Managers
{
    public class BotSettingsManager : IBotSettingsManager
    {
        private readonly IOptionsMonitor<TelegramBotSettings> _settings;
        private bool _isOverriden;
        public BotSettingsManager(IOptionsMonitor<TelegramBotSettings> settings)
        {
            _settings = settings;

            //TODO: settings.OnChange switch
        }

        public void EnableWebHook()
        {

        }

        public void EnablePolling()
        {

        }

        public Task SwitchStrategy()
        {
            return Task.CompletedTask;
        }
    }
}
