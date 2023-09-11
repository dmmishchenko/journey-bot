using JourneyBot.Common.Enums;
using JourneyBot.Datamodel.Models;

namespace JourneyBot.Logic.Interfaces
{
    interface IMessageRenderer
    {
        SimpleMessageResponse RenderMessage(MessageType messageType, SimpleMessageOptions options);
        InteractionResponse RenderMessage(MessageType messageType, InteractionOptions options);
    }
}