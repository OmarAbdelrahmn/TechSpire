using FluentValidation;
//using SurveyBasket.Contracts.Auth;

namespace SurvayBasket.Application.Contracts.Auth;

public class ResendEmailRequestValidator : AbstractValidator<ResendEmailRequest>
{
    public ResendEmailRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
    }
}
