class TelegramMessageRenderer : IMessageRenderer
{
  public SimpleMessageResponse RenderMessage(MessageType messageType, SimpleMessageOptions options)
  {
    return new SimpleMessageResponse(message: options.Message);
  }

  public InteractionResponse RenderMessage(MessageType messageType, InteractionOptions options)
  {
    return new InteractionResponse(message: options.Message, options: options.Options);
  }
}