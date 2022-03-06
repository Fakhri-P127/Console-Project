using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Project.Models
{
    class Student
    {
        public string Fullname;
        public string GroupNo;
        public bool IsWarranted;

        public Student(string fullname, string groupno)
        {
            Fullname = fullname;
            GroupNo = groupno;                       
        }
        public override string ToString()
        {
            string status = IsWarranted ? "Yes" : "No";
            return $"Fullname: {Fullname}, GroupNo: {GroupNo}, IsWarranted: {status}";
        }
    }
}
