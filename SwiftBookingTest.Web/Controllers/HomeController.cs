using System.Linq;
using System.Web.Mvc;
using SwiftBookingTest.Web.DAL;
using SwiftBookingTest.Web.Models;

namespace SwiftBookingTest.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new SwiftDataContext())
            {
                //Attempt to retrieve the model object and modelstate from TempData - only present on validation failure
                var homeViewModel = TempData["HomeViewModelTemp"] as HomeViewModel;
                var modelState = TempData["ModelState"] as ModelStateDictionary;
              
                //If model is not null, we've had a validation error, merge the model state back in.
                if (homeViewModel != null && modelState != null)
                {
                    ModelState.Merge(modelState);
                }
                else 
                {
                    homeViewModel = new HomeViewModel();
                }

                //Grab any existing bookings, ideally would be cached.
                homeViewModel.SavedBookings = db.Bookings.ToList().Select(z => BookingViewModel.FromDb(z)); 

                return View(homeViewModel);
            }
        }

    }
}
