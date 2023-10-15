using Hangfire;
using Journey.Common.Api;
using Journey.Common.Settings;
using Journey.TelegramBot.Management.Managers;
using Journey.TelegramBot.Managers;
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
        private readonly IBotStrategyManager _botStrategyManager;

        public JourneyBotController(IMessageRenderer messager,
            IJourneyBotMessagesService messagesService,
            IBotStrategyManager botStrategyManager)
        {
            _messager = messager;
            _messagesService = messagesService;
            _botStrategyManager = botStrategyManager;
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
            _botStrategyManager.StartPolling();

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
