using Journey.Common.Api;
using JourneyBot.Forms.JourneyBot;

namespace JourneyBot.Logic.Services.JourneyBot
{
    public interface IJourneyBotMessagesService
    {
        Task<ServerResult<bool>> AddMessage(JourneyBotMessageForm form);
    }
}