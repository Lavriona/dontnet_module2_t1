using System;
using Training.Business.Models;

namespace Training.Business.Controllers
{
        public class GroupController
        {
            /// <summary>
            /// Create Group
            /// </summary>
            /// <returns>Group group</returns>
            public static Group Create()
            {
                Console.WriteLine("Введите название группы: ");

                Group group = new Group();

                group.Name = Console.ReadLine();

                return group;
            }

            /// <summary>
            /// Show Group List
            /// </summary>
            /// <param name="groups">Group[] for show</param>
            public static void Show(Group[] groups)
            {
                for (int i = 0; i < groups.Length; i++)
                {
                    Console.WriteLine($"\r\nГруппа {groups[i].Name} \r\n{new string('-', 45)}");

                    Console.WriteLine($"Преподаватель: {groups[i].Teacher.Fullname} ({groups[i].Teacher.Type}) \r\n{new string('-', 45)}");

                    Console.WriteLine($"Студенты: \r\n{new string('-', 45)}");

                    StudentController.Show(groups[i].students, false);
                }
            }
        }
}
