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
            Console.WriteLine("Choose the category(Press 1, 2 or 3)");
            foreach (Categories item in Enum.GetValues(typeof(Categories)))
            {
                Console.WriteLine($"{(int)item}.{item}");
            }
            string strCategory = Console.ReadLine();
            bool result = int.TryParse(strCategory, out int category);            
            if (result)
            {                
                switch (category)
                {
                    case (int)Enums.Categories.Programming:
                        academyService.CreateGroup(Categories.Programming);
                        return;
                    case (int)Enums.Categories.Design:
                        academyService.CreateGroup(Categories.Design);
                        return;
                    case (int)Enums.Categories.SystemAdministration:
                        academyService.CreateGroup(Categories.SystemAdministration);
                        return;
                    default:
                        AcademyService.ClearAndColor();
                        Console.WriteLine("Please choose a valid option");
                        return;
                }
            }            
            AcademyService.ClearAndColor();
            Console.WriteLine("Input num value(Press 1, 2 or 3)");
            return;                                  
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
            academyService.CreateStudent(fullname, groupNo);            
        }
    }
}