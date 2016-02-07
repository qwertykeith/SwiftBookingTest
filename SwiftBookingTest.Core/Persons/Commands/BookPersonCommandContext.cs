using System.Linq;
using SwiftBookingTest.Core.SwiftApi;

namespace SwiftBookingTest.Core.Persons.Commands
{
    public class BookPersonCommandContext: ICommandContext<BookPersonCommand, BookPersonCommandResult>
    {
        private readonly IContext _context;
        private readonly ISwiftClient _swiftClient;

        public BookPersonCommandContext(IContext context, ISwiftClient swiftClient)
        {
            _context = context;
            _swiftClient = swiftClient;
        }

        public BookPersonCommandResult Execute(BookPersonCommand command)
        {
            var person = _context.Persons.Single(x => x.PersonId == command.PersonId);
            
            var result = _swiftClient.CreateDelivery(person.Address);

            return new BookPersonCommandResult
            {
                Message = result
            };
        }
    }
}
