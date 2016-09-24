using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Problems_51_60
{
    class Problem59 : AbstractProblem, IProblem
    {
        private string line;
        private string[] strLetters;
        private List<char> chrLetters = new List<char>();

        public Problem59() : base(59)
        {
            string[] lines;
            lines = System.IO.File.ReadAllLines(@"..\..\FileResources\p059_cipher.txt");
            line = lines[0];
            strLetters = line.Split(',');
            foreach (string sr in strLetters)
            {
                chrLetters.Add(((char)Int32.Parse(sr)));
            }
        }

        public void Run()
        {
            char[] testChr = new char[3];
            for(testChr[0] = 'a'; testChr[0] <= 'z'; testChr[0]++)
                for (testChr[1] = 'a'; testChr[1] <= 'z'; testChr[1]++)
                    for (testChr[2] = 'a'; testChr[2] <= 'z'; testChr[2]++)
                    {
                        StringBuilder sb = new StringBuilder();

                        int currChar = 0;

                        foreach (char cr in chrLetters)
                        {
                            sb = sb.Append((char)((int)cr^(int)testChr[currChar]));
                            
                            if (currChar == 2)
                                currChar = 0;
                            else
                                currChar++;
                        }

                        if (sb.ToString().Contains(" and "))
                        {
                            Console.WriteLine(sb);
                            this.result = sb.ToString().Sum(_ => _).ToString();
                        }
                    }
        }
    }
}
