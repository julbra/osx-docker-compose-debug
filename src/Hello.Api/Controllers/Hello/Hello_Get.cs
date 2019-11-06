using Microsoft.AspNetCore.Mvc;

namespace Hello.Api.Controllers.Hello
{
    public partial class HelloController
    {
        [HttpGet(Routes.Hello, Name = RouteNames.Hello)]
        public ActionResult SayHello()
        {
            return new ContentResult() { Content = "Hello World!" };
        }
    }
}
