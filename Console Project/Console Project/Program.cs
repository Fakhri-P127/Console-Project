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
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Course Managment Application");
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
                            Console.ForegroundColor = ConsoleColor.White;
                            MenuServices.MenuEditGroupNo();
                            break;
                        case 4:
                            Console.ForegroundColor = ConsoleColor.Yellow;
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
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You exited the application");
                            break;
                        default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;                            
                            Console.WriteLine("Enter a valid number: ");
                            break;
                    }
                }
                else
                {//tryagain ile herf ve ya bosluq qoyub entera basanda error un qarsini almaq ucun yeniden yazilmasini isteye bilerem amma kecmemisik deye yazmadim.
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You exited the application. Try again and only input numbers through 0 to 6.");
                }                
            } while (num!=0);            
        }
    }
}
