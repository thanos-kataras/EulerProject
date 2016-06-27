using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Problems_51_60
{
    class Problem52 : AbstractProblem, IProblem
    {
        public Problem52() : base(52)
        {

        }

        public void Run()
        {
            int i = 1;
            while (true)
            {
                i++;
                for (int j = 2; j <= 6; j++)
                {
                    if (!HasSameDigits(i, i * j))
                    {
                        break;
                    }
                    if (j == 6)
                    {
                        this.result = i.ToString();
                        return;
                    }
                }
            }
        }

        private bool HasSameDigits(int i, int v)
        {
            char[] firstComparator = i.ToString().ToArray();
            char[] secondComparator = v.ToString().ToArray();
            Array.Sort(firstComparator);
            Array.Sort(secondComparator);
            if (ArraysEqual<char>(firstComparator,secondComparator))
                return true;
            return false;
        }

        static bool ArraysEqual<T>(T[] a1, T[] a2)
        {
            if (ReferenceEquals(a1, a2))
                return true;

            if (a1 == null || a2 == null)
                return false;

            if (a1.Length != a2.Length)
                return false;

            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            for (int i = 0; i < a1.Length; i++)
            {
                if (!comparer.Equals(a1[i], a2[i])) return false;
            }
            return true;
        }
    }
}
