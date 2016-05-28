using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Libraries
{
    class StringUtils
    {
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
    }
}
