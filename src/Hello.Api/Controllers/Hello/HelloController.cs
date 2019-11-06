using Microsoft.AspNetCore.Mvc;

namespace Hello.Api.Controllers.Hello
{
   
    [Route(Routes.Hello, Name = RouteNames.Hello)]
    public sealed partial class HelloController : Controller
    {
        public static class Routes
        {
            public const string Hello = "/hello";
        }

        public static class RouteNames
        {
            public const string Hello = "hello";
        }
    }
}
