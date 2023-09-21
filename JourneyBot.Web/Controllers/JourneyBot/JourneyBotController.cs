using JourneyBot.Common.Enums;
using JourneyBot.Datamodel.Models;
using JourneyBot.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace JourneyBot.Web.Controllers.JourneyBot
{
    [ApiController]
    public class JourneyBotController : ControllerBase
    {
        private readonly TelegramMessageRenderer _messager;
        public JourneyBotController(TelegramMessageRenderer messager)
        {
            _messager = messager;
        }

        public SimpleMessageResponse SendResponse()
        {
            var option = new SimpleMessageOptions("Hello");

            return _messager.RenderMessage(InternalMessageType.SimpleMessage, option);
        }
    }
}
