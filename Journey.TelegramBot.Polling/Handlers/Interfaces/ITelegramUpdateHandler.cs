using Telegram.Bot.Types;



public interface ITelegramUpdateHandler
{
    Task HandleUpdateAsync(Update update, CancellationToken cancellationToken);
}
