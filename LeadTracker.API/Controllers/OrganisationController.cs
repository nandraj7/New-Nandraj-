using LeadTracker.Application.IService;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.BusinessLayer.Service;
using LeadTracker.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace LeadTracker.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class OrganisationController : BaseController
    {
        private readonly IOrgnisationService _orgnisationService;
        public OrganisationController(IOrgnisationService orgnisationService) 
        {
            _orgnisationService= orgnisationService;

        }


        [HttpPost]
        public async Task<ActionResult> SaveOrganisation(Core.DTO.OrganisationDTO organisation)
        {
            await _orgnisationService.CreateOrganisation(organisation).ConfigureAwait(false);

            return Ok(organisation);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Core.DTO.OrganisationDTO>> GetOrganisation(int id)
        {
            var organisation = await _orgnisationService.GetOrganisationByIdAsync(id).ConfigureAwait(false);

            if (organisation == null)
            {
                return NotFound();
            }

            return Ok(organisation);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Core.DTO.OrganisationDTO>>> GetAllOrganisations()
        {
            var organisations = await _orgnisationService.GetAllOrganisationsAsync().ConfigureAwait(false);
            return Ok(organisations);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrganisation(int id, Core.DTO.OrganisationDTO organisation)
        {
            if (id != organisation.OrgId)
            {
                return BadRequest();
            }

            await _orgnisationService.UpdateOrganisationAsync(id, organisation).ConfigureAwait(false);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganisation(int id)
        {
            await _orgnisationService.DeleteOrganisationAsync(id).ConfigureAwait(false);
            return NoContent();
        }

        //[HttpGet("GetEnquiriesByUserIdAndWorkflowId")]
        //public async Task<ActionResult<List<EnquiryDTO>>> GetEnquiriesByUserIdAndWorkflowId(int userId, int workflowId)
        //{
        //    var enquiryDTO = await _orgnisationService.GetEnquiriesByUserIdAndWorkflowIdAsync(userId, workflowId).ConfigureAwait(false);

        //    if (enquiryDTO == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(enquiryDTO);
        //}

    }
}
