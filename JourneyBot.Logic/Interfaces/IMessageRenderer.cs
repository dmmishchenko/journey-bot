using JourneyBot.Common.Enums;
using JourneyBot.Datamodel.Models;

namespace JourneyBot.Logic.Interfaces
{
    public interface IMessageRenderer
    {
        SimpleMessageResponse RenderMessage(InternalMessageType messageType, SimpleMessageOptions options);
        InteractionResponse RenderMessage(InternalMessageType messageType, InteractionOptions options);
    }
}