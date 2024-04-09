using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalCalenderBooking.Entities;

namespace TalCalenderBooking.Abstractions
{
    public interface ICalenderBookingRepository
    {
        Task<IEnumerable<BookingSlot>> FindBookingAsync(string dateMonth);

        Task<bool> AddBookingAsync(BookingSlot entity);
        Task<bool> DeleteBookingAsync(BookingSlot entity);
        Task<IEnumerable<BookingSlot>> GetAllBookingAsync();

    }
}
