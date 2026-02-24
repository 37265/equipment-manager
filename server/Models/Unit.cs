namespace server.Models;

public enum UnitStatus
{
    Active = 1,
    Retired = 2
}

public class Unit
{
    public int ID { get; set; }
    public string? SerialNumber { get; set; }
    public string Tag { get; set; }
    public UnitStatus Status { get; private set; } = UnitStatus.Active;

    public int ProductID { get; set; }
    public Product Product { get; set; }

    public ICollection<Booking> Bookings { get; set; }
    public ICollection<Maintenance> Maintenances { get; set; }
}