using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Libraries
{
    class CombiUtils
    {
        /// <summary>
        /// Return possible combinations of selections or r items out of n
        /// </summary>
        /// <param name="n">The total number of items</param>
        /// <param name="r">The number of items to select each time</param>
        /// <returns>The total combinations of items to select</returns>
        public static BigInteger SelectRfromN(int n, int r)
        {
            return Factorial(n) / (Factorial(r) * Factorial(n - r));
        }

        /// <summary>
        /// Calculate factorial of n
        /// </summary>
        /// <param name="n">The n number to calculate</param>
        /// <returns>Returns the factorial</returns>
        public static BigInteger Factorial(int n)
        {
            if (n==0)
                return 1;

            BigInteger factorial = 1;
            for (int j=n; j > 0; j--)
            {
                factorial *= j;
            }

            return factorial;
        }

        public static List<byte[]> IntCombinations(byte[] byteArray, int length = -1)
        {
            List<byte[]> combis = new List<byte[]>();
            combis.Add(new byte[1] { byteArray[0] });
            for (int i = 1; i < byteArray.Length; i++)
            {
                byte newDigit = byteArray[i];
                List<byte[]> latest = combis.Where(x => x.Length == i).ToList();
                foreach (byte[] num in latest)
                {
                    byte[] newNum = new byte[i + 1];
                    Array.Copy(num, 0, newNum, 1, num.Length);
                    for (int j = 0; j < i + 1; j++)
                    {
                        if (j == 0)
                            newNum[0] = newDigit;
                        else
                        {
                            byte inter = newNum[j];
                            newNum[j] = newNum[j - 1];
                            newNum[j - 1] = inter;
                        }
                        byte[] toAddArray = new byte[i + 1];
                        Array.Copy(newNum, toAddArray, newNum.Length);
                        combis.Add(toAddArray);
                    }
                }
            }

            if (length == -1)
                return combis;
            else
                return combis.Where(x => x.Length == length).ToList();
        }
    }
}