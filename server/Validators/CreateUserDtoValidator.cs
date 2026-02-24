using FluentValidation;
using server.DTOs.Users;

namespace server.Validators;

public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserDtoValidator()
    {
        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("E-mail address cannot be empty.")
            .EmailAddress().WithMessage("Invalid e-mail address format.");

        RuleFor(u => u.Password)
            .NotEmpty().WithMessage("Password cannot be empty.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters.")
            .Must(BeStrongPassword)
            .WithMessage("Password must contain at least one uppercase letter and one number.");
        
        RuleFor(u => u.FirstName)
            .NotEmpty().WithMessage("First name cannot be empty.")
            .Matches("^[A-Za-z]+$").WithMessage("First name can only contain letters.");

        RuleFor(u => u.LastName)
            .NotEmpty().WithMessage("Last name cannot be empty.")
            .Matches("^[A-Za-z]+$").WithMessage("Last name can only contain letters.");
    }

    private bool BeStrongPassword(string password) =>
        password.Any(char.IsUpper) && password.Any(char.IsDigit);
}