using Telegram.Bot;

namespace Journey.TelegramBot.Polling.Client
{
    public class JourneyTelegramClient
    {
        private readonly HttpClient _http;
        private readonly ITelegramBotClient _tgClient;

        public JourneyTelegramClient(HttpClient http, ITelegramBotClient tgClient)
        {
            _http = http;
            _tgClient = tgClient;
        }

        public async Task SendText()
        {
            await _tgClient.SendTextMessageAsync(2345, "kappa");
        }
    }
}
