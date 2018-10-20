using System;
using Training.Business.Models;
using Training.Business.Helpers;

namespace Training.Business.Controllers
{
    public class TeacherController
    {
        /// <summary>
        /// Create Teacher in current group
        /// </summary>
        /// <param name="group">Current group</param>
        /// <returns></returns>
        public static Teacher Create(Group group)
        {
            Console.WriteLine("\r\nВведите ФИО преподователя: ");

            Teacher teacher = new Teacher();

            teacher.Fullname = Console.ReadLine();

            teacher.group = group;

            while (true)
            {
                Console.WriteLine("\r\nВведите тип преподавателя: ");

                int j = 0;
                foreach (var type in Enum.GetNames(typeof(Teacher.EnumTypes)))
                {
                    j++;
                    Console.WriteLine($"{j} - {type}");
                }

                string inputTeacherType = Console.ReadLine();

                if (byte.TryParse(inputTeacherType, out byte teacherType) && Enum.GetName(typeof(Teacher.EnumTypes), --teacherType) != null)
                {
                    teacher.Type = teacherType.ToString();

                    break;
                }
                else
                {
                    Helper.ShowMessage("Такого типа нет в системе!");
                }
            }

            return teacher;
        }

        /// <summary>
        /// Show teachers
        /// </summary>
        /// <param name="teachers">Teachers for show</param>
        public static void Show(Teacher[] teachers)
        {
            for (int i = 0; i < teachers.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {teachers[i].Fullname} ({teachers[i].Type}, {teachers[i].group.Name})");
            }
        }
    }
}
