using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace server.Models;

public enum Role
{
    User = 1,
    Maintainer = 2,
    Admin = 3
}

public class User
{
    public int ID { get; set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Role Role { get; private set; } = Role.User;
    public bool IsActive { get; private set; } = true;
    // DateTimeOffset is preferable to DateTime, because it is the most flexible between time zones
    public DateTimeOffset CreatedAt { get; private set; }

    public ICollection<Booking> Bookings { get; set; }
    public ICollection<Booking> ApprovedBookings { get; set; }
    public ICollection<Maintenance> CreatedMaintenances { get; set; }
    public ICollection<Maintenance> ClosedMaintenances { get; set; }
}
