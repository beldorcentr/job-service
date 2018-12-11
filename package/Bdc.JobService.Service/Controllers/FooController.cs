using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bdc.JobService.Businesslogic.FooStaff;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace Bdc.JobService.Service.Controllers
{
    [ApiController]
    public class FooController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IFooWork _fooWork;

        public FooController(ILogger logger, IFooWork fooWork)
        {
            _logger = logger;
            _fooWork = fooWork;
        }

        [Route("api/makefoo")]
        [HttpPost]
        public IActionResult MakeFoo()
        {
            _logger.Info("Trigger Foo task");
            RecurringJob.Trigger(HangfireTaskKeys.Foo);
            return Accepted();
        }
    }
}