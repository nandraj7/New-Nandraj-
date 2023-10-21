using LeadTracker.BusinessLayer.IService;
using LeadTracker.BusinessLayer.Service;
using LeadTracker.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace LeadTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : BaseController
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpPost]
        public async Task<ActionResult> SaveLocation(LocationDTO location)
        {
            await _locationService.CreateLocation(location).ConfigureAwait(false);

            return Ok(location);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LocationDTO>> GetLocation(int id)
        {
            var location = await _locationService.GetLocationByIdAsync(id).ConfigureAwait(false);

            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationDTO>>> GetAllLocation()
        {
            var location = await _locationService.GetAllLocationAsync().ConfigureAwait(false);
            return Ok(location);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocation(int id, LocationDTO location)
        {
            if (id != location.LocationId)
            {
                return BadRequest();
            }

            await _locationService.UpdateLocationAsync(id, location).ConfigureAwait(false);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            await _locationService.DeleteLocationAsync(id).ConfigureAwait(false);
            return NoContent();
        }
    }
}
