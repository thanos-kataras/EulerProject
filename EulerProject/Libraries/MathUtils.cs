using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Libraries
{
    class MathUtils
    {
        public static List<Int32> NumberRotations(Int32 number)
        {
            List<Int32> rotations = new List<int>();
            rotations.Add(number);

            char[] cdigits = number.ToString().ToCharArray();
            int[] digits = Array.ConvertAll(cdigits, c => (int)Char.GetNumericValue(c)); ;
            for (int i = 0; i < digits.Length - 1; i++)
            {
                for (int j = 0; j < digits.Length - 1; j++)
                {
                    int temp;
                    if (j == 0)
                    {
                        temp = digits[j];
                        digits[j] = digits[digits.Length - 1];
                        digits[digits.Length - 1] = temp;
                    }
                    else
                    {
                        temp = digits[j];
                        digits[j] = digits[j - 1];
                        digits[j - 1] = temp;
                    }
                }
                rotations.Add(ConcatDigits(digits));
            }

            return rotations;
        }

        public static bool IsPandigital(Int32 number)
        {
            string numberStr = number.ToString();
            for (int i = 1; i <= numberStr.Length; i++)
            {
                if (!numberStr.Contains(i.ToString()))
                    return false;
            }
            return true;
        }

        private static Int32 ConcatDigits(int[] cdigits)
        {
            StringBuilder sb = new StringBuilder("");
            foreach(int digit in cdigits)
            {
                sb.Append(digit);
            }
            return Int32.Parse(sb.ToString());
        }
    }
}
