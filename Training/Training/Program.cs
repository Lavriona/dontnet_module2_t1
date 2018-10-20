using System;
using Training.Business.Models;
using Training.Business.Controllers;
using Training.Business.Helpers;

namespace Training
{
    class Program
    {
        static Group[] groups = new Group[0];
        static Teacher[] teachers = new Teacher[0];
        static Student[] students = new Student[0];

        static void Main(string[] args)
        {
            int groupCount = 0;

            while (true)
            {
                Console.WriteLine("Введите кол-во групп: ");

                string inputGroupCount = Console.ReadLine();

                if (int.TryParse(inputGroupCount, out groupCount))
                {
                    break;

                }
                else
                {
                    Helper.ShowMessage("Введенное значениe не является числом!");
                }
            }

            Array.Resize(ref teachers, teachers.Length + groupCount);

            Array.Resize(ref groups, groups.Length + groupCount);

            for (int i = 0; i < groups.Length; i++)
            {
                Console.Clear();

                Console.WriteLine($"Группа #{i + 1} \r\n");

                groups[i] = GroupController.Create();

                teachers[i] = TeacherController.Create(groups[i]);

                groups[i].Teacher = teachers[i];

                while (true)
                {
                    Console.WriteLine($"\r\nВведите кол-во студенов (не больше {groups[i].CountStudents}):");

                    string inputStudentsCount = Console.ReadLine();

                    if (byte.TryParse(inputStudentsCount, out byte studentsCount))
                    {
                        if (studentsCount <= groups[i].CountStudents)
                        {
                            groups[i].students = new Student[studentsCount];

                            for (int j = 0; j < studentsCount; j++)
                            {
                                groups[i].students[j] = StudentController.Create(groups[i]);

                                Array.Resize(ref students, students.Length + 1);

                                students[students.Length - 1] = groups[i].students[j];
                            }
                            break;
                        }
                        else
                        {
                            Helper.ShowMessage("Введенное значение превышает допустимое кол-во! Распределите в другие группы.");
                        }
                    }
                    else
                    {
                        Helper.ShowMessage("Введенное значение на является числом!");
                    }
                }

            }

            GetOptions();

            Console.ReadKey();
        }

        public static void GetOptions()
        {
            while (true)
            {
                Console.WriteLine("\r\nВведите номер операции:");
                Console.WriteLine("1 - Вывести список студентов");
                Console.WriteLine("2 - Вывести список преподавателей");
                Console.WriteLine("3 - Вывести информацтю по группам");

                string inputOption = Console.ReadLine();

                if (int.TryParse(inputOption, out int option))
                {
                    Console.Clear();
                    switch (option)
                    {
                        case 1:
                            Helper.ShowMessage("\r\nСписок студентов: ", ConsoleColor.Green);
                            StudentController.Show(students);
                            break;
                        case 2:
                            Helper.ShowMessage("\r\nСписок преподавателей: ", ConsoleColor.Green);
                            TeacherController.Show(teachers);
                            break;
                        case 3:
                            Helper.ShowMessage("\r\nИнформация по группам: ", ConsoleColor.Green);
                            GroupController.Show(groups);
                            break;
                        default:
                            Helper.ShowMessage("Номер введенной операции не доступен!");
                            break;
                    }
                }
                else
                {
                    Helper.ShowMessage("Введенное значение не является числом!");
                }
            }
        }
    }
}
