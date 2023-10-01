using Hangfire;
using Journey.Common.Api;
using Journey.Common.Settings;
using Journey.TelegramBot.Polling.Listeners;
using JourneyBot.Common.Enums;
using JourneyBot.Datamodel.Models;
using JourneyBot.Forms.JourneyBot;
using JourneyBot.Logic.Interfaces;
using JourneyBot.Logic.Services.JourneyBot;
using Microsoft.AspNetCore.Mvc;

namespace JourneyBot.Web.Controllers.JourneyBot
{
    public class JourneyBotController : ControllerBase
    {
        private readonly IMessageRenderer _messager;
        private readonly IJourneyBotMessagesService _messagesService;
        private readonly ITelegramPollingListener _listener;

        public JourneyBotController(IMessageRenderer messager, IJourneyBotMessagesService messagesService, ITelegramPollingListener listener)
        {
            _messager = messager;
            _messagesService = messagesService;
            _listener = listener;
        }

        [HttpGet]
        public SimpleMessageResponse GetTestMessage()
        {
            var option = new SimpleMessageOptions("Hello");

            return _messager.RenderMessage(InternalMessageType.SimpleMessage, option);
        }

        [HttpPost]
        public async Task<ServerResult<bool>> PostMessage([FromBody] JourneyBotMessageForm form)
        {
            var result = await _messagesService.AddMessage(form);

            return result;
        }
        [HttpPost("[action]")]
        public async Task<ServerResult<bool>> PostUsersMessage([FromBody] JourneyBotUsersMessageForm form)
        {
            return ServerResults.CachedTrue;
        }

        [HttpPost("[action]")]
        public async Task<ServerResult<bool>> StartBotListenerTest()
        {
            RecurringJob.AddOrUpdate<ITelegramPollingListener>(RecurrentTasksConsts.PollingTaskJobId, u => u.StartPolling(), RecurrentTasksConsts.Every30SecondsCron);

            return ServerResults.CachedTrue;
        }

        [HttpPost("[action]")]
        public async Task<ServerResult<bool>> StopBotListenerTest()
        {
            RecurringJob.RemoveIfExists(RecurrentTasksConsts.PollingTaskJobId);

            return ServerResults.CachedTrue;
        }
    }
}
