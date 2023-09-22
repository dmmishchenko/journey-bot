using JourneyBot.Common.Enums;
using JourneyBot.Datamodel.Models;
using JourneyBot.Logic.Interfaces;

namespace JourneyBot.Logic.Services
{
    public class TelegramMessageRenderer : IMessageRenderer
    {
        public SimpleMessageResponse RenderMessage(InternalMessageType messageType, SimpleMessageOptions options)
        {
            return new SimpleMessageResponse(message: options.Message);
        }

        public InteractionResponse RenderMessage(InternalMessageType messageType, InteractionOptions options)
        {
            return new InteractionResponse(message: options.Message, options: options.Options);
        }
    }
}