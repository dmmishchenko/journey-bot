using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JourneyBot.Web.Controllers.Users
{
    public class UsersController : ControllerBase
    {
        public UsersController()
        {

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<string> Test()
        {
            return "Test completed";
        }
    }
}
