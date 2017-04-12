using NUnit.Framework;
using SchoolSystem.Framework;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Tests.RemoveStudentCommandTests
{

    [TestFixture]
    public class ExecuteMethodShould
    {
        [Test]
        public void SuccesfullyRemoveStudent()
        {
            // Arrange
            string firstName = "pesho";
            string lastName = "peshov";
            string grade = "7";
            IList<string> args = new List<string>() { firstName, lastName, grade };

            var studentFactory = new StudentFactory();
            var createStudentCommand = new CreateStudentCommand(studentFactory);
            var removeStudentCommand = new RemoveStudentCommand();

            // Act
            var createdStudent = createStudentCommand.Execute(args);
            int studentsBeforeRemove = Engine.Students.Count;
            removeStudentCommand.Execute(new List<string>() { "0" });
            int studentsAfterRemove = Engine.Students.Count;

            // Assert
            Assert.AreEqual(studentsBeforeRemove - 1, studentsAfterRemove);
        }
    }
}
