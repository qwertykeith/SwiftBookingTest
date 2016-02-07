using System.Web.Mvc;
using MvcFlashMessages;
using SwiftBookingTest.Core;
using SwiftBookingTest.Core.Persons.Commands;

namespace SwiftBookingTest.Web.Controllers
{
    public class PersonController : Controller
    {
        private readonly IContext _context;

        public PersonController(IContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            new NewPersonCommandContext(_context)
                .Execute(new NewPersonCommand
                {
                    Person = person
                });

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Book(int personId)
        {
            var result = new BookPersonCommandContext()
                                .Execute(new BookPersonCommand
                                {
                                    PersonId = personId
                                });
            this.Flash("info", result.Message);
            return RedirectToAction("Index", "Home");
        }
    }
}
