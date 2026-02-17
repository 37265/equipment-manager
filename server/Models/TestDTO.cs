namespace server.Models;

/* DTO class to avoid over-posting. Basically just to create custom views of objects. */
public class TestDTO
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}