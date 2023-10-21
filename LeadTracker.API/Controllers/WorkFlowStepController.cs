using LeadTracker.BusinessLayer.IService;
using LeadTracker.BusinessLayer.Service;
using LeadTracker.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeadTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkFlowStepController : BaseController
    {
        private readonly IWorkFlowStepService _workFlowStepService;

        public WorkFlowStepController(IWorkFlowStepService workFlowStepService)
        {
            _workFlowStepService = workFlowStepService;
        }

        [HttpPost]
        public async Task<ActionResult> SaveWorkFlowStep(WorkFlowStepDTO workFlowStep)
        {
            await _workFlowStepService.CreateWorkFlowStep(workFlowStep).ConfigureAwait(false);
            return Ok(workFlowStep);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkFlowStepDTO>> GetWorkFlowStep(int id)
        {
            var workFlowStep = await _workFlowStepService.GetWorkFlowStepByIdAsync(id).ConfigureAwait(false);

            if (workFlowStep == null)
            {
                return NotFound();
            }

            return Ok(workFlowStep);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkFlowStepDTO>>> GetAllWorkFlowStep()
        {
            var workFlowStep = await _workFlowStepService.GetAllWorkFlowStepAsync().ConfigureAwait(false);
            return Ok(workFlowStep);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWorkFlowStep(int id, WorkFlowStepDTO workFlowStep)
        {
            if (id != workFlowStep.Id)
            {
                return BadRequest();
            }

            await _workFlowStepService.UpdateWorkFlowStepAsync(id, workFlowStep).ConfigureAwait(false);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkFlowStep(int id)
        {
            await _workFlowStepService.DeleteWorkFlowStepAsync(id).ConfigureAwait(false);
            return NoContent();
        }

        [HttpGet("GetWorkflow")]
        public async Task<ActionResult<List<OrgWorkFlowDTO>>> GetWorkFlow()
        {

            //var _orgId = Convert.ToInt32(HttpContext.item.[].FindFirst(a => a.Type.Equals("OrgId")).Value);
            var _orgId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("OrgId")).Value);
            //var _orgId = Convert.ToInt32(HttpContext.Items["OrgId"]);



            var workFlow = await _workFlowStepService.GetWorkFlowAsync(_orgId).ConfigureAwait(false);

            if (workFlow == null)
            {
                return NotFound();
            }

            return Ok(workFlow);
        }


        [HttpGet("GetNextSteps/{currentStep}/{currentStepWorkFlowId}")]
        public async Task<ActionResult<List<NextStepDTO>>> GetNextSteps(string currentStep , int currentStepWorkFlowId)
        {
            var _orgId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("OrgId")).Value);

            var nextSteps = await _workFlowStepService.GetNextStepsAsync(currentStep, currentStepWorkFlowId, _orgId).ConfigureAwait(false);

            if (nextSteps == null)
            {
                return NotFound();
            }
            return Ok(nextSteps);
        }



    }
}
