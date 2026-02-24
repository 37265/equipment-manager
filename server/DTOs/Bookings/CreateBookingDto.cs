namespace server.DTOs.Bookings;

public record CreateBookingDto(
    DateTime? ScheduledStart,
    DateTime? ScheduledEnd,
    int? UserID,
    int? ProductID
);