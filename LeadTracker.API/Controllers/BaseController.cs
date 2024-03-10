using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeadTracker.API.Controllers
{
    [Authorize]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public BaseController()
        {

        }
    }
}

