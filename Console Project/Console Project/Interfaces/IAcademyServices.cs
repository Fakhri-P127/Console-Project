using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Project.Interfaces
{
    interface IAcademyServices
    {
        public string CreateGroup();
        public void ShowAllGroups();
        public void EditGroup();
        public void ShowStudentsInGroup();
        public void ShowAllStudents();
        public string CreateStudent();

    }
}
