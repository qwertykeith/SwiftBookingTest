using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Model.Validators
{
    public class ClientPhoneValidator: AbstractValidator<ClientPhone>
    {
        public ClientPhoneValidator()
        {
            RuleFor(x => x.PhoneNumberId).NotEmpty().WithMessage("PhoneNumberId is required");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("PhoneNumber is required");
            RuleFor(x => x.ClientRecord).NotEmpty();
            RuleFor(x => x.ClientRecordId).NotEmpty();
        }
    }
}
