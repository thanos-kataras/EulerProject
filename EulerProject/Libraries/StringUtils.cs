using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Libraries
{
    class StringUtils
    {
        public static string Reverse(string str)
        { 
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static bool IsPalindrome(String checkStr)
        {
            int half = Int32.Parse(
                Math.Floor((double)checkStr.Length / 2).ToString()
                );

            for (int i = 0; i<half; i++)
            {
                if (checkStr[i] != checkStr[checkStr.Length - 1 - i])
                    return false;
            }

            return true;
        }

        public static int CalculateWordValue(string word)
        {
            int wordSum = 0;
            foreach (char c in word)
            {
                wordSum += GetCharValue(c);
            }
            return wordSum;
        }

        private static int GetCharValue(char c)
        {
            return char.ToUpper(c) - 64;
        }
    }
}
