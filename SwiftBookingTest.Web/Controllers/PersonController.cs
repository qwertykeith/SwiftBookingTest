using System.Web.Mvc;
using MvcFlashMessages;
using SwiftBookingTest.Core;
using SwiftBookingTest.Core.Persons.Commands;
using SwiftBookingTest.Core.SwiftApi;

namespace SwiftBookingTest.Web.Controllers
{
    public class PersonController : Controller
    {
        private readonly IContext _context;
        private readonly ISwiftClient _swiftClient;

        public PersonController(IContext context, ISwiftClient swiftClient)
        {
            _context = context;
            _swiftClient = swiftClient;
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
            var result = new BookPersonCommandContext(_context, _swiftClient)
                                .Execute(new BookPersonCommand
                                {
                                    PersonId = personId
                                });

            this.Flash("info", result.Message);

            return RedirectToAction("Index", "Home");
        }
    }
}
