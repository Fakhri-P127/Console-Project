﻿using Console_Project.Enums;
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
            Console.WriteLine("Insert a GroupNo:");
            string strNum = Console.ReadLine();
            bool isonline = false;
            Console.WriteLine("Is this group online?\nEnter only: yes/no");            
            string str = Console.ReadLine();
            if (str == "yes")
            {
                isonline = true;
            }
            else if (str == "no")
            {
                isonline = false;
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter only 'yes' or 'no'");
                return;
            }
            if (AcademyService.CheckGroupNo(strNum))//bunu silib yoxla ve academyservice deki conditionları commentden çıxar
            {
                Console.WriteLine("Choose the category you want to study in");                
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
                        case (int)Enums.Categories.Design:
                            academyService.CreateGroup(strNum, isonline ,Categories.Design);                              
                            break;
                        case (int)Enums.Categories.Programming:
                            academyService.CreateGroup(strNum, isonline, Categories.Programming);
                            break;
                        case (int)Enums.Categories.SystemAdministration:
                            academyService.CreateGroup(strNum, isonline, Categories.SystemAdministration);
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please choose a valid option");
                            break;
                    }
                }                       
            }                      
        }
        public static void MenuShowAllGroups()
        {
            academyService.ShowAllGroups();            
        }

        public static void MenuEditGroup()
        {
            if (academyService.Groups.Count == 0)
            {
                Console.WriteLine("No Group exists");
                return;
            }
            Console.WriteLine("Enter the group no you want to change");
            string no = Console.ReadLine();
            Console.WriteLine("Enter the group you want to change into");
            string newNo = Console.ReadLine();
            academyService.EditGroup(no, newNo);
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
            string newGroup = Console.ReadLine();
            Console.WriteLine("Enter the score they got");
            bool iswarranted;// bunu ve isonline i group,studentde false edib yoxla(optimizasiya üçün)
            string strScore = Console.ReadLine();
            bool resultScore = byte.TryParse(strScore, out byte score);
            if (resultScore)
            {
                if (score >= 50 && score <= 100)
                {
                    iswarranted = true;
                }
                else// else if(score<50 && score>=0) ele
                {
                    iswarranted = false;
                }  
              //Else{
Cw $"The score must be between 0 and 100"
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Write valid value");
                return;
            }           
            academyService.CreateStudent(fullname, newGroup,iswarranted);           
        }
    }
}
