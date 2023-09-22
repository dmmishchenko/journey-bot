using Journey.Common.Api;
using JourneyBot.Common.Enums;
using JourneyBot.Datamodel.Models;
using JourneyBot.Forms.JourneyBot;
using JourneyBot.Logic.Interfaces;
using JourneyBot.Logic.Services;
using JourneyBot.Logic.Services.JourneyBot;
using Microsoft.AspNetCore.Mvc;

namespace JourneyBot.Web.Controllers.JourneyBot
{
    public class JourneyBotController : ControllerBase
    {
        private readonly IMessageRenderer _messager;
        private readonly IJourneyBotMessagesService _messagesService;

        public JourneyBotController(IMessageRenderer messager, IJourneyBotMessagesService messagesService)
        {
            _messager = messager;
            _messagesService = messagesService;
        }

        [HttpGet]
        public SimpleMessageResponse GetMessage()
        {
            var option = new SimpleMessageOptions("Hello");

            return _messager.RenderMessage(InternalMessageType.SimpleMessage, option);
        }

        [HttpPost]
        public async Task<ServerResult<bool>> PostMessage([FromBody]JourneyBotMessageForm form)
        {
            var result = await _messagesService.AddMessage(form);

            return result;
        }
    }
}
