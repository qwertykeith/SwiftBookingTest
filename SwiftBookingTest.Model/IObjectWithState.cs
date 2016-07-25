using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Model
{
    public interface IObjectWithState
    {
        State State { get; set; }
    }
    public enum State
    {
        Unchanged,
        Added,
        Modified,
        Deleted
    }
}
