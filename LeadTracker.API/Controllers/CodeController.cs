using LeadTracker.BusinessLayer.IService;
using LeadTracker.BusinessLayer.Service;
using LeadTracker.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace LeadTracker.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CodeController : BaseController
    {
        private readonly ICodeService _codeService;

        public CodeController(ICodeService codeService)
        {
            _codeService = codeService;

        }


        [HttpPost]
        public async Task<ActionResult> SaveCode(CodeDTO code)
        {
            await _codeService.CreateCode(code).ConfigureAwait(false);

            return Ok(code);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CodeDTO>> GetCode(int id)
        {
            var code = await _codeService.GetCodeByIdAsync(id).ConfigureAwait(false);

            if (code == null)
            {
                return NotFound();
            }

            return Ok(code);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CodeDTO>>> GetAllCode()
        {
            var code = await _codeService.GetAllCodeAsync().ConfigureAwait(false);
            return Ok(code);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCode(int id, CodeDTO code)
        {
            if (id != code.CodeId)
            {
                return BadRequest();
            }

            await _codeService.UpdateCodeAsync(id, code).ConfigureAwait(false);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCode(int id)
        {
            await _codeService.DeleteCodeAsync(id).ConfigureAwait(false);
            return NoContent();
        }
    }
}
