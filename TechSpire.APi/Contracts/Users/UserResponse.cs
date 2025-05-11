namespace SurvayBasket.Application.Contracts.Users;

public record UserResponse
(
    string Id,
    string FirstName,
    string LastName,
    string Email,
    bool IsDisable,
    IEnumerable<string> Roles

    );
