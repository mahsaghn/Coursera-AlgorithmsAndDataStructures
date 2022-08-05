using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A7
{
    public class PartitioningSouvenirs : Processor
    {
        public PartitioningSouvenirs(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long souvenirsCount, long[] souvenirs)
        {
            long total = souvenirs.Sum();
            if (souvenirsCount < 3 || total % 3 != 0)
                return 0;
            long third = total / 3;
            long[,] table = new long[third+1 ,souvenirsCount+1];
            for(int i=1;i<=third;i++)
            {
                for(int j=1;j<=souvenirsCount;j++)
                {
                    long k = i - souvenirs[j - 1];
                    if (souvenirs[j - 1] == i || (k > 0 && table[k, j - 1] > 0))
                    {
                        if (table[i, j - 1] == 0)
                            table[i, j] = 1;
                        else
                            table[i, j] = 2;
                    }
                    else
                        table[i, j] = table[i, j - 1];
                }
            }
            return table[third,souvenirsCount] == 2 ? 1 : 0;
        }
    }
}
