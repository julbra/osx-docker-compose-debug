using System;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

        private readonly ILogger<RootController> _logger;

        public HelloController([NotNull] ILogger<RootController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

    }
}
