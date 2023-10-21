using LeadTracker.API;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.IService
{
    public interface IBookingService
    {
        Task CreateBooking(BookingDTO booking);

        Task<BookingDTO> GetBookingByIdAsync(int id);

        Task<IEnumerable<BookingDTO>> GetAllBookingAsync();

        Task UpdateBookingAsync(int id, BookingDTO booking);

        Task DeleteBookingAsync(int id);
    }
}
