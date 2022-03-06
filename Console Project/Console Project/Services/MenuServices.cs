using Console_Project.Enums;
using Console_Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Project.Operations
{
    static class MenuServices
    {
        public static AcademyService academyService = new AcademyService();

        public static void MenuCreateGroup()
        {
            #region attempts
            //Console.WriteLine("Insert a GroupNo:");
            //string strNo = Console.ReadLine();
            //bool isonline;
            //Console.WriteLine("Is this group online?\nEnter: yes/no");
            //string str = Console.ReadLine();
            //if (str == "yes")
            //{
            //    isonline = true;
            //}
            //else if (str == "no")
            //{
            //    isonline = false;
            //}
            //else
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("Enter only 'yes' or 'no'");
            //    return;
            //}
            //foreach (Group item in Group)
            //{
            //    item.
            //    Console.WriteLine($"");
            //}
            //string numStr = Console.ReadLine();
            //bool result = int.TryParse(numStr, out int num);
            //switch (num)
            //{
            //    case 1:
            //        Console.WriteLine("You Chose Online");
            //        break;
            //    case 2:
            //        Console.WriteLine("You Chose Offline");
            //        break;
            //    default:
            //        Console.WriteLine("Please enter valid number");
            //        break;
            //}

            //byte limit=0;

            #endregion
            bool isonline;            
            Console.WriteLine("Is this group online?(Press 1 or 2)\n1.Yes\n2.No");            
            string str = Console.ReadLine();
            bool result = int.TryParse(str, out int num);
            if (result)
            {
                switch (num)
                {
                    case 1:
                        isonline = true;
                        break;
                    case 2:
                        isonline = false;                        
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Input 1 or 2");
                        return;                                          
                }                
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Input 1 or 2");
                return;
            }                
            Console.WriteLine("Choose the category:");
            foreach (Categories item in Enum.GetValues(typeof(Categories)))
            {
                Console.WriteLine($"{(int)item}.{item}");
            }
            string strCategory = Console.ReadLine();
            bool result1 = int.TryParse(strCategory, out int category);
            if (result1)
            {
                switch (category)
                {
                    case (int)Enums.Categories.Design:
                        academyService.CreateGroup(Categories.Design,isonline);                        
                        break;
                    case (int)Enums.Categories.Programming:
                        academyService.CreateGroup(Categories.Programming,isonline);
                        break;
                    case (int)Enums.Categories.SystemAdministration:
                        academyService.CreateGroup(Categories.SystemAdministration,isonline);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please choose a valid option");
                        break;
                }                
            }            
        }
        public static void MenuShowAllGroups()
        {
            academyService.ShowAllGroups();
        }
        public static void MenuEditGroupNo()
        {
            Console.WriteLine("Enter the group no you want to change");
            string no = Console.ReadLine();
            Console.WriteLine("Enter the group no you want to change into");
            string newNo = Console.ReadLine();
            academyService.EditGroupNo(no, newNo);
        }
        public static void MenuShowStudentsInGroup()
        {
            Console.WriteLine("Which group's students do you want to see?");
            string no = Console.ReadLine();
            academyService.ShowStudentsInGroup(no);
        }
        public static void MenuShowAllStudents()
        {
            academyService.ShowAllStudents();
        }
        public static void MenuCreateStudent()
        {
            Console.WriteLine("Enter Students Fullname");
            string fullname = Console.ReadLine();
            Console.WriteLine("Enter the groupno");
            string groupNo = Console.ReadLine();
            
            #region minorities
            //bool iswarranted;
            //string strScore = Console.ReadLine();
            //bool resultScore = byte.TryParse(strScore, out byte score);
            //if (resultScore)
            //{
            //    if (score >= 50 && score <= 100)
            //    {
            //        iswarranted = true;
            //    }

            //    else if (score<50 && score>=0)
            //    {
            //        iswarranted = false;
            //    }
            //    else
            //    {
            //        Console.ForegroundColor = ConsoleColor.Red;                   
            //        Console.WriteLine("Score must be between 0 and 100");
            //        return;
            //    }                
            //}
            //else
            //{
            //    Console.ForegroundColor = ConsoleColor.Red; 
            //    Console.WriteLine("Enter num value");
            //    return;
            //}           
            #endregion
            academyService.CreateStudent(fullname, groupNo);            
        }
        }
    }
