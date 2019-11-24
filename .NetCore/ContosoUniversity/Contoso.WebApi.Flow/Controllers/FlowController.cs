using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contoso.Web.Flow;
using Contoso.Web.Flow.Options;
using Contoso.Web.Flow.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Contoso.WebApi.Flow.Controllers
{
    [Produces("application/json")]
    [Route("api/Flow")]
    public class FlowController : Controller
    {
        private ILogger<FlowController> _logger;
        private readonly IFlowManager _flowManager;
        private readonly InitialOptions _initialOptions;
        public FlowController(ILogger<FlowController> logger, IFlowManager flowManager, IOptions<InitialOptions> optionsAccessor)
        {
            this._logger = logger;
            this._flowManager = flowManager;
            _initialOptions = optionsAccessor.Value;
        }

        [HttpPost("Start")]
        public IActionResult Start([FromBody]string value)
        {
            //System.Diagnostics.Stopwatch stopWatch = System.Diagnostics.Stopwatch.StartNew();
            DateTime dt = DateTime.Now;
            object o = this._flowManager.Start(_initialOptions.InitialModule, _initialOptions.TargetModule);
            DateTime dt2 = DateTime.Now;

            _logger.LogInformation(string.Format("Start (milliseconds) = {0}", (dt2 - dt).TotalMilliseconds));
            return Ok(o);
        }

        [HttpPost("NavStart")]
        public IActionResult NavStart([FromBody]NavBarRequest navBarRequest)
        {
            //System.Diagnostics.Stopwatch stopWatch = System.Diagnostics.Stopwatch.StartNew();
            DateTime dt = DateTime.Now;
            object o = this._flowManager.NavStart(navBarRequest);
            DateTime dt2 = DateTime.Now;

            _logger.LogInformation(string.Format("NavStart (milliseconds) = {0}", (dt2 - dt).TotalMilliseconds));
            return Ok(o);
        }

        [HttpPost("Next")]
        public IActionResult Next([FromBody]RequestBase response)
        {
            //System.Diagnostics.Stopwatch stopWatch = System.Diagnostics.Stopwatch.StartNew();
            DateTime dt = DateTime.Now;
            object o = this._flowManager.Next(response);
            DateTime dt2 = DateTime.Now;

            _logger.LogInformation(string.Format("Next (milliseconds) = {0}", (dt2 - dt).TotalMilliseconds));
            return Ok(o);
        }
    }
}