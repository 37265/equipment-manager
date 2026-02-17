namespace server.Models;

public class Product
{
    public int ID { get; set; }
    public int CategoryID { get; set; }
    
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public bool RequiresApproval { get; set; }

    public Category Category { get; set; }
}