using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfo
{
    class StudentInfo
    {

        public string studentName;
        public string studentAddress;
        public bool studentSpicyPreference;

        public StudentInfo(string name, string address, bool spicePreference)
        {
            studentAddress = address;
            studentName = name;
            studentSpicyPreference = spicePreference;
        }

        public override string ToString()
        {
            return string.Format("Name: {0} lives in {1}, and {2} spicy food!", studentName,
                        studentAddress, studentSpicyPreference ? "loves" : "does not love");
        }
    }
}
