using Console_Project.Enums;
using Console_Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Project.Interfaces
{
    interface IAcademyServices
    {
        public void CreateGroup(string no, bool isonline, Categories category);
        public void ShowAllGroups();
        public void EditGroup(string no, string newNo);
        public void ShowStudentsInGroup(string no);
        public void ShowAllStudents();
        public void CreateStudent(string fullname, string no, bool iswarranted);
    }
}
