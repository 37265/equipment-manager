using FluentValidation;
using server.DTOs.Bookings;

namespace server.Validators;

public class CreateBookingDtoValidator : AbstractValidator<CreateBookingDto>
{
    public CreateBookingDtoValidator()
    {
        /* It's better to use NotNull than NotEmpty, because NotEmpty checks against the default 
        value for a data type. NotNull explicitly checks nullity. */
        RuleFor(b => b.ScheduledStart)
            .Cascade(CascadeMode.Stop) // Makes sure validation stops as soon as one failure occurs
            .NotNull().WithMessage("Start time not specified.")
            .Must(BeInFuture).WithMessage("Booking cannot start before current time.");

        RuleFor(b => b.ScheduledEnd).NotNull().WithMessage("End time not specified.");

        RuleFor(b => b).Must(HaveValidDateRange).WithMessage("End time must be after start time.");

        RuleFor(b => b.UserID).NotNull().WithMessage("User ID not specified.");

        RuleFor(b => b.ProductID).NotNull().WithMessage("Product ID not specified.");
    }

    private static bool BeInFuture(DateTime? start) => start > DateTime.UtcNow;

    private static bool HaveValidDateRange(CreateBookingDto dto) => 
        dto.ScheduledStart.HasValue && dto.ScheduledEnd.HasValue && 
        dto.ScheduledEnd > dto.ScheduledStart;
}