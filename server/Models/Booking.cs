using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models;

public enum BookingStatus
{
    Pending,
    Approved,
    Denied,
    Cancelled,
    Returned
}

public class Booking
{
    public int ID { get; set; }
    public int UserID { get; set; }
    public int ProductID { get; set; }
    public int UnitID { get; set; }
    public int ApprovedByUserID { get; set; }

    public DateTime ScheduledStart { get; set; }
    public DateTime ScheduledEnd { get; set; }
    public DateTime PickedUpAt { get; set; }
    public DateTime ReturnedAt { get; set; }
    public BookingStatus Status { get; private set; }
    public DateTime CreatedAt { get; set; }

    public User User { get; set; }
    public Product Product { get; set; }
    public Unit Unit { get; set; }
    public User ApprovedByUser { get; set; }
}
