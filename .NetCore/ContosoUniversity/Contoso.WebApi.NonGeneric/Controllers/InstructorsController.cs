using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Contoso.Data.Entities;
using Contoso.Domain.Entities;
using Contoso.Repositories;
using Contoso.Web.Utils;
using Kendo.Mvc.UI;
using LogicBuilder.Expressions.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contoso.WebApi.NonGeneric.Controllers
{
    [Produces("application/json")]
    [Route("api/Instructors")]
    public class InstructorsController : Controller
    {
        readonly ISchoolRepository _schoolRepository;
        readonly IMapper mapper;
        public InstructorsController(ISchoolRepository schoolRepository, IMapper mapper)
        {
            this._schoolRepository = schoolRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([DataSourceRequest]DataSourceRequest request)
        {
            try
            {
                return Json(await request.GetDataSourceResult<InstructorModel, Instructor>(this._schoolRepository, KendoUIHelpers.GetIncludes<InstructorModel>(i => i.Include(s => s.Courses).ThenInclude(c => c.CourseTitle), i => i.Include(s => s.OfficeAssignment))));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCourses")]
        public async Task<IActionResult> GetCourses([DataSourceRequest]DataSourceRequest request)
        {
            try
            {
                return Json(await request.GetDataSourceResult<CourseAssignmentModel, CourseAssignment>(this._schoolRepository, KendoUIHelpers.GetIncludes<CourseAssignmentModel>(i => i.Include(s => s.CourseTitle), i => i.Include(s => s.Department))));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/values
        [HttpPost("GetDropdownList")]
        public async Task<IActionResult> Get([FromBody]IEnumerable<string> selects)
        {
            try
            {
                ParameterExpression param = Expression.Parameter(typeof(IQueryable<InstructorModel>), "q");
                MethodCallExpression mce = param
                    .GetOrderBy<InstructorModel>(new LogicBuilder.Expressions.Utils.Strutures.SortCollection(new List<LogicBuilder.Expressions.Utils.Strutures.SortDescription>() { new LogicBuilder.Expressions.Utils.Strutures.SortDescription("FullName", LogicBuilder.Expressions.Utils.Strutures.ListSortDirection.Ascending) }))
                    .GetSelectNew<InstructorModel>(selects.ToList());
                Expression<Func<IQueryable<InstructorModel>, IQueryable<dynamic>>> exp = Expression.Lambda<Func<IQueryable<InstructorModel>, IQueryable<dynamic>>>(mce, param);

                return Ok(await this._schoolRepository.QueryAsync<InstructorModel, Instructor, IQueryable<dynamic>, IQueryable<dynamic>>(exp));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok
                (
                    await this._schoolRepository.QueryAsync<InstructorModel, Instructor, InstructorModel, Instructor>
                    (
                        q => q.Where(s => s.ID == id).Single(),
                        KendoUIHelpers.GetIncludes<InstructorModel>(a => a.Include(e => e.Courses), a => a.Include(s => s.OfficeAssignment))
                    )
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]InstructorModel instructor)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not Saved");

            try
            {
                //instructor.EntityState = LogicBuilder.Domain.EntityStateType.Added;
                if (await this._schoolRepository.SaveGraphAsync<InstructorModel, Instructor>(instructor))
                {
                    return Created($"/api/[controller]/{instructor.ID}", instructor);
                }
                else
                {
                    return BadRequest("Not Saved");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]InstructorModel instructor)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not Saved");

            try
            {
                //instructor.EntityState = LogicBuilder.Domain.EntityStateType.Modified;
                if (await this._schoolRepository.SaveGraphAsync<InstructorModel, Instructor>(instructor))
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest("Not Saved");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (await this._schoolRepository.DeleteAsync<InstructorModel, Instructor>(d => d.ID == id))
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest("Not Saved");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}