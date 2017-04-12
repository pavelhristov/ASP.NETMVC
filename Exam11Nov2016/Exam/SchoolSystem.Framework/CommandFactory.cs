using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Framework
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IDictionary<string, Func<ICommand>> commands;

        public CommandFactory(IStudentFactory studentFactory, ITeacherFactory teacherFactory)
        {
            commands = new Dictionary<string, Func<ICommand>>
                        {
                            {"CreateStudent", () => new CreateStudentCommand(studentFactory)},
                            {"CreateTeacher", () => new CreateTeacherCommand(teacherFactory)},
                            {"RemoveStudent", () => new RemoveStudentCommand()},
                            {"RemoveTeacher", () => new RemoveTeacherCommand()},
                            {"StudentListMarks", () => new StudentListMarksCommand()},
                            {"TeacherAddMark", () => new TeacherAddMarkCommand()}
                        };
        }

        public ICommand GetCommand(string commandName)
        {
            Func<ICommand> command;
            commands.TryGetValue(commandName, out command);
            return command();
        }
    }
}
