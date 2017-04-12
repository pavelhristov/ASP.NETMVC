using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Models;

namespace SchoolSystem.Framework
{
    public class TeacherFactory : ITeacherFactory
    {
        public ITeacher GetTeacher(string firstName, string lastName, Subject subject)
        {
            return new Teacher(firstName, lastName, subject);
        }
    }
}
