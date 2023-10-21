using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeadTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkFlowController : BaseController
    {
        private readonly IWorkFlowService _workFlowService;

        public WorkFlowController(IWorkFlowService workFlowService)
        {
            _workFlowService = workFlowService;
        }

        [HttpPost]
        public async Task<ActionResult> SaveWorkFlow(WorkFlowDTO workFlow)
        {
            await _workFlowService.CreateWorkFlow(workFlow).ConfigureAwait(false);
            return Ok(workFlow);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkFlowDTO>> GetWorkZone(int id)
        {
            var workFlow = await _workFlowService.GetWorkFlowByIdAsync(id).ConfigureAwait(false);

            if (workFlow == null)
            {
                return NotFound();
            }

            return Ok(workFlow);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkFlowDTO>>> GetAllWorkFlow()
        {
            var workFlow = await _workFlowService.GetAllWorkFlowAsync().ConfigureAwait(false);
            return Ok(workFlow);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWorkFlow(int id, WorkFlowDTO workFlow)
        {
            if (id != workFlow.Id)
            {
                return BadRequest();
            }

            await _workFlowService.UpdateWorkFlowAsync(id, workFlow).ConfigureAwait(false);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkFlow(int id)
        {
            await _workFlowService.DeleteWorkFlowAsync(id).ConfigureAwait(false);
            return NoContent();
        }
    }
}
