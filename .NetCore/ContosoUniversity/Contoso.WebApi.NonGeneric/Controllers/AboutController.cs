using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contoso.Data.Entities;
using Contoso.Domain.Entities;
using Contoso.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contoso.WebApi.NonGeneric.Controllers
{
    [Produces("application/json")]
    [Route("api/About")]
    public class AboutController : Controller
    {
        ISchoolRepository _schoolRepository;
        public AboutController(ISchoolRepository schoolRepository)
        {
            this._schoolRepository = schoolRepository;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok
                (
                    await this._schoolRepository.QueryAsync<StudentModel, Student, object, object>
                    (
                        lst => lst.OrderBy(s => s.EnrollmentDate).GroupBy(s => s.EnrollmentDate).Select(grp => new { EnrollmentDate = grp.Key, StudentCount = grp.Count() })
                    )
                );
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}