using LeadTracker.BusinessLayer.IService;
using LeadTracker.BusinessLayer.Service;
using LeadTracker.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeadTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : BaseController
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }


        [HttpPost]
        public async Task<ActionResult> SaveBooking(BookingDTO booking)
        {
            await _bookingService.CreateBooking(booking).ConfigureAwait(false);

            return Ok(booking);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDTO>> GetBooking(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id).ConfigureAwait(false);

            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDTO>>> GetAllBooking()
        {
            var bookings = await _bookingService.GetAllBookingAsync().ConfigureAwait(false);
            return Ok(bookings);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, BookingDTO booking)
        {
            if (id != booking.BookingId)
            {
                return BadRequest();
            }

            await _bookingService.UpdateBookingAsync(id, booking).ConfigureAwait(false);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            await _bookingService.DeleteBookingAsync(id).ConfigureAwait(false);
            return NoContent();
        }
    }
}
