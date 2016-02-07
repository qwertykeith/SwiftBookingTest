namespace SwiftBookingTest.Core.Persons.Commands
{
    public class BookPersonCommandContext: ICommandContext<BookPersonCommand, BookPersonCommandResult>
    {
        public BookPersonCommandResult Execute(BookPersonCommand command)
        {
            return new BookPersonCommandResult
            {
                Message = "Something happened!"
            };
        }
    }

    public class BookPersonCommandResult
    {
        public string Message { get; set; }
    }

    public class BookPersonCommand
    {
        public int PersonId { get; set; }
    }
}
