namespace server.Models;

public class Maintenance
{
    public int ID { get; set; }
    public int CreatedByUserID { get; private set; }
    public int ClosedByUserID { get; private set; }
    public int UnitID { get; set; }

    public string Reason { get; set; }
    public string Notes { get; set; }
    public DateTime Start { get; set; }
    public DateTime? End { get; set; }
    public DateTime CreatedAt { get; set; }

    public User CreatedByUser { get; set; }
    public User ClosedByUser { get; set; }
    public Unit Unit { set; get; }
}