using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace server.Models;

public enum Role
{
    User,
    Maintainer,
    Admin
}

public class User
{
    public int Id { get; set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Role Role { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<Booking> Bookings { get; set; }
    public ICollection<Maintenance> CreatedMaintenances { get; set; }
    public ICollection<Maintenance> ClosedMaintenances { get; set; }
}