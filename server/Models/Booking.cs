using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models;

public enum BookingStatus
{
    Pending = 1,
    Approved = 2,
    Returned = 3,
    Denied = 4,
    Cancelled = 5,
}

public class Booking
{
    public int ID { get; set; }
    public DateTime ScheduledStart { get; set; }
    public DateTime ScheduledEnd { get; set; }
    public DateTime? PickedUpAt { get; set; }
    public DateTime? ReturnedAt { get; set; }
    public BookingStatus Status { get; private set; } = BookingStatus.Pending;
    public DateTimeOffset CreatedAt { get; set; }

    public int UserID { get; set; }
    public User User { get; set; }

    public int ProductID { get; set; }
    public Product Product { get; set; }

    public int? UnitID { get; set; }
    public Unit? Unit { get; set; }
    
    public int? ApprovedByUserID { get; set; }
    public User? ApprovedByUser { get; set; }
}
