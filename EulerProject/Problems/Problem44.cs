using EulerProject.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Problems
{
    class Problem44 : AbstractProblem, IProblem
    {
        public Problem44() : base(44)
        {
        }

        public void Run()
        {
            SortedSet<BigInteger> pentaNumbers = new SortedSet<BigInteger>();
            int batchStart = 1, batchStep = 10000;
            BigInteger minDiff = -1;

            for (int i = batchStart; i < batchStart + batchStep; i++)
            {
                pentaNumbers.Add(MathUtils.GeneratePentagonalNumber(i));
            }

            foreach (BigInteger pentaNumber in pentaNumbers)
            {
                foreach (BigInteger pentaNumberTest in pentaNumbers)
                {
                    if (pentaNumbers.Contains(pentaNumber + pentaNumberTest))
                    {
                        BigInteger diff = 0;
                        if (pentaNumber > pentaNumberTest)
                            diff = pentaNumber - pentaNumberTest;
                        if (pentaNumberTest >= pentaNumber)
                            diff = pentaNumberTest - pentaNumber;
                        if (pentaNumbers.Contains(diff))
                        {
                            if (minDiff == -1 || minDiff > diff)
                                minDiff = diff;
                        }
                    }
                }
            }

            this.result = minDiff.ToString();

        }
    }
}
