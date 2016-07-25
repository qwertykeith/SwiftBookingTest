using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Model.Validators
{
    public class ClientRecordValidator : AbstractValidator<ClientRecord>
    {
        public ClientRecordValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
