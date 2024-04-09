using System.ComponentModel.DataAnnotations.Schema;

namespace TalCalenderBooking.Entities;

[Table(name: "BookingSlot")]
public class BookingSlot
{
    public Int64 Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public string? DateMonth { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime ModifiedDate { get; set; }

}
