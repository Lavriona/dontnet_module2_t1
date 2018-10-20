using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Business.Models
{
    public class Group
    {
        public Student[] students;

        public string Name { get; set; }

        public Teacher Teacher { get; set; }

        public byte CountStudents
        {
            get
            {
                switch (Teacher.type)
                {
                    case (byte)Teacher.EnumTypes.Docent:
                        return 20;

                    case (byte)Teacher.EnumTypes.Lecturer:
                        return 15;

                    case (byte)Teacher.EnumTypes.Assistant:
                    default:
                        return 5;
                }
            }
        }

    }
}
