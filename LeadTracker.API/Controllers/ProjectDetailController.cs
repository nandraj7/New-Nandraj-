using LeadTracker.BusinessLayer.IService;
using LeadTracker.BusinessLayer.Service;
using LeadTracker.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace LeadTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectDetailController : BaseController
    {
        private readonly IProjectDetailService _projectDetailService;

        public ProjectDetailController(IProjectDetailService projectDetailService)
        {
            _projectDetailService = projectDetailService;

        }


        [HttpPost]
        public async Task<ActionResult> SaveProjectDetail(ProjectDetailDTO projectDetail)
        {
            await _projectDetailService.CreateProjectDetail(projectDetail).ConfigureAwait(false);

            return Ok(projectDetail);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDetailDTO>> GetProjectDetail(int id)
        {
            var projectDetail = await _projectDetailService.GetProjectDetailByIdAsync(id).ConfigureAwait(false);

            if (projectDetail == null)
            {
                return NotFound();
            }

            return Ok(projectDetail);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDetailDTO>>> GetAllProjectDetail()
        {
            var projectDetail = await _projectDetailService.GetAllProjectDetailAsync().ConfigureAwait(false);
            return Ok(projectDetail);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProjectDetail(int id, ProjectDetailDTO projectDetail)
        {
            if (id != projectDetail.ProjectId)
            {
                return BadRequest();
            }

            await _projectDetailService.UpdateProjectDetailAsync(id, projectDetail).ConfigureAwait(false);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectDetail(int id)
        {
            await _projectDetailService.DeleteProjectDetailAsync(id).ConfigureAwait(false);
            return NoContent();
        }
    }
}
