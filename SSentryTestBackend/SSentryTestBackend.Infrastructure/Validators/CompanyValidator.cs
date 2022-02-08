using FluentValidation;
using SSentryTestBackend.Core.DTOs;

namespace SSentryTestBackend.Infrastructure.Validators
{
    public class CompanyValidator : AbstractValidator<CompanyDto>
    {
        public CompanyValidator()
        {
            RuleFor(c => c.IdentificationTypeId)
                .NotNull()
                .WithMessage("El tipo de identificación es obligatorio.");
        }
    }
}
