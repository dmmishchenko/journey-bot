using Telegram.Bot.Types;

namespace Journey.TelegramBot.Polling.Handlers
{
    /// <summary>
    /// Handler for private operations with bot (private user-bot messages)
    /// </summary>
    internal class ChatMemberHandler : ITelegramUpdateHandler
    {
        public ChatMemberHandler()
        {

        }

        public Task HandleUpdateAsync(Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
