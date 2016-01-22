using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Core.Common
{
    public abstract class ServiceBase
    {        
        protected ServiceBase()
        {

        }

        protected void EnsureValid(EntityBase entity)
        {
            var errors = entity.GetValidationErrors();

            if (errors.Any())
            {
                throw new ValidationException(errors);
            }
        }        
    }
}
