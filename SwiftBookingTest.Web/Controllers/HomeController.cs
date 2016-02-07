using System.Linq;
using System.Web.Mvc;
using SwiftBookingTest.Core;
using SwiftBookingTest.Web.Models;

namespace SwiftBookingTest.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContext _database;

        public HomeController(IContext database)
        {
            _database = database;
        }

        //
        // GET: /Home/
        
        public ActionResult Index()
        {
            return View(new PersonsViewModel
            {
                SavedPeople = _database.Persons.ToArray()
            });
        }

    }
}
