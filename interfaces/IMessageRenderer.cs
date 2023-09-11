
interface IMessageRenderer
{
  SimpleMessageResponse RenderMessage(MessageType messageType, SimpleMessageOptions options);
  InteractionResponse RenderMessage(MessageType messageType, InteractionOptions options);
}





