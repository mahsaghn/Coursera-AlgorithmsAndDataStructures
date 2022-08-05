using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class PrimitiveCalculator: Processor
    {
        public PrimitiveCalculator(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[]>)Solve);

        public long[] Solve(long n)
        {
            long[] table = new long[n+1];
            for(int number=1;number<=n;number++)
            {
                FindMinOperation(ref table, number);
            }
            List<long> result = new List<long>();
            result.Add(n);
            for (int i = (int)n; 1 < i; )
            {
                result.Add(0);
                long min = n, check = 0;
                if (table[i - 1] <= min)
                {
                    result[result.Count() - 1] = i-1;
                    check = 1;
                    min = table[i - 1];
                }
                if ((i) % 2 == 0)
                {
                    if (table[i / 2] <= min)
                    {
                        result[result.Count() - 1] = i / 2;
                        check = 2;
                        min = table[i - 1];
                    }
                }
                if ((i) % 3 == 0)
                    if (table[i / 3] <= min)
                    {
                        result[result.Count() - 1] = i/3;
                        check = 3;
                        min = table[i - 1];
                    }
                
                if (check > 1)
                    i /= (int)check;
                else
                    i--;
            }
            result.Reverse();
            return result.ToArray();
        }

        private void FindMinOperation(ref long[] table, long number)
        {
            List<long> candidate = new List<long>();
            if (number == 2 || number == 3 || number == 1)
                candidate.Add(1);
            else
            {
                if ((number) % 2 == 0)
                    candidate.Add(table[(number / 2)] + 1);
                if (number % 3 == 0)
                    candidate.Add(table[(number / 3)] + 1);
                candidate.Add(table[number - 1] + 1);
            }
            table[number] = candidate.Min();
        }
    }
}
