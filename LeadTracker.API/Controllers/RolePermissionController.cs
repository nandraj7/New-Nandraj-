using LeadTracker.BusinessLayer.IService;
using LeadTracker.BusinessLayer.Service;
using LeadTracker.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace LeadTracker.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class RolePermissionController : BaseController
    {
        private readonly IRolePermissionService _rolePermissionService;

        public RolePermissionController(IRolePermissionService rolePermissionService)
        {
            _rolePermissionService = rolePermissionService;
        }
         
        [HttpPost]
        public async Task<ActionResult> SaveRolePermission(RolePermissionDTO rolePermission)
        {
            await _rolePermissionService.CreateRolePermission(rolePermission).ConfigureAwait(false);

            return Ok(rolePermission);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<RolePermissionDTO>> GetRolePermission(int id)
        {
            var rolepermission = await _rolePermissionService.GetRolePermissionByIdAsync(id).ConfigureAwait(false);

            if (rolepermission == null)
            {
                return NotFound();
            }

            return Ok(rolepermission);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolePermissionDTO>>> GetAllRolePermission()
        {
            var rolePermissions = await _rolePermissionService.GetAllRolePermissionAsync().ConfigureAwait(false);
            return Ok(rolePermissions);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRolePermission(int id, RolePermissionDTO rolePermission)
        {
            if (id != rolePermission.RolePermissionId)
            {
                return BadRequest();
            }

            await _rolePermissionService.UpdateRolePermissionAsync(id, rolePermission).ConfigureAwait(false);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRolePermission(int id)
        {
            await _rolePermissionService.DeleteRolePermissionAsync(id).ConfigureAwait(false);
            return NoContent();
        }
    }
}
