using LeadTracker.BusinessLayer.IService;
using LeadTracker.BusinessLayer.Service;
using LeadTracker.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace LeadTracker.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    
    public class AddressController : BaseController
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService= addressService;
        }

        [HttpPost]
        public async Task<ActionResult> SaveAddress(AddressDTO address)
        {
            await _addressService.CreateAddress(address).ConfigureAwait(false);

            return Ok(address);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDTO>> GetAddress(int id)
        {
            var address = await _addressService.GetAddressByIdAsync(id).ConfigureAwait(false);

            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressDTO>>> GetAllAddress()
        {
            var addresses = await _addressService.GetAllAddressAsync().ConfigureAwait(false);
            return Ok(addresses);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress(int id, AddressDTO address)
        {
            if (id != address.AddressId)
            {
                return BadRequest();
            }

            await _addressService.UpdateAddressAsync(id,address).ConfigureAwait(false);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            await _addressService.DeleteAddressAsync(id).ConfigureAwait(false);
            return NoContent();
        }
    }
}



