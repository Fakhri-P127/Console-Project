using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Project.Models
{
    class Student
    {
        public string Fullname;
        public string GroupNo;
        public bool Type;
        public bool Online;

        public Student(string fullname, string groupno)
        {
            Fullname = fullname;
            GroupNo = groupno;
            
        }
        public override string ToString()
        {
            string statusOnline = Online ? "Yes" : "No";
            string statusType = Type ? "Warranted" : "Not Warranted";
            return $"Fullname: {Fullname}, GroupNo: {GroupNo}, Online: {statusOnline}, Type: {statusType}";
        }
    }
}
