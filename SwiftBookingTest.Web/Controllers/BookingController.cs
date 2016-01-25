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
                using (var db = new SwiftDataContext())
                {
                    db.Bookings.Add(new BookingDataModel()
                    {
                        Name = homeViewModel.BookingViewModel.Name,
                        Phone = homeViewModel.BookingViewModel.Phone,
                        Address = homeViewModel.BookingViewModel.Address
                    });

                    db.SaveChanges();
                }
            }
            else
            {
                //Store the model and modelstate in temp data to be retrieved in the Home controller
                TempData["ModelState"] = ModelState;
                TempData["HomeViewModelTemp"] = homeViewModel; 
            }

            //Redirect to home controller on model valitaiton error.
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Function that calls the GetSwift api to submit the delivery.
        /// Implemented in a very bare-bones synchronous fashion returning the raw output.
        /// Currently not tracking which items have been submitted or their status.
        /// </summary>
        /// <param name="id">Id of the booking to be submitted</param>
        /// <returns></returns>
        [HttpPost]
        public string Submit(int id)
        {
            //Note: Ideally we would check the users authentication and access levels here before continuing.
            string response = null;
            using (var db = new SwiftDataContext())
            {
                var booking = db.Bookings.FirstOrDefault(z => z.Id == id);

                if (booking != null)
                {
                    response = SwiftApi.SubmitBookingRequest(booking);
                }
                else
                {
                    response = "Bad Request"; //Booking not found
                }
            }

            return response;
        }
    }
}
