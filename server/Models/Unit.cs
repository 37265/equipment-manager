namespace server.Models;

public enum UnitStatus
{
    Active,
    Retired
}

public class Unit
{
    public int ID { get; set; }
    public int ProductID { get; set; }

    public string? SerialNumber { get; set; }
    public string Tag { get; set; }
    public BookingStatus Status { get; set; }

    public Product Product { get; set; }
}