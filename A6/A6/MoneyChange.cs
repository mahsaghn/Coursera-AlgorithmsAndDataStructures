using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class MoneyChange: Processor
    {
        private static readonly int[] COINS = new int[] {1, 3, 4};

        public MoneyChange(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>) Solve);

        public long Solve(long n)
        {
            long[] table = new long[(int)n];
            for (int i = 1; i <= n; i++)
                FindMinCoinNum(ref table, i);
            return table[n-1];
        }

        private void FindMinCoinNum(ref long[] table,long n)
        {
            long minCoin = n;
            if (n == 3 || n == 4 || n == 1)
            {
                table[n-1] = 1;
                minCoin = 1;
            }
            else
            {
                for (int i = 1; i <= n / 2; i++)
                {
                    long coinNUm = table[i-1] + table[n - i-1];
                    if (coinNUm < minCoin)
                        minCoin = coinNUm;
                }
            }
            table[n-1] = minCoin;
            return;
        }
    }
}
