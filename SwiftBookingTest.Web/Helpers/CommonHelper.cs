using SwiftBookingTest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwiftBookingTest.Web.Helpers
{
    public class CommonHelper
    {
        /// <summary>
        /// Gets the swift API url.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <returns></returns>
        public static string GetSwiftApi(string method)
        {
            return string.Format("{0}/{1}/{2}", ApplicationConstants.swiftApi, ApplicationConstants.swiftApiVersion, method);
        }
    }
}