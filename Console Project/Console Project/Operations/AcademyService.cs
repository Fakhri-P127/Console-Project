using System;
using System.Collections.Generic;
using System.Text;
using Console_Project.Enums;
using Console_Project.Interfaces;
using Console_Project.Models;

namespace Console_Project.Operations
{
    class AcademyService : IAcademyServices
    {
        public List<Group> groups = new List<Group>();
        public List<Student> students = new List<Student>();
                
        public string CreateGroup(string no, bool isonline, Categories category)
        {
            if(no.Length==0)
            {
                return "Please write something.";
            }
            if (!CheckGroupNo(no))
            {
                return "Please write GroupNo correctly.";
            }                  
            Console.WriteLine($"Created GroupNo: {no}");
            Group group = new Group(no, category, isonline);
            groups.Add(group);
            if (isonline)
            {
                group.Limit = 15;
            }
            else
            {
                group.Limit = 10;
            }
            return group.No;            
        }
        public void ShowAllGroups()
        {
            if (groups.Count == 0)
            {
                Console.WriteLine("There's no group that exists");
            }

            foreach (Group group in groups)
            {
                Console.WriteLine($"GroupNo: {group.No}\nCategory: {group.Category}\nStudentCount: {students.Count}");//helelik groups.count goster
            }
        }
        public void EditGroup(string no, string newNo)
        {
            Group existGroup = FindGroup(no);
            if (existGroup == null)
            {
                Console.WriteLine("Please input valid value");
                return;
            }
            if (existGroup.No.ToLower().Trim() == newNo.ToLower().Trim())
            {
                Console.WriteLine("This group already exists");
                return;
            }
            existGroup.No = newNo;
            Console.WriteLine($"{no} Hall has been successfuly changed to {newNo}");
        }
        public Group FindGroup(string no)
        {
            foreach (Group group in groups)
            {
                if (group.No.ToLower().Trim() == no.ToLower().Trim())
                {
                    return group;
                }
            }
            return null;
        }
        public void ShowStudentsInGroup(string no, List<Student> students)
        {
            Group group = FindGroup(no);
            if (group == null)
            {
                Console.WriteLine("Write something mf");
                return;
            }
            
            foreach (Student student in group.Students )
            {
                Console.WriteLine(student.Fullname);
            }
        }
        public void ShowAllStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("There's no students.");
                return;
            }
            foreach (Group student in groups)
            {
                Console.WriteLine($"Fullname: {student.Students}\nGroupNo: {student.No}\nIsOnline: {student.IsOnline}");
            }            
        }
        public string CreateStudent(string fullname,string no,bool iswarranted)
        {
            
            Group group = FindGroup(no);
            if(group == null)
            {                
                return "There's no group to add Students";
            }
            if (group.IsOnline)
            {
                if (group.Limit > 15)
                {
                    return "There cant be more than 15 students in online group";
                }            
            }
            else
            {
                if (group.Limit > 10)
                {
                    return "There cant be more than 10 students in offline group";
                }
            }
            if (CheckFullname(fullname))
            {
                Console.WriteLine($"Created Student {fullname}");
                Student student = new Student(fullname, no, iswarranted);
                students.Add(student);
                return student.Fullname;                
            }
            return "Wrong. Write again";
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
        public static bool CheckFullname(string fullname)
        {
            bool notAllLower1 = false;
            bool notAllLower2 = false;

            string[] splitFullname = fullname.Split(" ");
            if (splitFullname.Length == 2) //2 cunki(name and surname)
            {
                if (char.IsUpper(splitFullname[0][0]) && char.IsUpper(splitFullname[1][0]))
                {
                    for (int i = 1; i < splitFullname[0].Length; i++)
                    {
                        if (!char.IsLower(splitFullname[0][i]))
                        {
                            notAllLower1 = true;
                        }
                    }
                    for (int i = 1; i < splitFullname[1].Length; i++)
                    {
                        if (!char.IsLower(splitFullname[1][i]))
                        {
                            notAllLower2 = true;
                        }
                    }
                    if (!notAllLower1 && !notAllLower2)
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("After an Uppercase(in name and surname) all characters should be lowercase");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Name and Surname has to start with an Uppercase ");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Fullname must include 3 parts: Name + Space + Surname. Example(Fakhri Afandiyev)");
                return false;
            }
        }
    }
}
