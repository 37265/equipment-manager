using server.Models;

namespace server.DTOs.Bookings;

public record BookingMinimalDto(
    int ID,
    DateTime ScheduledStart,
    DateTime ScheduledEnd,
    string Status,
    int ProductID
);