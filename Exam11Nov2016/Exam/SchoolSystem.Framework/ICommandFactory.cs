using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework
{
    public interface ICommandFactory
    {
        ICommand GetCommand(string commandName);
    }
}
