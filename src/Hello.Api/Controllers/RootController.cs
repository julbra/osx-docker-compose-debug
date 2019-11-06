using System;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hello.Api.Controllers
{
    [Route(Routes.Root, Name = RouteNames.Root)]
    public class RootController : Controller
    {
        public static class Routes
        {
            public const string Root = "/";
        }


        public static class RouteNames
        {
            public const string Root = "root";
        }


        private readonly ILogger<RootController> _logger;


        public RootController([NotNull] ILogger<RootController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        [HttpGet]
        public StatusCodeResult Get()
        {
            _logger.LogInformation("Root Controller GET");
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}