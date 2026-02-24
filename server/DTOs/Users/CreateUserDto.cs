namespace server.DTOs.Users;

public record CreateUserDto(
    string Email,
    string Password,
    string FirstName,
    string LastName
);