using System;

namespace Training.Business.Models
{
    public class Teacher
    {
        public Group group;

        internal byte type;

        public string Fullname { get; set; }

        public string Type
        {
            get
            {
                return Enum.GetName(typeof(EnumTypes), type);
            }
            set
            {
                type = byte.Parse(value);
            }
        }

        public enum EnumTypes
        {
            Docent,
            Lecturer,
            Assistant
        }
    }
}
