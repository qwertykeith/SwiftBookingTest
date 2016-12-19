using SwiftBookingTest.Core.Helpers;
using SwiftBookingTest.Model;
using System;
using System.Data.Entity;
using System.Reflection;

namespace SwiftBookingTest.Core.Extensions
{
    public static class ExtensionHelper
    {
        public static void ApplyStateChange(this DbContext dbContext)
        {
            foreach (var entry in dbContext.ChangeTracker.Entries<IObjectWithState>())
            {
                IObjectWithState stateInfo = entry.Entity;
                entry.State = StateHelpers.ConvertsState(stateInfo.State);
            }
        }

        public static void ResetStateToUnchange(this IObjectWithState entity)
        {
            Type type = entity.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var pp = property;
            }
        }

    }
}
