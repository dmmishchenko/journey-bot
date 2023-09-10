using Telegram.Bot.Types.ReplyMarkups;

public class SimpleMessageResponse
{
  public string Message { get; }

  public SimpleMessageResponse(string message)
  {
    Message = message;
  }
}


public class InteractionResponse
{
  public string Message { get; }
  public IEnumerable<InlineKeyboardButton> Buttons { get; }

  public InteractionResponse(string message, string[] options)
  {
    Message = message;
    Buttons = options.Select(o => InlineKeyboardButton.WithCallbackData(o));
  }
}