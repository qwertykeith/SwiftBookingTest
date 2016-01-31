using SwiftBookingTest.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Bootstrap
{
    public static class DbInitializer
    {
        public static void InitializeDB()
        {
            Database.SetInitializer(new PersonInitializer());            
        }
    }
}
