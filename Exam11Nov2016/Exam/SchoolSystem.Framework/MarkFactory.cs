using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Models;

namespace SchoolSystem.Framework
{
    public class MarkFactory : IMarkFactory
    {
        public IMark GetMark(Subject subject, float value)
        {
            return new Mark(subject, value);
        }
    }
}
