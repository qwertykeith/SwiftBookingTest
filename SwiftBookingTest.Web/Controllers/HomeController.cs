using System.Linq;
using System.Web.Mvc;
using SwiftBookingTest.Web.DAL;
using SwiftBookingTest.Web.Models;
using SwiftBookingTest.Web.Remote;

namespace SwiftBookingTest.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new DataContext())
            {
                var homeViewModel = new HomeViewModel
                {
                    BookingViewModel = new BookingViewModel(), //Instantiate blank model
                    SavedBookings = db.Bookings.ToList().Select(z => BookingViewModel.FromDb(z)) //Grab any existing bookings
                };

                return View(homeViewModel);
            }
        }

    }
}
