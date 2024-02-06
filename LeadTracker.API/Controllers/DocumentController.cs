using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.Reflection.Metadata;

namespace LeadTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : BaseController
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpPost]
        [Route("upload")]
        public async Task<ActionResult> UploadTest([FromForm] DocumentDTO document)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("EmployeeId")).Value);
            var orgId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("OrgId")).Value);

            await _documentService.CreateDocument(userId, orgId, document).ConfigureAwait(false);

            return Ok(document);
        }

        [HttpPost]
        [Route("status")]
        public async Task<ActionResult> UploadStatus([FromForm] StatusDTO status)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("EmployeeId")).Value);
            var orgId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("OrgId")).Value);

            await _documentService.InsertStatus(status, orgId, userId).ConfigureAwait(false);

            return Ok(status);
        }

        [HttpGet]
        [Route("DownloadFile")]
        public async Task<IActionResult> DownloadFile(string filename)
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), filename);

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filepath, out var contenttype))
            {
                contenttype = "application/octet-stream";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(filepath);
            return File(bytes, contenttype, Path.GetFileName(filepath));
        }

        [HttpGet]
        [Route("File")]
        public async Task<IActionResult> File(string filename)
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), filename);

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filepath, out var contenttype))
            {
                contenttype = "application/octet-stream";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(filepath);

            string documentType = await _documentService.GetDocumentType(filename);

            var response = new
            {
                Content = new FileContentResult(bytes, contenttype),
                DocumentType = documentType
            };
            // return File(bytes, contenttype, Path.GetFileName(filepath));

            return Ok(response);
        }

        [HttpGet("GetFile/{filename}")]
        public async Task<IActionResult> GetFileAsync(string filename)
        {
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), filename);

                if (System.IO.File.Exists(filePath))
                {
                    byte[] fileData = System.IO.File.ReadAllBytes(filePath);

                    string contentType = await _documentService.GetContentType(filename); /*= GetContentType(fileName);*/

                    return File(fileData, contentType);
                }
                else
                {
                    return NotFound("File not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

    }
}
