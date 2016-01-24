using System.Linq;
using System.Web.Mvc;
using SwiftBookingTest.Web.DAL;
using SwiftBookingTest.Web.Models;
using SwiftBookingTest.Web.Remote;

namespace SwiftBookingTest.Web.Controllers
{
    /// <summary>
    /// Controller class responsible for all the Booking actions
    /// Currently implemented: Create and Submit.
    /// </summary>
    public class BookingController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HomeViewModel homeViewModel)
        {
            if (ModelState.IsValid)
            {
                var newBooking = homeViewModel.BookingViewModel;

                using (var db = new DataContext())
                {
                    db.Bookings.Add(new BookingDataModel()
                    {
                        Name = newBooking.Name,
                        Phone = newBooking.Phone,
                        Address = newBooking.Address
                    });

                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public string Submit(int id)
        {
            //Note: Ideally we would check the users authentication and access levels here before continuing.
            string response = null;
            using (var db = new DataContext())
            {
                var booking = db.Bookings.Where(z => z.Id == id).FirstOrDefault();
                if (booking != null)
                {
                    response = SwiftApi.SubmitBookingRequest(booking);
                }
            }

            return response;
        }
    }
}
