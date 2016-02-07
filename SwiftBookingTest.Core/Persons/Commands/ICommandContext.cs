using System.Collections.Generic;

namespace SwiftBookingTest.Core.Persons.Commands
{
    public interface ICommandContext<TCommand, TCommandResult>
    {
        TCommandResult Execute(TCommand command);
    }
}