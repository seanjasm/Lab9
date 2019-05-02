using System;
using System.Collections.Generic;

namespace StudentInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<StudentInfo> studentList = new List<StudentInfo>();
            InitStudentInfo(studentList);
            studentList.Sort((x, y) => x.studentName.CompareTo(y.studentName));

            bool repeat = true;

            while (repeat)
            {                
                Console.Clear();
                UserInput.Display("\n\n\tWelcome to ASP.Net Student Info Center!\n\n");
                for (int i = 0; i < studentList.Count; i++)
                {
                    UserInput.Display($"\t\t{i + 1}............  {studentList[i].studentName}");
                }
                try
                {
                    int indexOfStudent = UserInput.GetUserInputAsInteger("\n\n\tEnter a " +
                        "student number to see more:  ") - 1;

                    UserInput.Display(studentList[indexOfStudent].ToString());//override to string to display info about student

                }
                catch (ArgumentOutOfRangeException e)
                {
                    UserInput.Display($"This record does not exist. Please check the above list.");
                    ErrorDetail(e);
                }
                catch (Exception e)
                {
                    UserInput.Display(e.Message);
                    ErrorDetail(e);
                }
                finally
                {
                    if (UserInput.UserConfirmationPrompt("\tDo you want to add a student(Y/N)? "))
                    {
                        AddStudent(studentList);
                    }
                    repeat = UserInput.UserConfirmationPrompt("\n\n\tLookup another student(Y/N)? ");
                }

            }
        }

        public static void InitStudentInfo(List<StudentInfo> studentInfos)
        {
            studentInfos.Add(new StudentInfo("Sean Mattis", "Detroit, MI", true));
            studentInfos.Add(new StudentInfo("Jeff Ducat", "Stratford, CT", true));
            studentInfos.Add(new StudentInfo("Andre Watts", "Westland, MI", false));
            studentInfos.Add(new StudentInfo("Anita Devkota", "Livonia, MI", false));
            studentInfos.Add(new StudentInfo("Tony Yeho", "Royal Oak, MI", true));
        }

        public static void AddStudent(List<StudentInfo> studentList)
        {
            string name = UserInput.GetUserInput("New student's name: ");           
            string address = UserInput.GetUserInput($"{name.Split()[0]}'s address(city & state initial): ");
            bool spicePreference = UserInput.GetUserInputAsBool($"Does {name.Split()[0]} likes spice(true or false)? ");
            studentList.Add(new StudentInfo(name, address, spicePreference));
            studentList.Sort((x, y) => x.studentName.CompareTo(y.studentName)); ;
        }

        public static void ErrorDetail(Exception e)
        {
            if (UserInput.UserConfirmationPrompt("\n\n\tDo you want to " +
                        "see more about this error(Y/N)? "))
            {
                UserInput.DisplayExceptionDetail(e);
            }
        }
    }
}
