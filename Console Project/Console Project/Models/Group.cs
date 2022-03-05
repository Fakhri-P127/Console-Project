using System;
using System.Collections.Generic;
using System.Text;
using Console_Project.Enums;
using Console_Project.Operations;

namespace Console_Project.Models
{
    class Group
    {
        public static int count = 100;
        public string No;        
        public bool IsOnline;
        public byte Limit;
        public List<Student> GroupStudents;
        public Categories Category;

        public Group(string no, Categories category, bool isonline)
        {            
            //No = no;                                                
            IsOnline = isonline;            
            GroupStudents = new List<Student>();
            switch (category)
            {
                case Categories.Programming:
                    No = $"P-{count}";
                    Console.WriteLine("You chose Programming class");
                    break;
                case Categories.Design:
                    Console.WriteLine("You chose Design class"); 
                    break;
                case Categories.SystemAdministration:
                    Console.WriteLine("You chose System Administration class"); 
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The class you chose does not exist. Please choose valid option");
                    break;
            }
            Category = category;                       
        }               
    }
}
