using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contoso.Data.Entities;
using Contoso.Domain.Entities;
using Contoso.Repositories;
using Contoso.Web.Utils;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contoso.WebApi.NonGeneric.Controllers
{
    [Produces("application/json")]
    [Route("api/Students")]
    public class StudentsController : Controller
    {
        ISchoolRepository _schoolRepository;
        IMapper mapper;
        public StudentsController(ISchoolRepository schoolRepository, IMapper mapper)
        {
            this._schoolRepository = schoolRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([DataSourceRequest]DataSourceRequest request)
        {
            try
            {
                return Json(await request.GetDataSourceResult<StudentModel, Student>(this._schoolRepository));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetStudents")]
        public async Task<IActionResult> GetStudents([DataSourceRequest]DataSourceRequest request)
        {
            try
            {
                return Json(await request.GetDataSourceResult<StudentModel, Student>(this._schoolRepository));
                //return Json(await Task.Run(() => request.GetDataSourceResult<StudentModel, Student>(this._context.Students, this.mapper)));
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
            {//typically takes less than 5 milliseconds.
                return Ok
                (
                    await this._schoolRepository.QueryAsync<StudentModel, Student, StudentModel, Student>
                    (
                        q => q.Where(s => s.ID == id).Single(),
                        KendoUIHelpers.GetIncludes<StudentModel>(a => a.Include(x => x.Enrollments).ThenInclude(e => e.CourseTitle))
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
        public async Task<IActionResult> Post([FromBody]StudentModel student)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not Saved");

            try
            {
                student.EntityState = LogicBuilder.Domain.EntityStateType.Added;
                if (await this._schoolRepository.SaveAsync<StudentModel, Student>(student))
                {
                    return Created($"/api/[controller]/{student.ID}", student);
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
        public async Task<IActionResult> Put(int id, [FromBody]StudentModel student)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not Saved");

            try
            {
                student.EntityState = LogicBuilder.Domain.EntityStateType.Modified;
                if (await this._schoolRepository.SaveAsync<StudentModel, Student>(student))
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
                if (await this._schoolRepository.DeleteAsync<StudentModel, Student>(d => d.ID == id))
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