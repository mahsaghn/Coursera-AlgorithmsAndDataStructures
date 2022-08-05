using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A9
{
    public class MergingTables : Processor
    {
        public MergingTables(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);

        public long[] Solve(long[] tableSizes, long[] sourceTables, long[] targetTables)
        {
            long[] resault = new long[sourceTables.Length];
            long[] leared = new long[tableSizes.Length];
            List<long> Tables = tableSizes.ToList();
            long value=0;
            for (int i = 0; i < leared.Length; i++)
                leared[i] = i;
            for (int i = 0; i < sourceTables.Length; i++)
            {
                if (leared[sourceTables[i] - 1] != leared[targetTables[i] - 1])
                {
                    value = Tables[(int)sourceTables[i] - 1] + Tables[(int)targetTables[i] - 1];
                    long max = leared[sourceTables[i] - 1] > leared[targetTables[i] - 1]
                        ? leared[sourceTables[i] - 1] : leared[targetTables[i] - 1];
                    long min = leared[sourceTables[i] - 1] + leared[targetTables[i] - 1] - max;
                    for (int j = 0; j < leared.Length; j++)
                    {
                        if (leared[j] == min)
                        {
                            leared[j] = max;
                            Tables[j] = value;
                        }
                        else if (leared[j] == max)
                            Tables[j] = value;
                    }
                }
                if (i == 0)
                    resault[i] = Tables.Max();
                else if ((i > 0 && resault[i - 1] < value))
                    resault[i] = value;
                else
                    resault[i] = resault[i - 1];
            }
            return resault;
        }
    }
}