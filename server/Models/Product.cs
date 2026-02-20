namespace server.Models;

public class Product
{
    public int ID { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public bool RequiresApproval { get; set; } = true;

    public int CategoryID { get; set; }
    public Category Category { get; set; }

    public ICollection<Booking> Bookings { get; set; }
    public ICollection<Unit> Units { get; set; }
}