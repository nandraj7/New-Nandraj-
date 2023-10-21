using AutoMapper;
using LeadTracker.API;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure;
using LeadTracker.Infrastructure.IRepository;
using LeadTracker.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.Service
{
    public class BookingService : IBookingService
    {

        private readonly IBookingRepository _bookingrepository;
        private readonly IMapper _mappingProfile;

        public BookingService(IMapper mappingProfile, IBookingRepository bookingService)
        {
            _mappingProfile = mappingProfile;
            _bookingrepository = bookingService;

        }

        public async Task CreateBooking(BookingDTO booking)
        {
            var book = _mappingProfile.Map<Booking>(booking);
            await _bookingrepository.CreateAsync(book).ConfigureAwait(false);
        }

        public async Task<BookingDTO> GetBookingByIdAsync(int id)
        {
            var booking = await _bookingrepository.GetByIdAsync(id);

            var bookingDTO = _mappingProfile.Map<BookingDTO>(booking);
            return bookingDTO;

        }

        public async Task<IEnumerable<BookingDTO>> GetAllBookingAsync()
        {
            var bookings = await _bookingrepository.GetAllAsync();
            var bookingsDTO = _mappingProfile.Map<List<BookingDTO>>(bookings);
            return bookingsDTO.ToList();
        }

        public async Task UpdateBookingAsync(int id, BookingDTO booking)
        {
           
            var existingBooking = await _bookingrepository.GetByIdAsync(id);
            _mappingProfile.Map(booking, existingBooking);
            await _bookingrepository.UpdateAsync(existingBooking);

            //var book = _mappingProfile.Map<Booking>(booking);
            //await _bookingrepository.UpdateAsync(book);
        }

        public async Task DeleteBookingAsync(int id)
        {
            var booking = await _bookingrepository.GetByIdAsync(id);
            if (booking != null)
            {
                await _bookingrepository.DeleteAsync(id);
            }
        }
    }
}
