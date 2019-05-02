using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentInfo
{
    class UserInput
    {
        public static int GetUserInputAsInteger(string message)
        {
            Display(message);
            string input = Console.ReadLine();

            if (input == string.Empty)
            {
                return GetUserInputAsInteger(message);
            }
            try
            {
                return int.Parse(input);
            }
            catch(Exception e)
            {
                throw new Exception("A whole number is needed like 1, but not like 1.0!", e);
            }
        }


        public static string GetUserInput(string message)
        {
            Display(message);
            string input = Console.ReadLine();

            if (input == string.Empty)
            {
                return GetUserInput(message);
            }
            return input;
        }


        public static bool GetUserInputAsBool(string message)
        {
            Display(message);

            if(!bool.TryParse(Console.ReadLine(), out bool result))
            {
                return GetUserInputAsBool(message);
            }
            return result;
        }


        /// <summary>
        /// Displays a message
        /// </summary>
        /// <param name="message"></param>
        public static void Display(string message)
        {
            Console.Write("\n\n" + message);
        }

        /// <summary>
        /// Return true if user input equals trueOption. trueOption set to "Y" by default.  
        /// </summary>
        /// <param name="message"></param>  
        public static bool UserConfirmationPrompt(string message, string trueOption = "Y", string falseOption = "N")
        {

            string input = UserInput.GetUserInput(message);

            if (new Regex($"{trueOption}", RegexOptions.IgnoreCase).IsMatch(input))
            {
                return true;
            }

            if (new Regex($"{falseOption}", RegexOptions.IgnoreCase).IsMatch(input))
            {
                return false;
            }
            else
            {
                return UserConfirmationPrompt(message);
            }
        }

        public static void DisplayExceptionDetail(Exception e)
        {
            Display(e.Message);
            if(e.InnerException != null)
            {
                Display(e.InnerException.Message);
                Display(e.Source);
            }
        }
    }
}
