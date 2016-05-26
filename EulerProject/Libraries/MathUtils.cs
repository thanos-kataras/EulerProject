using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Libraries
{
    class MathUtils
    {
        public static List<Int32> NumberPermutations(Int32 number)
        {
            List<Int32> permutations = new List<int>();

            char[] cdigits = number.ToString().ToCharArray();
            int[] digits = Array.ConvertAll(cdigits, c => (int)Char.GetNumericValue(c)); ;
            Array.Sort(digits);
            permutations.Add(ConcatDigits(digits));

            return permutations;
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
