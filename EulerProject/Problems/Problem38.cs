using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Problems
{
    class Problem38 : AbstractProblem, IProblem
    {
        public Problem38() : base(38)
        {
        }

        public void Run()
        {
            int currNumber = 2;
            int maxPandigital = 0;
            // Any five digit number will be over
            // 9 digits at the second concatenation
            while (currNumber < 9999)
            {
                if (GetPandigital(currNumber) > maxPandigital)
                    maxPandigital = GetPandigital(currNumber);

                currNumber++;

            }
            this.result = maxPandigital.ToString();
        }

        private int GetPandigital(int currNumber)
        {
            string outcome = "";
            int index = 1;
            while (outcome.Length < 9)
            {
                outcome += (currNumber*index).ToString();
                index++;
            }
            if (outcome.Length==9 && IsPandigital(outcome)) {
                return Int32.Parse(outcome);
            }

            return 0;
        }

        private bool IsPandigital(string outcome)
        {
            for (int i = 1; i<=9; i++)
            {
                if (!outcome.Contains(i.ToString()))
                    return false;
            }
            return true;
        }
    }
}
