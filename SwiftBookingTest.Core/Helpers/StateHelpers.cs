using SwiftBookingTest.Model;
using System.Data.Entity;

namespace SwiftBookingTest.Core.Helpers
{
    public class StateHelpers
    {
        public static EntityState ConvertsState(State state)
        {
            switch (state)
            {
                case State.Added:
                    return EntityState.Added;
                case State.Modified:
                    return EntityState.Modified;
                case State.Deleted:
                    return EntityState.Deleted;
                default:
                    return EntityState.Unchanged;
            }
        }
    }
}
