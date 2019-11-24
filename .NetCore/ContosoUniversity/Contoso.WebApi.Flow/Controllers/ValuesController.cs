using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contoso.Data.Rules;
using Contoso.Domain.Entities;
using Contoso.Repositories;
using Contoso.Web.Flow;
using Contoso.Web.Flow.Requests;
using Contoso.Web.Flow.Rules;
using LogicBuilder.DataContracts;
using LogicBuilder.RulesDirector;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Contoso.WebApi.Flow.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpPost("PostFileData")]
        public IActionResult PostFileData([FromBody]LogicBuilder.DataContracts.ModuleData value)
        {
            return Created($"/api/[controller]/{value.ModuleName}", value);
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
