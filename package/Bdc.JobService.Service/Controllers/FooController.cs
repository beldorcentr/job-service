using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bdc.JobService.Businesslogic.FooStaff;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bdc.JobService.Service.Controllers
{
    [ApiController]
    public class FooController : ControllerBase
    {
        private readonly IFooWork _fooWork;

        public FooController(IFooWork fooWork)
        {
            _fooWork = fooWork;
        }

        [Route("api/makefoo")]
        [HttpPost]
        public IActionResult MakeFoo()
        {
            RecurringJob.Trigger(HangfireTaskKeys.Foo);
            return Accepted();
        }
    }
}