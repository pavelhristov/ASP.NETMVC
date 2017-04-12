using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateStudentCommand : ICommand
    {
        private int currentStudentId;
        private IStudentFactory studentFactory;

        public CreateStudentCommand(IStudentFactory studentFactory)
        {
            this.studentFactory = studentFactory;
        }

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);
            currentStudentId = IdGenerator.Instance.StudentId;

            var student = studentFactory.GetStudent(firstName, lastName, grade);
            Engine.Students.Add(currentStudentId, student);

            return $"A new student with name {firstName} {lastName}, grade {grade} and ID {currentStudentId} was created.";
        }
    }
}
