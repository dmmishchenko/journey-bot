using Journey.Common.Settings;
using Microsoft.Extensions.Options;

namespace Journey.TelegramBot.Managers
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
    }
}
