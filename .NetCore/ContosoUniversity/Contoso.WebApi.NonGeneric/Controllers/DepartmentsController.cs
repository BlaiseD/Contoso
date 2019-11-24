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
using LogicBuilder.Expressions.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contoso.WebApi.NonGeneric.Controllers
{
    [Produces("application/json")]
    [Route("api/Departments")]
    public class DepartmentsController : Controller
    {
        readonly ISchoolRepository _schoolRepository;
        readonly IMapper mapper;
        public DepartmentsController(ISchoolRepository schoolRepository, IMapper mapper)
        {
            this._schoolRepository = schoolRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([DataSourceRequest]DataSourceRequest request)
        {
            try
            {
                //return Json(await Task.Run(() => request.GetDataSourceResult<DepartmentModel, Department>(this._context.Departments, this.mapper, Help.GetIncludes<DepartmentModel>(i => i.Include(s => s.AdministratorName)))));
                return Json(await request.GetDataSourceResult<DepartmentModel, Department>(this._schoolRepository, KendoUIHelpers.GetIncludes<DepartmentModel>(i => i.Include(s => s.AdministratorName))));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/values
        [HttpGet("GetDepartments")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await this._schoolRepository.GetItemsAsync<DepartmentModel, Department>(null,
                                                        lst => lst.OrderBy(s => s.Name),
                                                        KendoUIHelpers.GetIncludes<DepartmentModel>(i => i.Include(s => s.AdministratorName))));
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
                System.Linq.Expressions.ParameterExpression param = System.Linq.Expressions.Expression.Parameter(typeof(IQueryable<DepartmentModel>), "q");
                System.Linq.Expressions.MethodCallExpression mce = param
                    .GetOrderBy<DepartmentModel>(new LogicBuilder.Expressions.Utils.Strutures.SortCollection(new List<LogicBuilder.Expressions.Utils.Strutures.SortDescription>() { new LogicBuilder.Expressions.Utils.Strutures.SortDescription("Name", LogicBuilder.Expressions.Utils.Strutures.ListSortDirection.Ascending) }))
                    .GetSelectNew<DepartmentModel>(selects.ToList());
                System.Linq.Expressions.Expression<Func<IQueryable<DepartmentModel>, IQueryable<dynamic>>> exp = System.Linq.Expressions.Expression.Lambda<Func<IQueryable<DepartmentModel>, IQueryable<dynamic>>>(mce, param);

                return Ok(await this._schoolRepository.QueryAsync<DepartmentModel, Department, IQueryable<dynamic>, IQueryable<dynamic>>(exp));
                //return Ok(await this._schoolRepository.QueryAsync<DepartmentModel, Department, IQueryable<dynamic>, IQueryable<dynamic>>(selects.ToList().BuildSelectNewExpression<DepartmentModel>()));
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
                            await this._schoolRepository.QueryAsync<DepartmentModel, Department, DepartmentModel, Department>
                            (
                                q => q.Where(d => d.DepartmentID == id).Single(),
                                KendoUIHelpers.GetIncludes<DepartmentModel>(a => a.Include(x => x.AdministratorName))
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
        public async Task<IActionResult> Post([FromBody]DepartmentModel department)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not Saved");

            try
            {
                department.EntityState = LogicBuilder.Domain.EntityStateType.Added;
                if (await this._schoolRepository.SaveAsync<DepartmentModel, Department>(department))
                {
                    return Created($"/api/[controller]/{department.DepartmentID}", department);
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
        public async Task<IActionResult> Put(int id, [FromBody]DepartmentModel department)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not Saved");

            try
            {
                department.EntityState = LogicBuilder.Domain.EntityStateType.Modified;
                if (await this._schoolRepository.SaveAsync<DepartmentModel, Department>(department))
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
                if (await this._schoolRepository.DeleteAsync<DepartmentModel, Department>(d => d.DepartmentID == id))
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