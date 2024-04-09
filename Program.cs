// See https://aka.ms/new-console-template for more information


using System.Globalization;
using System.Text.RegularExpressions;
using TalCalenderBooking.Presentation;
using static System.Net.Mime.MediaTypeNames;

Console.WriteLine("Hello, Tal! \n");

var inputCommamds = $"ADD DD/MM hh:mm to add an appointment \n" +
                     "DELETE DD/MM hh:mm to remove an appointment \n" +
                     "FIND DD/MM to find a free timeslot for the day \n" +
                     "KEEP hh:mm keep a timeslot for any day \n";

Console.WriteLine("Please enter following commands only \n" + inputCommamds);

var booking = new CalenderBooking();
booking.processCalenderBooking();















