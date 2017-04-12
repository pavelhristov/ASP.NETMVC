﻿using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework
{
    public interface ITeacherFactory
    {
        ITeacher GetTeacher(string firstName, string lastName, Subject subject);
    }
}
