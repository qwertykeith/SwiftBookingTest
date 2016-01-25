using System;
using System.Collections.Generic;

namespace SwiftBookingTest.Web.Models
{
    /// <summary>
    /// Simple container class to encapsulate the functionality on the home page.
    /// </summary>
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            this.BookingViewModel = new BookingViewModel();
        }

        public BookingViewModel BookingViewModel { get; set; }

        public IEnumerable<BookingViewModel> SavedBookings { get; set; }
    }
}