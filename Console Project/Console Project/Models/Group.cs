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
        public List<Student> Students;
        public Categories Category;
        public static int P_count = 100;
        public static int D_count = 100;
        public static int S_count = 100;

        public Group(Categories category)
        {                                       
            Students = new List<Student>();            
            Category = category;
        }
        public override string ToString()
        {           
            return $"GroupNo: {No}, Category: {Category}, StudentCount: {Students.Count}";
        }
    }
}
