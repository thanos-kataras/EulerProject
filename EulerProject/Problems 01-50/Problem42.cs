using EulerProject.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Problems
{
    class Problem42 : AbstractProblem, IProblem
    {
        private ISet<int> _triangNumbers = new HashSet<int>();
        public Problem42() : base(42)
        {
        }

        public void Run()
        {
            string text = System.IO.File.ReadAllText(@"..\..\FileResources\p042_words.txt");
            string[] words = text.Replace("\"", "").Split(',');

            int currWordValue = 0, triangWordCount = 0;
            int maxTriangleCalculated = 0;
            foreach (string word in words)
            {
                currWordValue = StringUtils.CalculateWordValue(word);
                while (maxTriangleCalculated < currWordValue)
                {
                    _triangNumbers.Add(GetTriangleNumber(++maxTriangleCalculated));
                }
                if (_triangNumbers.Contains(currWordValue))
                {
                    triangWordCount++;
                }
            }
            this.result = triangWordCount.ToString();
        }

        private int GetTriangleNumber(int baseNamber)
        {
            double res = 0.5 * baseNamber * (baseNamber + 1);
            return Int32.Parse(res.ToString());
        }
    }
}
