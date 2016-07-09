using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Model.Validators
{
    public class ClientPhoneValidator : AbstractValidator<ClientPhone>
    {
        public ClientPhoneValidator()
        {
            RuleFor(x => x.PhoneNumberId)
                .NotEmpty()
                .WithMessage("PhoneNumberId is required")
                .When(x => x.State != State.Added);

            RuleFor(x => x.ClientRecordId)
                .NotEmpty()
                .WithMessage("ClientRecordId is required")
                .When(x => x.State != State.Added);
        }

    }
}
