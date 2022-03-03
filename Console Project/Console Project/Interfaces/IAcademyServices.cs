using Console_Project.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Project.Interfaces
{
    interface IAcademyServices
    {
        public string CreateGroup(string no, bool isonline, Categories category);
        public void ShowAllGroups();
        public void EditGroup(string no, string newNo);
        public void ShowStudentsInGroup();
        public void ShowAllStudents();
        public string CreateStudent(string fullname, string no);

    }
}
