using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalCalenderBooking.ViewModels;

namespace TalCalenderBooking.Abstractions
{
    public interface ICalenderBookingService
    {
        Task<IList<BookingSlotModel>> GetAllBookingAsync();
        Task<IList<BookingSlotRecord>> FindBookingAsync(string input);
        Task<bool> AddBookingAsync(BookingSlotModel model);
        Task<bool> DeleteBookingAsync(BookingSlotModel model);
    }
}
