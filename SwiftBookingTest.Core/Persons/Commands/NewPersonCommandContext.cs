namespace SwiftBookingTest.Core.Persons.Commands
{
    public class NewPersonCommandContext : ICommandContext<NewPersonCommand, EmptyCommandResult>
    {
        private readonly IContext _context;

        public NewPersonCommandContext(IContext context)
        {
            _context = context;
        }

        public EmptyCommandResult Execute(NewPersonCommand command)
        {
            _context.Persons.Add(command.Person);
            _context.SaveChanges();

            return new EmptyCommandResult();
        }
    }

    public class EmptyCommandResult
    {
    }

    public class NewPersonCommand
    {
        public Person Person { get; set; }
    }
}
