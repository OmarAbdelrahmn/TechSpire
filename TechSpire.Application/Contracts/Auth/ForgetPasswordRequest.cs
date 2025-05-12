using System.ComponentModel.DataAnnotations;

namespace TechSpire.Application.Contracts.Auth;

public record ForgetPasswordRequest
(
    [EmailAddress]
    [Required]
    string Email
    );
