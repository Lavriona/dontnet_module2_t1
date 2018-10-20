using System;
using Training.Business.Models;

namespace Training.Business.Controllers
{
    public class StudentController
    {
        /// <summary>
        /// Create Student in current group
        /// </summary>
        /// <param name="group">Current group</param>
        /// <returns></returns>
        public static Student Create(Group group)
        {
            Console.WriteLine("\r\nВведите ФИО студента:");

            Student student = new Student();

            student.Fullname = Console.ReadLine();

            student.group = group;

            return student;
        }

        /// <summary>
        /// Show Students
        /// </summary>
        /// <param name="students">Students for show</param>
        /// <param name="showGroup">bool</param>
        public static void Show(Student[] students, bool showGroup = true)
        {
            for (int i = 0; i < students.Length; i++)
            {
                Console.Write($"{i + 1} - {students[i].Fullname} ");

                if (showGroup)
                {
                    Console.Write($"({students[i].group.Name})");
                }
                Console.WriteLine();
            }
        }
    }
}
