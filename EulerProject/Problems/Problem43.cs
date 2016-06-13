using EulerProject.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Problems
{
    class Problem43 : AbstractProblem, IProblem
    {
        public Problem43() : base(43)
        {
        }

        public void Run()
        {
            List<byte[]> retCombis = CombiUtils.IntCombinations(new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 10);
            Int64 sum = 0;
            foreach (byte[] retCombi in retCombis)
            {


                StringBuilder str = new StringBuilder();
                str.Append(bytesToString(retCombi));

                if (str.ToString().StartsWith("0"))
                    continue;
                if (!IsExactDivision(Int32.Parse(str.ToString(1, 3)), 2))
                    continue;
                if (!IsExactDivision(Int32.Parse(str.ToString(2, 3)), 3))
                    continue;
                if (!IsExactDivision(Int32.Parse(str.ToString(3, 3)), 5))
                    continue;
                if (!IsExactDivision(Int32.Parse(str.ToString(4, 3)), 7))
                    continue;
                if (!IsExactDivision(Int32.Parse(str.ToString(5, 3)), 11))
                    continue;
                if (!IsExactDivision(Int32.Parse(str.ToString(6, 3)), 13))
                    continue;
                if (!IsExactDivision(Int32.Parse(str.ToString(7, 3)), 17))
                    continue;
                if (MathUtils.IsPandigital(Int64.Parse(str.ToString()), 0))
                    sum += Int64.Parse(str.ToString());

            }
            this.result = sum.ToString();
        }

        private String bytesToString(byte[] bytes)
        {
            string tmp = "";
            foreach (byte b in bytes)
            {
                tmp += b;
            }
            return tmp;
        }

        private bool IsExactDivision(int number, int divisor)
        {
            return (number % divisor == 0);
        }
    }
}