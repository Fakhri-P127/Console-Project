using System;
using System.Collections.Generic;
using System.Text;
using Console_Project.Enums;
using Console_Project.Operations;

namespace Console_Project.Models
{
    class Group
    {
        //public static int count = 0;
        public string No;        
        public bool IsOnline;
        public byte Limit;
        public List<Student> GroupStudents;
        public Categories Category;

        public Group(string no, Categories category, bool isonline)
        {            
            bool result1 = CheckGroupNo(no);
            if (result1)
            {
                No = no;
            }
            
            if (isonline)
            {
                Limit = 15;                
            }
            else
            {
                Limit = 10;
            }
            
            IsOnline = isonline;
            GroupStudents = new List<Student>(Limit);
            switch (category)
            {
                case Categories.Programming:
                    Console.WriteLine("You chose Programming class");
                    break;
                case Categories.Design:
                    Console.WriteLine("You chose Design class"); 
                    break;
                case Categories.SystemAdministration:
                    Console.WriteLine("You chose System Administration class"); 
                    break;
                default:
                    Console.WriteLine("The class you chose does not exist. Please choose valid option");
                    break;
            }
            Category = category;                       
        }
        public static bool CheckGroupNo(string groupno)
        {
            if (groupno.Length == 4 && char.IsUpper(groupno[0]))
            {
                for (int i = 1; i < groupno.Length; i++)
                {
                    if (!char.IsDigit(groupno[i]))
                    {
                        Console.WriteLine("After the first uppercase all 3 characters must be a digit");
                        return false;
                    }
                }
                return true;
            }
            else
            {
                Console.WriteLine("GroupNo needs to be 4 characters long. First character must be an uppercase letter and last 3 characters should be all digits");
                return false;
            }
        }
    }
}
