using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Framework
{
    public sealed class IdGenerator
    {
        private static IdGenerator idGeneratorInstance;
        private int studentId;
        private int teacherId;

        private IdGenerator()
        {
            this.studentId = 0;
            this.teacherId = 0;
        }

        public static IdGenerator Instance
        {
            get
            {
                if (idGeneratorInstance == null)
                {
                    idGeneratorInstance = new IdGenerator();
                }

                return idGeneratorInstance;
            }
        }

        public int StudentId
        {
            get
            {
                return studentId++;
            }
        }

        public int TeacherId
        {
            get
            {
                return teacherId++;
            }
        }
    }
}
