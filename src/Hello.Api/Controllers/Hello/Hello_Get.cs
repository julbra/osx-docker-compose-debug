using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hello.Api.Controllers.Hello
{
    public partial class HelloController
    {
        [HttpGet(Routes.Hello, Name = RouteNames.Hello)]
        public ActionResult SayHello()
        {
            _logger.LogInformation("Hello Controller GET");
            return new ContentResult() { Content = "Hello World!" };
        }
    }
}
