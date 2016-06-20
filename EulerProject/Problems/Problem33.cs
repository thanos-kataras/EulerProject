using EulerProject.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Problems
{
    class Problem33 : AbstractProblem, IProblem
    {
        private int[] newFraction = new int[2] {1,1};

        public Problem33() : base(33)
        {
        }

        public void Run()
        {
            for (int i=11; i<100; i++)
            {
                if (i % 10 == 0)
                    continue;
                for (int j = i; j < 100; j++)
                {
                    if (j % 10 == 0)
                        continue;

                    if (i == j)
                        continue;
                    char charRemove = ' ';
                    if (i.ToString().Contains(j.ToString()[0]))
                        charRemove = j.ToString()[0];

                    if (charRemove != ' ' && CheckFractionEquality(i,j,charRemove))
                    {
                        newFraction[0] *= i;
                        newFraction[1] *= j;
                        charRemove = ' ';
                    }


                    if (i.ToString().Contains(j.ToString()[1]))
                        charRemove = j.ToString()[1];

                    if (charRemove != ' ' && CheckFractionEquality(i, j, charRemove))
                    {
                        newFraction[0] *= i;
                        newFraction[1] *= j;
                    }
                }
            }

            int mcd = MathUtils.MaxCommonDenominator(new List<int>() { newFraction[0], newFraction[1] });
            this.result = (newFraction[1] / mcd).ToString();
        }

        private bool CheckFractionEquality(int i, int j, char charRemove)
        {
            float firstResult = (float)i / (float)j;

            int newI = Int32.Parse(ReplaceFirst(i.ToString(),charRemove.ToString(),""));
            int newJ = Int32.Parse(ReplaceFirst(j.ToString(), charRemove.ToString(), ""));

            float secondResult = (float)newI / (float)newJ;

            return firstResult == secondResult;
        }

        public string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }
    }
}
