using System.ComponentModel.DataAnnotations;

namespace SurvayBasket.Application.Contracts.Auth;

public record ForgetPasswordRequest
(
    [EmailAddress]
    [Required]
    string Email
    );
