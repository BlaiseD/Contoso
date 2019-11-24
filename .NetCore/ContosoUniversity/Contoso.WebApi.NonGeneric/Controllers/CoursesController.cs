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
using LogicBuilder.Expressions.Utils.Strutures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contoso.WebApi.NonGeneric.Controllers
{
    [Produces("application/json")]
    [Route("api/Courses")]
    public class CoursesController : Controller
    {
        readonly ISchoolRepository _schoolRepository;
        readonly IMapper mapper;
        public CoursesController(ISchoolRepository schoolRepository, IMapper mapper)
        {
            this._schoolRepository = schoolRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([DataSourceRequest]DataSourceRequest request)
        {
            try
            {
                return Json(await request.GetDataSourceResult<CourseModel, Course>(this._schoolRepository, KendoUIHelpers.GetIncludes<CourseModel>(i => i.Include(s => s.DepartmentName))));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetEnrollments")]
        public async Task<IActionResult> GetStudents([DataSourceRequest]DataSourceRequest request)
        {
            try
            {
                return Json(await request.GetDataSourceResult<EnrollmentModel, Enrollment>(this._schoolRepository, KendoUIHelpers.GetIncludes<EnrollmentModel>(i => i.Include(s => s.CourseTitle), i => i.Include(s => s.StudentName))));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/values
        [HttpPost("GetDropdownList")]
        public async Task<IActionResult> Get([FromBody]IDictionary<string, string> selects)
        {
            try
            {
                Expression<Func<IQueryable<CourseModel>, IQueryable<dynamic>>> exp = Expression.Parameter(typeof(IQueryable<CourseModel>), "q").BuildLambdaExpression<IQueryable<CourseModel>, IQueryable<dynamic>>
                (
                    p => p.GetOrderBy<CourseModel>(new SortCollection(new List<SortDescription>() { new SortDescription("Title", ListSortDirection.Ascending) }))
                        .GetSelectNew<CourseModel>(selects)
                );

                return Ok(await this._schoolRepository.QueryAsync<CourseModel, Course, IQueryable<dynamic>, IQueryable<dynamic>>(exp));
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
                return Ok(
                            (
                                await this._schoolRepository.GetItemsAsync<CourseModel, Course>(d => d.CourseID == id,
                                                        lst => lst.OrderBy(s => s.Title),
                                                        KendoUIHelpers.GetIncludes<CourseModel>(i => i.Include(s => s.DepartmentName)))
                            ).Single()

                         );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CourseModel course)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not Saved");

            try
            {
                CourseModel crs = (await this._schoolRepository.GetItemsAsync<CourseModel, Course>(d => d.CourseID == course.CourseID)).SingleOrDefault();
                if (crs != null)
                    return BadRequest("Couse ID Exists");

                course.EntityState = LogicBuilder.Domain.EntityStateType.Added;
                if (await this._schoolRepository.SaveAsync<CourseModel, Course>(course))
                {
                    return Created($"/api/[controller]/{course.CourseID}", course);
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
        public async Task<IActionResult> Put(int id, [FromBody]CourseModel course)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not Saved");

            try
            {
                course.EntityState = LogicBuilder.Domain.EntityStateType.Modified;
                if (await this._schoolRepository.SaveAsync<CourseModel, Course>(course))
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
                if (await this._schoolRepository.DeleteAsync<CourseModel, Course>(d => d.CourseID == id))
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