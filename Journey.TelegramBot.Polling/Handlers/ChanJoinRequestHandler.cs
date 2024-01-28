using Telegram.Bot.Types;

namespace Journey.TelegramBot.Polling.Handlers
{
    /// <summary>
    /// Handler for request for joining channel or chat with bot
    /// </summary>
    internal class ChanJoinRequestHandler : ITelegramUpdateHandler
    {
        public ChanJoinRequestHandler()
        {

        }

        public Task HandleUpdateAsync(Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
