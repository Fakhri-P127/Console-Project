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
        public List<Group> Groups { get; } = new List<Group>();

        public List<Student> Students { get; } = new List<Student>();

        public void CreateGroup(Categories category, bool isonline)
        {
            // birazdan calis ki 1ci kateqoriyani istesin sonra online olub olmamagini
            //birdeki, komekci metodlardaki cw leri sil esas metodlarda yaz. Birde Clear, ConsoleColor ucun ayrica bir metod yarat gorunus adli 
            
            Group group = new Group(category,isonline);
            if (!CheckGroupNo(group))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{group.No} already exists.");
                return;
            }           
            group.Limit = isonline ? group.Limit = 15 : group.Limit = 10;            
            Console.WriteLine($"Created GroupNo: {group.No}\n");
            Groups.Add(group);           
        }
        public bool CheckGroupNo(Group currentGroup)
        {
            //if the groupNo of the group changed, this makes sure that you can't create group with the same groupNo
            foreach (var group in Groups)
            {
                if (group.No == currentGroup.No)
                {
                    return false;
                }                
            }
            return true;
        }        
        public void ShowAllGroups()
        {
            if (Groups.Count == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There's no group that exists");
                return;
            }
            foreach (Group group in Groups)
            {
                Console.WriteLine(group);                
            }
        }        
        public void EditGroupNo(string no, string newNo)
        {
            if (Groups.Count == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Group exists");
                return;
            }
            Group existGroup = FindGroup(no);            
            if (existGroup == null)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please input valid group no value");
                return;
            }
            if (existGroup.No.ToLower().Trim() == newNo.ToLower().Trim())
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This group already exists");
                return;
            }
            foreach (var item in Groups)
            {
                if (item.No == existGroup.No)
                {
                    Console.WriteLine($"{item.No} Exists");// BUNA BAXXXXXXXXXX
                    return;
                }
            }
            existGroup.No = newNo;
            
            foreach (Student student in existGroup.GroupStudents)//When calling ShowAllStudents() after EditGroupNo() it shows the old groupNo. This code is preventing that.                                                                 
            {
                student.GroupNo = newNo;
            }
            
            Console.WriteLine($"{no} Hall has been successfuly changed to {newNo}\n");
        }
        public Group FindGroup(string no)
        {            
            foreach (Group group in Groups)
            {
                if (group.No.ToLower().Trim() == no.ToLower().Trim())
                {
                    return group;
                }
            }
            return null;
        }
        public void ShowStudentsInGroup(string no)
        {            
            Group group = FindGroup(no);
            if (group == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter valid input");
                return;
            }
            if (group.GroupStudents.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There's no students in this group");
                return;
            }
            if(no.ToLower().Trim() == group.No.ToLower().Trim())
            {
                foreach (Student student in group.GroupStudents)
                {
                    Console.WriteLine(student);                   
                }
            }       
        }        
        public void ShowAllStudents()
        {            
            if (Students.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There's no students.");
                return;
            }
            foreach (Student student in Students)
            {
                Console.WriteLine(student);               
            }            
        }
        public void CreateStudent(string fullname,string groupNo)
        {
            if (Groups.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There's no group to add Students");
                return;
            }
            Group group = FindGroup(groupNo);
            
            if(group == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter a group that exists");
                return;
            }                                    
            if (!CheckFullname(fullname))                
            {   
                return;                
            }
            if (group.Limit-1 < group.GroupStudents.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"You passed the limit. This Group's max limit is {group.Limit}");
                return;
            }
            //bunlari menuya atmaq olar belke
            Console.WriteLine("Choose:");
            Console.WriteLine("1.With Warranty\n2.Without Warranty");
            Student student = new Student(fullname, groupNo);            
            CheckIfWarranted(student);
            Console.WriteLine($"Created Student {fullname}");                   
            Students.Add(student);
            group.GroupStudents.Add(student);                                 
        }               
    public static void CheckIfWarranted(Student student)
        {
            string str = Console.ReadLine();
            bool result = int.TryParse(str, out int num);
            if (result)
            {
                switch (num)
                {
                    case 1:
                        student.IsWarranted = true;
                        break;
                    case 2:
                        student.IsWarranted = false;
                        break;
                }
            }
            else
            {
                Console.WriteLine("Input num value");
                return;
            }            
        }        
        public static bool CheckFullname(string fullname)
        {
            bool notAllLowerFirstName = false;
            bool notAllLowerLastName = false;

            string[] splitFullname = fullname.Split(" ");
            if (splitFullname.Length == 2) //2 cunki(name and surname)
            {
                if (char.IsUpper(splitFullname[0][0]) && char.IsUpper(splitFullname[1][0]))
                {
                    for (int i = 1; i < splitFullname[0].Length; i++)
                    {
                        if (!char.IsLower(splitFullname[0][i]))
                        {
                            notAllLowerFirstName = true;
                        }
                    }
                    for (int i = 1; i < splitFullname[1].Length; i++)
                    {
                        if (!char.IsLower(splitFullname[1][i]))
                        {
                            notAllLowerLastName = true;
                        }
                    }
                    if (!notAllLowerFirstName && !notAllLowerLastName)
                    {
                        return true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("After an Uppercase(in name and surname) all characters should be lowercase");
                        return false;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Name and Surname has to start with an Uppercase ");
                    return false;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fullname must include 3 parts: Name + Space + Surname. Example(Fakhri Afandiyev)");
                return false;
            }
        }
    }
}
#region attempts
//if (no.Length == 0)
//{
//    Console.Clear();
//    Console.ForegroundColor = ConsoleColor.Red;
//    Console.WriteLine("Please input valid GroupNo value.");
//    return;
//}
//if (!CheckGroupNo(no))
//{
//    Console.Clear();
//    Console.ForegroundColor = ConsoleColor.Red;
//    Console.WriteLine("GroupNo needs to be 4 characters long. First character must be an uppercase letter and last 3 characters should be digits");
//    return;
//}
//foreach (Group group1 in Groups)
//{
//    if (group1.IsOnline)
//    {
//        group1.Limit = 15;
//    }
//    else
//    {
//        group1.Limit = 1;
//    }
//CheckIfOnline(group);
//}                //public static void CheckIfOnline(Group group)
//{
//    string str = Console.ReadLine();
//    bool result = int.TryParse(str, out int num);
//    if (result)
//    {
//        switch (num)
//        {
//            case 1:
//                group.IsOnline = true;
//                break;
//            case 2:
//                group.IsOnline = false;
//                break;
//            default:
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("Input 1 or 2");
//                break;
//        }
//        group.Limit = group.IsOnline ? group.Limit = 15 : group.Limit = 10;

//    }
//    else
//    {
//        Console.WriteLine("Input num value");
//        return;
//    }

//}//public bool Pff(Student student)
//{
//    for (int i = 0; i < Students.Count; i++)
//    {
//        if (student.Fullname == Groups[0].GroupStudents[i].Fullname )
//        {
//            return false;
//        }
//    }


//    return true;
//}     
#endregion
#region 
//if (!Pff(student))
//{
//    Console.Clear();
//    Console.ForegroundColor = ConsoleColor.Red;
//    Console.WriteLine($"{student.Fullname} is already in this group");
//    return;
//}
//public bool Pff(Student student)
//{
//    foreach (var item in Groups)
//    {
//        foreach (var item1 in item.GroupStudents)
//        {
//            if (student.Fullname == item1.Fullname)
//            {
//                return false;
//            }
//        }
//    }
//    return true;
//}
#endregion