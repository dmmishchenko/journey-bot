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
  public string[] Options { get; }

  public InteractionResponse(string message, string[] options)
  {
    Message = message;
    Options = options;
  }
}