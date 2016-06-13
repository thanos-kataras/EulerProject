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

        public static bool IsPandigital(Int64 number, int baseInt = 1)
        {            
            long[] digits = IntToArray(number);
            // Account for 10 digit numbers. The number 10 can't be
            // part of a pandigital.
            int length = digits.Length < 10 ? digits.Length : 9;
            Array.Sort(digits);

            long current = -1, previous = -1;
            for (int i = 0; i <= length - 1; i++)
            {
                current = digits[i];
                if (i + baseInt != current)
                    return false;
                if (current == previous)
                    return false;
                previous = current;
            }
            return true;
        }

        public static long[] IntToArray(long value)
        {
            var numbers = new Stack<long>();

            for (; value > 0; value /= 10)
                numbers.Push(value % 10);

            return numbers.ToArray();
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
