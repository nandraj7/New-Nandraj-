using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeadTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _educationService;

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;

        }
        //[HttpPost("NewEmployeeEducation")]
        //public async Task<ActionResult> NewEmployeeEducation([FromForm] NewEducationDTO education)
        //{
        //    var userId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("EmployeeId")).Value);

        //    await _educationService.RegisterEmployeeEducation(education, userId).ConfigureAwait(false);

        //    return Ok(education);
        //}

        //[HttpPost("NewEmployeeBankDetail")]
        //public async Task<ActionResult> NewEmployeeBankDetail([FromForm] NewBankDetailDTO bankDetail)
        //{
        //    var userId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("EmployeeId")).Value);

        //    await _educationService.RegisterEmployeeBankDetail(bankDetail, userId).ConfigureAwait(false);

        //    return Ok(bankDetail);
        //}



        [HttpPut("UpdateEmployeeEducation/{employeeId}")]
        public async Task<IActionResult> UpdateEmployeeEducation([FromForm] NewEducationDTO education, int employeeId)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("EmployeeId")).Value);

            var updatedEducationResult = await _educationService.UpdateEmployeeEducation(employeeId, education, userId).ConfigureAwait(false);

            return Ok(updatedEducationResult);
        }


        [HttpPut("UpdateEmployeeBankDetail/{employeeId}")]
        public async Task<IActionResult> UpdateEmployeeBankDetail([FromForm] NewBankDetailDTO bankDetail, int employeeId)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("EmployeeId")).Value);

            var updatedBankDetailResult = await _educationService.UpdateEmployeeBankDetail(employeeId, bankDetail, userId).ConfigureAwait(false);

            return Ok(updatedBankDetailResult);
        }
    }

}
