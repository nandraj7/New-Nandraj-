using LeadTracker.BusinessLayer.IService;
using LeadTracker.BusinessLayer.Service;
using LeadTracker.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace LeadTracker.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : BaseController
    {
        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;

        }


        [HttpPost]
        public async Task<ActionResult> SavePermission(PermissionDTO permission)
        {
            await _permissionService.CreatePermission(permission).ConfigureAwait(false);

            return Ok(permission);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PermissionDTO>> GetPermission(int id)
        {
            var permission = await _permissionService.GetPermissionByIdAsync(id).ConfigureAwait(false);

            if (permission == null)
            {
                return NotFound();
            }

            return Ok(permission);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermissionDTO>>> GetAllPermission()
        {
            var permission = await _permissionService.GetAllPermissionAsync().ConfigureAwait(false);
            return Ok(permission);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePermission(int id, PermissionDTO permission)
        {
            if (id != permission.PermissionId)
            {
                return BadRequest();
            }

            await _permissionService.UpdatePermissionAsync(id, permission).ConfigureAwait(false);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermission(int id)
        {
            await _permissionService.DeletePermissionAsync(id).ConfigureAwait(false);
            return NoContent();
        }
    }
}
