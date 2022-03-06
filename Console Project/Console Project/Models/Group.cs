using System;
using System.Collections.Generic;
using System.Text;
using Console_Project.Enums;

namespace Console_Project.Models
{
    class Group
    {        
        public string No;        
        public bool IsOnline;
        public byte Limit;
        public List<Student> GroupStudents;
        public Categories Category;
        public static int P_count = 100;
        public static int D_count = 100;
        public static int S_count = 100;

        public Group(Categories category,bool isonline)
        {
            //No = no;                  
            IsOnline = isonline;            
            GroupStudents = new List<Student>();
            
            switch (category)
            {
                case Categories.Programming:
                    No = $"P{P_count}";
                    P_count++;
                    //Console.WriteLine("You chose Programming class");
                    break;
                case Categories.Design:
                    No = $"D{D_count}";
                    D_count++;
                    //Console.WriteLine("You chose Design class"); 
                    break;
                case Categories.SystemAdministration:
                    No = $"S{S_count}";
                    S_count++;
                    //Console.WriteLine("You chose System Administration class"); 
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The class you chose does not exist. Please choose valid option");
                    break;
            }
            Category = category;
        }
        public override string ToString()
        {
            string status = IsOnline ? "Yes" : "No";
            return $"GroupNo: {No}, Category: {Category}, IsOnline: {status}, StudentCount: {GroupStudents.Count}";
        }
    }
}
