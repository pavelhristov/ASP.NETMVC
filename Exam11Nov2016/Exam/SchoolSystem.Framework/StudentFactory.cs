using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Models;

namespace SchoolSystem.Framework
{
    public class StudentFactory : IStudentFactory
    {
        public IStudent GetStudent(string firstName, string lastName, Grade grade)
        {
            return new Student(firstName, lastName, grade);
        }
    }
}
