using System.Globalization;
using System.Text.RegularExpressions;
using TalCalenderBooking.Persistance;
using TalCalenderBooking.Repository;
using TalCalenderBooking.Service;
using TalCalenderBooking.ViewModels;
using TalCalenderBooking.ViewModels.Constants;

namespace TalCalenderBooking.Presentation;

public class CalenderBooking
{
    public void processCalenderBooking()
    {
        var dbcontext = new CalenderBookingDbContext();
        var repository = new CalenderBookingRepository(dbcontext);
        var service = new CalenderBookingService(repository);

        try
        {
            var escape = false;
            while (!escape)
            {
                var input = Console.ReadLine();
                Console.WriteLine($"{BookingConstant.EnteredValue}  {input}");

                if (string.IsNullOrWhiteSpace(input))
                {
                    escape = true;
                }
                else
                {
                    input = input.ToUpper();
                    if (input.StartsWith(BookingConstant.FIND))
                    {
                        Console.WriteLine(BookingConstant.AvailableSlots);
                        var slots = service.FindBookingAsync(input).Result;
                        slots.ToList().ForEach(slot =>
                        {
                            Console.WriteLine($"Id: {slot.Id},  DateMonth: {slot.DateMonth}, StartTime: {slot.StartTime},  EndTime{slot.EndTime}");
                        });
                        if (slots.Count <= 0)
                        {
                            Console.WriteLine(BookingConstant.NoAvailableSlots);
                        }

                    }
                    else if (input.StartsWith(BookingConstant.ADD))
                    {
                        var isBookingSlotAdded = false;
                        var bookingSlot = BookingProcess(input, $"{BookingConstant.ADD} ");
                        if (bookingSlot is not null && bookingSlot?.DateMonth is not null)
                        {
                            isBookingSlotAdded = service.AddBookingAsync(bookingSlot).Result;
                        }

                        if (isBookingSlotAdded)
                        {
                            Console.WriteLine($"Appointment Added. \n  DateMonth: {bookingSlot?.DateMonth}, StartTime: {bookingSlot?.StartTime},  EndTime{bookingSlot?.EndTime}");
                        }
                        else
                        {
                            Console.WriteLine(BookingConstant.NotAdded);
                        }

                    }
                    else if (input.StartsWith(BookingConstant.DELETE))
                    {
                        var isBookingSlotDeleted = false;
                        var bookingSlot = BookingProcess(input, $"{BookingConstant.DELETE} ");
                        if(bookingSlot is not null && bookingSlot?.DateMonth is not null)
                        {
                            isBookingSlotDeleted = service.DeleteBookingAsync(bookingSlot).Result;
                        }

                        if (isBookingSlotDeleted)
                        {
                            Console.WriteLine($"Appointment Deleted. \n  DateMonth: {bookingSlot?.DateMonth}, StartTime: {bookingSlot?.StartTime},  EndTime{bookingSlot?.EndTime}");
                        }
                        else
                        {
                            Console.WriteLine(BookingConstant.NotDeleted);
                        }
                    }
                    else if (input.StartsWith(BookingConstant.KEEP))
                    {
                        // Couldnt understand the requirement for "KEEP hh:mm keep a timeslot for any day"
                        Console.WriteLine(BookingConstant.KeepRequirement);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

    private  BookingSlotModel BookingProcess(string input, string command)
    {
        var bookingSlot = new BookingSlotModel();
        input = input.Replace(command, "");

        if (input.Length < 5)
        {
            Console.WriteLine($"{BookingConstant.CorrectFormat}   {command}{BookingConstant.DateMonthTime}");
        }
        var dateMonth = input.Substring(0, 5);
        var hhmmValue = input.Substring(5);

        if (!Regex.Match(dateMonth, @"\d{2}/\d{2}").Success || !Regex.Match(hhmmValue, @"\d{2}:\d{2}").Success)
        {
            Console.WriteLine($"{BookingConstant.CorrectFormat}   {command}{BookingConstant.DateMonthTime}");
        }
        else
        {
            var startTime = DateTime.ParseExact(dateMonth + "/" + DateTime.Now.Year + hhmmValue, BookingConstant.DateFormat, CultureInfo.InvariantCulture);
            Console.WriteLine(startTime);

            var endTime = startTime.AddMinutes(30);
            Console.WriteLine(endTime);
            if(!IsBookingSlotBetween9amto5pm(startTime))
            {
                Console.WriteLine(BookingConstant.BookingSlotBetween9amto5pm);
            } else if (!IsSecondDayOfThirdWeekOfEachMonth(startTime))
            {
                Console.WriteLine(BookingConstant.SecondDayOfThirdWeekOfEachMonth);
            }
            else
            {
                bookingSlot.StartTime = startTime;
                bookingSlot.EndTime = endTime;
                bookingSlot.DateMonth = dateMonth;
            }
        }

        
        return bookingSlot;
    }

    private bool IsBookingSlotBetween9amto5pm(DateTime startTime)
    {
        TimeSpan start = new TimeSpan(9, 0, 0); 
        TimeSpan end = new TimeSpan(16, 30, 0);
        return isAllowedTime(startTime, start, end);
    }

    private bool IsSecondDayOfThirdWeekOfEachMonth(DateTime startTime)
    {

        // Start from the first day of the month
        DateTime date = new DateTime(startTime.Year, startTime.Month, 1);

        // Find the first Monday of the month
        while (date.DayOfWeek != DayOfWeek.Monday)
        {
            date = date.AddDays(1);
        }

        // Add 14 days to get to the second day of the third week
        date = date.AddDays(14);

        if(startTime.Day == date.Day)
        {
            TimeSpan start = new TimeSpan(16, 00, 0);
            TimeSpan end = new TimeSpan(17, 00, 0);
            return !isAllowedTime(startTime, start, end);
        }
        return true;
    }

    private bool isAllowedTime(DateTime startTime, TimeSpan start, TimeSpan end)
    {
        TimeSpan now = startTime.TimeOfDay;

        if (start < end)
            return start <= now && now <= end;
        return !(end < now && now < start);
    }
}
