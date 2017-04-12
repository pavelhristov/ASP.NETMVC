using NUnit.Framework;
using SchoolSystem.Framework;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Commands;
using System.Collections.Generic;

namespace SchoolSystem.Tests.TeacherAddMarkCommandTests
{
    [TestFixture]
    public class ExecuteMethodShould
    {
        [Test]
        public void ReturnCorrectMessage_WithCorrectTeacherAndStudentInformation()
        {
            // Arrange
            string studentFirstName = "pesho";
            string studentLastName = "peshov";
            string grade = "7";

            string teacherFirstName = "ivan";
            string teacherLastName = "ivanov";
            string subject = "1";
            string mark = "2";
            string subjectEnum = "English";

            IList<string> studentArgs = new List<string>() { studentFirstName, studentLastName, grade };
            IList<string> teacherArgs = new List<string>() { teacherFirstName, teacherLastName, subject };

            var studentFactory = new StudentFactory();
            var createStudentCommand = new CreateStudentCommand(studentFactory);

            var teacherFactory = new TeacherFactory();
            var createTeacherCommand = new CreateTeacherCommand(teacherFactory);

            var teacherAddMarkCommand = new TeacherAddMarkCommand();
            string expectedMessage = $"Teacher {teacherFirstName} {teacherLastName} added mark {mark} to student {studentFirstName} {studentLastName} in {subjectEnum}.";

            // Act
            createStudentCommand.Execute(studentArgs);
            createTeacherCommand.Execute(teacherArgs);

            var addMarkMessage = teacherAddMarkCommand.Execute(new List<string>() { "0", "0", mark });

            // Assert
            //Assert.IsTrue(addMarkMessage.Contains($"{teacherFirstName} {teacherLastName}") && addMarkMessage.Contains($"{studentFirstName} {studentLastName}"));
            Assert.IsTrue(addMarkMessage == expectedMessage);
        }

        [Test]
        public void AddMarkOnlyToSpecifiedStudent()
        {
            // Arrange
            string studentFirstName1 = "pesho";
            string studentLastName1 = "peshov";

            string studentFirstName2 = "gosho";
            string studentLastName2 = "goshev";
            string grade = "7";

            string teacherFirstName = "ivan";
            string teacherLastName = "ivanov";
            string subject = "1";
            string mark = "2";

            IList<string> studentArgs1 = new List<string>() { studentFirstName1, studentLastName1, grade };
            IList<string> studentArgs2 = new List<string>() { studentFirstName2, studentLastName2, grade };

            IList<string> teacherArgs = new List<string>() { teacherFirstName, teacherLastName, subject };

            var studentFactory = new StudentFactory();
            var createStudentCommand = new CreateStudentCommand(studentFactory);

            var teacherFactory = new TeacherFactory();
            var createTeacherCommand = new CreateTeacherCommand(teacherFactory);

            var teacherAddMarkCommand = new TeacherAddMarkCommand();

            // Act
            createStudentCommand.Execute(studentArgs1);
            createStudentCommand.Execute(studentArgs2);
            createTeacherCommand.Execute(teacherArgs);

            var addMarkMessage = teacherAddMarkCommand.Execute(new List<string>() { "0", "0", mark });

            // Assert
            Assert.IsTrue(Engine.Students[0].Marks.Count == 1);
            Assert.IsTrue(Engine.Students[1].Marks.Count == 0);
        }
    }
}
