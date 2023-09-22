using Journey.Common.Api;
using JourneyBot.Database.Context;
using JourneyBot.Datamodel.Database.Context;
using JourneyBot.Forms.JourneyBot;

namespace JourneyBot.Logic.Services.JourneyBot
{
    public class JourneyBotMessagesService : IJourneyBotMessagesService
    {
        private readonly JourneyBotContext _botDc;

        public JourneyBotMessagesService(JourneyBotContext botDc)
        {
            _botDc = botDc;
        }

        public async Task<ServerResult<bool>> AddMessage(JourneyBotMessageForm form)
        {
            var entity = _botDc.BotMessages.Add(new JourneyBotMessageDbModel
            {
                DateTime = DateTimeOffset.UtcNow,
                IsCommand = false,
                Text = form.Text,
            }).Entity;

            await _botDc.SaveChangesAsync();

            return entity.Id > 0;
        }
    }
}
