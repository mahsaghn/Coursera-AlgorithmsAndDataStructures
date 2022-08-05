using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class LCSOfTwo : Processor
    {
        public LCSOfTwo(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2)
        {
            long[,] table = new long[seq1.Length + 1, seq2.Length + 1];
            FillTable(seq1, seq2, ref table);
            return table[seq1.Length, seq2.Length];
        }

        private void FillTable(long[] str1, long[] str2, ref long[,] table)
        {
            for (int i = 0; i <= str1.Length; i++)
                table[i, 0] = 0;
            for (int i = 0; i <= str2.Length; i++)
                table[0, i] = 0;

            for (int i = 1; i <= str2.Length; i++)
            {
                for (int j = 1; j <= str1.Length; j++)
                {
                    List<long> condidate = new List<long> { table[j, i - 1], table[j - 1, i], table[j - 1, i - 1] };
                    long choise = condidate.Max();
                    if (str1[j - 1] == str2[i - 1])
                    {
                        table[j, i] = table[j - 1, i - 1]+1;
                    }
                    else
                        table[j, i] = choise;
                }
            }
        }
    }
}
