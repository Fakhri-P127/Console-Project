﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Project.Models
{
    class Student
    {
        public string Fullname;
        public string GroupNo;
        public bool IsWarranted;

        public Student(string fullname, string groupno, bool iswarranted)
        {
            Fullname = fullname;
            GroupNo = groupno;
            IsWarranted = iswarranted;
        }        
    }
}
