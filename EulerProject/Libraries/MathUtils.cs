using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        internal static BigInteger[] AddFractions(BigInteger[] fraction1, BigInteger[] fraction2)
        {
            BigInteger[] resultFraction = new BigInteger[2];
            BigInteger lcm = LeastCommonMultiplier(fraction1[1], fraction2[1]);
            resultFraction[0] = fraction1[0] * (lcm / fraction1[1]) + fraction2[0] * (lcm / fraction2[1]);
            resultFraction[1] = lcm;
            return resultFraction;
        }

        public static long LeastCommonMultiplier(long a, long b)
        {
            long top = a * b;
            top = top < 0 ? (-1) * top : top;
            return top / MaxCommonDenominator(a, b);
        }

        public static BigInteger LeastCommonMultiplier(BigInteger a, BigInteger b)
        {
            BigInteger top = a * b;
            top = top < 0 ? (-1) * top : top;
            return top / MaxCommonDenominator(a, b);
        }

        private static long MaxCommonDenominator(long a, long b)
        {
            long t = b;
            b = b < a ? a: b;
            a = a == b ? t : a;
            while (b != 0)
            {
                t = b;
                b = a % b;
                a = t;
            }
            return a;
        }

        private static BigInteger MaxCommonDenominator(BigInteger a, BigInteger b)
        {
            BigInteger t = b;
            b = b < a ? a : b;
            a = a == b ? t : a;
            while (b != 0)
            {
                t = b;
                b = a % b;
                a = t;
            }
            return a;
        }

        public static int MaxCommonDenominator(List<int> numbers)
        {
            int mcd = 1;
            for(int i = numbers[0]; i > 0; i--)
            {
                foreach(int number in numbers)
                {
                    if (number % i != 0)
                        continue;
                }
                mcd = i;
                break;
            }
            return mcd;
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

        /// <summary>
        /// Generates triangle numbers
        /// </summary>
        /// <param name="n">The n in n(n+1) / 2</param>
        /// <returns>The nth triagonal number</returns>
        public static BigInteger GenerateTriangleNumber(long n)
        {
            return (n * (n + 1) / 2);
        }

        /// <summary>
        /// Generates pentagonal numbers
        /// </summary>
        /// <param name="n">The n in n(n+1) / 2</param>
        /// <returns>The nth triagonal number</returns>
        public static BigInteger GeneratePentagonalNumber(long n)
        {
            return (n * (3 * n - 1) / 2);
        }

        /// <summary>
        /// Generates Hexagonal numbers
        /// </summary>
        /// <param name="n">The n in n(2n+1)</param>
        /// <returns>The nth triagonal number</returns>
        public static BigInteger GenerateHexagonalNumber(int n)
        {
            return n * (2 * n - 1);
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

        public static List<int> IntToList(BigInteger integer)
        {
            BigInteger temp = integer;
            List<int> array = new List<int>();
            do
            {
                array.Add((int)(temp % 10));
                temp /= 10;
            } while (temp > 0);

            return array;
        }

    }
}
