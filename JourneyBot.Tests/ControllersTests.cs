using JourneyBot.Web.Controllers.Users;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace JourneyBot.Tests
{
    [TestFixture]
    public class ControllersTests
    {
        private const string url = "http://localhost:4811/";

        [Test]
        public async Task SimpleTest_RequestToRunningApplication_Success()
        {
            string method = "Users/Test";
            string finalUrl = url + method;

            using var httpClinet = new HttpClient();

            using var response = await httpClinet.GetAsync(finalUrl);

            string result = await response.Content.ReadAsStringAsync();

            ClassicAssert.AreEqual("Test completed", result, "Test for message from User controller failed, see messeges");
        }

        [Test]
        public async Task SimpleTest_UnitTestOfClass_Success()
        {
            UsersController controller = new UsersController();
            string result = await controller.Test();

            ClassicAssert.AreEqual("Test completed", result, "Test for message from User controller failed, see messeges");
        }
    }
}
