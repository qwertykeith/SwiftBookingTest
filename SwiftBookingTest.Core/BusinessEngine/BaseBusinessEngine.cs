using SwiftBookingTest.CoreContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftBookingTest.Model;

namespace SwiftBookingTest.Core.BusinessEngine
{
    public class BaseBusinessEngine : IBusinessEngine
    {
        private ISwiftDemoUow _uow;
        public ISwiftDemoUow Uow
        {
            get
            {
                return _uow;
            }

            set
            {
                _uow = value;
            }
        }

        public bool IsNull(BaseClass entity, bool checkId = false)
        {
            if (!checkId)
                return entity == null;
            else
                return entity == null && entity.Id <= 0;
        }

    }
}
