using LeadTracker.BusinessLayer.IService;
using LeadTracker.BusinessLayer.Service;
using LeadTracker.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Core.Mapping;

namespace LeadTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRoleController : BaseController
    {
        private readonly IEmployeeRoleService _employeeRoleService;


        public EmployeeRoleController(IEmployeeRoleService employeeRoleService)
        {
            _employeeRoleService = employeeRoleService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveEmployeeRole(EmployeeRoleDTO employeeRole)
        {
            await _employeeRoleService.CreateEmployeeRole(employeeRole).ConfigureAwait(false);
            return Ok(employeeRole);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult<EmployeeRoleDTO>> GetEmployeeRole(int id)
        //{
        //    var employeeRole = await _employeeRoleService.GetEmployeeRoleByIdAsync(id).ConfigureAwait(false);

        //    if (employeeRole == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(employeeRole);
        //}



        //[HttpGet]
        //public async Task<IActionResult<IEnumerable<EmployeeRoleDTO>>> GetAllEmployeeRole()
        //{
        //    var employeeRoles = await _employeeRoleService.GetAllEmployeeRoleAsync().ConfigureAwait(false);
        //    return Ok(employeeRoles);
        //}







    }
}
