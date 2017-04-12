using Moq;
using NUnit.Framework;
using SchoolSystem.Framework;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Tests.CreateStudentCommandTests
{
    [TestFixture]
    public class ExecuteMethodShould
    {
        [Test]
        public void ReturnCorrectMessageWithThePassedParameters()
        {
            // Arrange
            string firstName = "pesho";
            string lastName = "peshov";
            string grade = "7";
            string gradeEnum = "Seventh";
            IList<string> args = new List<string>() { firstName, lastName, grade };
            string expectedMessage = $"A new student with name {firstName} {lastName}, grade {gradeEnum} and ID";

            var studentFactory = new StudentFactory();
            var createStudentCommand = new CreateStudentCommand(studentFactory);

            // Act
            var createdStudent = createStudentCommand.Execute(args);

            // Assert
            Assert.IsTrue(createdStudent.Contains(expectedMessage));
        }

        [Test]
        public void AddNewlyCreatedStudentToEngineDictonary()
        {
            // Arrange
            string firstName = "pesho";
            string lastName = "peshov";
            string grade = "7";
            IList<string> args = new List<string>() { firstName, lastName, grade };

            var studentFactory = new StudentFactory();
            var createStudentCommand = new CreateStudentCommand(studentFactory);

            // Act
            var createdStudent = createStudentCommand.Execute(args);

            // Assert
            Assert.IsTrue(Engine.Students.Count == 1);
        }

        [Test]
        public void CallStudentFactoryCreateStudentOnce()
        {
            // Arrange
            int methodCalled = 0;
            string firstName = "pesho";
            string lastName = "peshov";
            string grade = "7";
            IList<string> args = new List<string>() { firstName, lastName, grade };

            // Act
            var mockedFactory = new Mock<IStudentFactory>();
            mockedFactory.Setup(x => x.GetStudent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Grade>())).Returns((string f, string l, Grade g) => { methodCalled++; return new Student(f, l, g); });
            var createStudentCommand = new CreateStudentCommand(mockedFactory.Object);
            var createdStudent = createStudentCommand.Execute(args);

            // Assert
            Assert.IsTrue(methodCalled == 1);
        }
    }
}
