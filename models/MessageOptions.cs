public class InteractionOptions
{
  public string Message { get; }
  public string[] Options { get; }
  public InteractionOptions(string message, string[] options)
  {
    Message = message;
    Options = options;
  }

}

public class SimpleMessageOptions
{
  public string Message { get; }

  public SimpleMessageOptions(string message)
  {
    Message = message;
  }
}
