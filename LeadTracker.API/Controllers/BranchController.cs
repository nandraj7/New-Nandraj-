using LeadTracker.BusinessLayer.IService;
using LeadTracker.BusinessLayer.Service;
using LeadTracker.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeadTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : BaseController
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpPost]
        public async Task<ActionResult> SaveBranch(BranchDTO branch)
        {
            await _branchService.CreateBranch(branch).ConfigureAwait(false);

            return Ok(branch);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BranchDTO>> GetBranch(int id)
        {
            var branch = await _branchService.GetBranchByIdAsync(id).ConfigureAwait(false);

            if (branch == null)
            {
                return NotFound();
            }

            return Ok(branch);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<BranchDTO>>> GetAllBranch()
        {
            var branch = await _branchService.GetAllBranchAsync().ConfigureAwait(false);
            return Ok(branch);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBranch(int id, BranchDTO branch)
        {
            if (id != branch.BranchId)
            {
                return BadRequest();
            }

            await _branchService.UpdateBranchAsync(branch).ConfigureAwait(false);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            await _branchService.DeleteBranchAsync(id).ConfigureAwait(false);
            return NoContent();
        }
    }
}
