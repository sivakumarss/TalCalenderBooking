using System.Globalization;
using System.Text.RegularExpressions;

namespace TalCalenderBooking;


//----Initial proto type to check the connectivity  directly from Program.cs


//var connectionString = @"Data Source=DESKTOP-9KOABJS\SQLEXPRESS;Initial Catalog=CorePlusDemo;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
//var dbOptions = new DbContextOptionsBuilder<CalenderBookingDbContext>()
//    .UseSqlServer(connectionString).Options;

//using (var dbcontext = new CalenderBookingDbContext(dbOptions))
//{
//    var bookingSlot = dbcontext.BookingSlots.ToListAsync().Result;

//    foreach (var slot in bookingSlot)
//    {
//        Console.WriteLine($"Id: {slot.Id}, StartTime: {slot.StartTime},  EndTime{slot.EndTime}");

//    }

//}


//--  To Fetch All records 
//var slotsALL = service.GetAllBookingAsync().Result;

//slotsALL.ToList().ForEach(slot =>
//{
//    Console.WriteLine($"Id: {slot.Id}, StartTime: {slot.StartTime},  EndTime{slot.EndTime}");
//});



//----Practice demo to check the logic for   ADD DD/MM hh:mm to add an appointment

//var input = Console.ReadLine();

//input = input.Replace("ADD ", "");

//var ddMMValue = input.Substring(0, 5);
//var ddMMValuetest = Regex.Match(ddMMValue, @"\d{2}/\d{2}");
//Console.WriteLine(ddMMValue);
//Console.WriteLine($"ddMMValuetest Regex: {ddMMValuetest} ");


//var hhmmValue = input.Substring(5) + "";
//var hhmmValuetest = Regex.Match(hhmmValue, @"\d{2}:\d{2}");
//Console.WriteLine(hhmmValue);
//Console.WriteLine($"ddMMValuetest Regex: {hhmmValuetest} ");

//if(ddMMValuetest.Success  && hhmmValuetest.Success)
//{
//    var startTime = DateTime.ParseExact(ddMMValue + "/" + DateTime.Now.Year + hhmmValue, "g", CultureInfo.InvariantCulture);
//Console.WriteLine(startTime);

//    var endTime = startTime.AddMinutes(30);
//Console.WriteLine(endTime);
//}
//else
//{
//    Console.WriteLine("Please use the correct format:   ADD DD/MM hh:mm");
//}




//Console.WriteLine(DateTime.Now);  //7/04/2024 11:26:03 AM



//----- Practice  to Fetch  for each second day of the third week of any month


//int year = 2024;
//int month = 4; // April

//DateTime secondDayOfThirdWeek = GetSecondDayOfThirdWeek(year, month);

//Console.WriteLine($"The second day of the third week of {month}/{year} is: {secondDayOfThirdWeek}");

//static DateTime GetSecondDayOfThirdWeek(int year, int month)
//{
//    // Start from the first day of the month
//    DateTime date = new DateTime(year, month, 1);

//    // Find the first Monday of the month
//    while (date.DayOfWeek != DayOfWeek.Monday)
//    {
//        date = date.AddDays(1);
//    }

//    // Add 14 days to get to the second day of the third week
//    date = date.AddDays(14);

//    return date;
//}
