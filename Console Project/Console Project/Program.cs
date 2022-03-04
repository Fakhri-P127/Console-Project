using Console_Project.Models;
using Console_Project.Operations;
using System;

namespace Console_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            Console.WriteLine("Hello!");
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                
                Console.WriteLine("1. Create Group");
                Console.WriteLine("2. Show All Groups");
                Console.WriteLine("3. Edit Group");
                Console.WriteLine("4. Show Students in Group");
                Console.WriteLine("5. Show all Students");
                Console.WriteLine("6. Create Student");
                Console.WriteLine("0.Exit");

                string strNum = Console.ReadLine();
                bool result = int.TryParse(strNum, out num);

                if (result)
                {
                    switch (num)
                    {
                        case 1:
                            
                            MenuServices.MenuCreateGroup();
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Green;
                            MenuServices.MenuShowAllGroups();
                            break;
                        case 3:
                            MenuServices.MenuEditGroup();
                            break;
                        case 4:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            MenuServices.MenuShowStudentsInGroup();
                            break;
                        case 5:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            MenuServices.MenuShowAllStudents();
                            break;
                        case 6:
                            MenuServices.MenuCreateStudent();
                            break;
                        case 0:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You exited the program");
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Enter a valid number");
                            break;
                    }
                }

            } while (num!=0);
            

        }
    }
}
