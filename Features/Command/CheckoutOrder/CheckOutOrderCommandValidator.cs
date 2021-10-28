//using FluentValidation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Command.CheckoutOrder
{
    public class CheckoutOrderCommandValidator : AbstractValidator<CheckOutOrderCommand>
    {
        public CheckoutOrderCommandValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{UserName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{UserName} must not exceed 50 characters.");

            RuleFor(p => p.EmailAddress)
               .NotEmpty().WithMessage("{EmailAddress} is required.");

            RuleFor(p => p.Payment)
                .NotEmpty().WithMessage("{Payment} is required.")
                .GreaterThan(0).WithMessage("{Payment} should be greater than zero.");
        }
    }
}
