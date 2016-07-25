using SwiftBookingTest.CoreContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Core.Repository
{
    public class Logger : ILogger
    {
        private ISwiftDemoUow _uow { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        /// <param name="uow">The uow.</param>
        public Logger(ISwiftDemoUow uow)
        {
            this._uow = uow;
        }
        public void CreateAudit(string description)
        {
            System.Diagnostics.Debug.WriteLine(description);
        }
    }
}
