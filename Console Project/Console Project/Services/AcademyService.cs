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
        public List<Group> AllGroups { get; } = new List<Group>();

        public List<Student> AllStudents { get; } = new List<Student>();

        public void CreateGroup(Categories category)
        {                                  
            Group group = new Group(category);            
            if (!CheckGroupNo(group))
            {
                ClearAndColor();
                Console.WriteLine($"{group.No} already exists.");
                return;
            }
            Console.WriteLine("Is this group online?(Press 1 or 2)\n1.Yes\n2.No");
            if (!CheckIfOnline(group))
            {
                ClearAndColor();
                Console.WriteLine("Input valid num value");
                return;
            }
            //switch category ni burda yazdim cunki Group class inda yazanda CreateGroup() da online olub olmamasini secerken sehv yazsan yenede count++ edirdi.(cunki instance i birinci cagirmisam)
            switch (category)
            {
                case Categories.Programming:
                    group.No = $"P{Group.P_count}";
                    Group.P_count++;
                    break;
                case Categories.Design:
                    group.No = $"D{Group.D_count}";
                    Group.D_count++;
                    break;
                case Categories.SystemAdministration:
                    group.No = $"S{Group.S_count}";
                    Group.S_count++;
                    break;
                default:
                    ClearAndColor();
                    Console.WriteLine("The class you chose does not exist. Please choose valid option");
                    break;
            }          
            group.Limit = group.IsOnline ? group.Limit = 15 : group.Limit = 1;
            AllGroups.Add(group);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Created GroupNo: {group.No}\n");                       
        }
        public bool CheckGroupNo(Group currentGroup)
        {
            //if the groupNo of the group changed, this makes sure that you can't create group with the same groupNo
            foreach (var group in AllGroups)
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
            if (AllGroups.Count == 0)
            {
                ClearAndColor();
                Console.WriteLine("There's no group that exists");
                return;
            }
            foreach (Group group in AllGroups)
            {
                Console.WriteLine(group);                
            }
        }        
        public void EditGroupNo(string no, string newNo)
        {
            if (AllGroups.Count == 0)
            {
                ClearAndColor();
                Console.WriteLine("No Group exists");
                return;
            }
            Group existGroup = FindGroup(no);             
            if (existGroup == null)
            {
                ClearAndColor();
                Console.WriteLine("Please enter a groupNo that exists");
                return;
            }            
            foreach (Group group in AllGroups)
            {
                if(group.No.ToLower().Trim() == newNo.ToLower().Trim())
                {
                    ClearAndColor();
                    Console.WriteLine($"{group.No} already exists");
                    return;
                }
            }                      
            existGroup.No = newNo;
            //When calling ShowAllStudents() after EditGroupNo() it shows the old groupNo. This code is preventing that.                                                   
            foreach (Student student in existGroup.Students)              
            {
                student.GroupNo = newNo;
            }            
            Console.WriteLine($"{no} Hall has been successfuly changed to {newNo}\n");
        }
        public Group FindGroup(string no)
        {            
            foreach (Group group in AllGroups)
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
                ClearAndColor();
                Console.WriteLine("Please enter valid groupNo ");
                return;
            }
            if (group.Students.Count == 0)
            {
                ClearAndColor();
                Console.WriteLine("There's no students in this group");
                return;
            }
            if(no.ToLower().Trim() == group.No.ToLower().Trim())
            {
                foreach (Student student in group.Students)
                {
                    Console.WriteLine(student);                   
                }
            }       
        }        
        public void ShowAllStudents()
        {            
            if (AllStudents.Count == 0)
            {
                ClearAndColor();
                Console.WriteLine("There's no students.");
                return;
            }
            foreach (Student student in AllStudents)
            {
                Console.WriteLine(student);
            }
        }       
        public void CreateStudent(string fullname,string groupNo)
        {            
            if (AllGroups.Count == 0)
            {
                ClearAndColor();
                Console.WriteLine("There's no group to add Students");
                return;
            }
            if (!CheckFullname(fullname))
            {
                return;
            }
            Group group = FindGroup(groupNo);
            if (group == null)
            {
                ClearAndColor();
                Console.WriteLine("Enter a group that exists");
                return;
            }                                                                                        
            if (group.Limit-1 < group.Students.Count)
            {
                ClearAndColor();
                Console.WriteLine($"You passed the limit. This Group's max limit is {group.Limit}");
                return;
            }
            //isonline,type i cagirsam bunlari menuya atmaq olar
            Student student = new Student(fullname, groupNo);
            Console.WriteLine("Choose:(Press 1 or 2)\n1.Online\n2.Offline");
            if (!CheckIfOnline(student))
            {
                ClearAndColor();
                Console.WriteLine("Input valid num value");
                return;
            }            
            Console.WriteLine("Choose:(Press 1 or 2)\n1.With Warranty\n2.Without Warranty");
            if (!CheckIfWarranted(student))
            {
                ClearAndColor();               
                Console.WriteLine("Input valid num value");
                return;
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Created Student {fullname}");                   
            AllStudents.Add(student);
            group.Students.Add(student);                                 
        }        
        public static bool CheckIfWarranted(Student student)
        {
            string str = Console.ReadLine();
            bool result = byte.TryParse(str, out byte num);
            if (result)
            {
                switch (num)
                {
                    case 1:
                        student.Type = true;
                        return true;                        
                    case 2:
                        student.Type = false;
                        return true;                       
                    default:
                        return false;
                }
            }                          
            return false;                       
        }
        public static bool CheckIfOnline(Group group)
        {
            string str = Console.ReadLine();
            bool result = byte.TryParse(str, out byte num);
            if (result)
            {
                switch (num)
                {
                    case 1:
                        group.IsOnline = true;
                        return true;                     
                    case 2:
                        group.IsOnline = false;
                        return true;                       
                    default:                        
                        return false;
                }
            }            
            return false;
        }
        public static bool CheckIfOnline(Student student)
        {
            string str = Console.ReadLine();
            bool result = byte.TryParse(str, out byte num);
            if (result)
            {
                switch (num)
                {
                    case 1:
                        student.Online = true;
                        return true;
                    case 2:
                        student.Online = false;
                        return true;
                    default:                        
                        return false;
                }
            }            
            return false;
        }        
    public bool CheckFullname(string fullname)
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
                    ClearAndColor();
                    Console.WriteLine("After an Uppercase(in name and surname) all characters should be lowercase");
                    return false;                    
                }
                ClearAndColor();
                Console.WriteLine("Name and Surname has to start with an Uppercase ");
                return false;                
            }
            ClearAndColor();
            Console.WriteLine("Fullname must include 3 parts: Name + Space + Surname. Example(Fakhri Afandiyev)");
            return false;
        }
        public static void ClearAndColor()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
        }
    }
}