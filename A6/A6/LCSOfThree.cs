using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class LCSOfThree: Processor
    {
        public LCSOfThree(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2, long[] seq3)
        {
            long[,,] table123 = new long[seq1.Length + 1, seq2.Length + 1,seq3.Length+1];
            FillTable(seq1, seq2,seq3, ref table123);
            return table123[seq1.Length,seq2.Length, seq3.Length];
        }

        private void FillTable(long[] str1, long[] str2,long[] str3, ref long[,,] table)
        {
            for (int i = 1; i <= str2.Length; i++)
            {
                for (int j = 1; j <= str1.Length; j++)
                {
                    for(int k=1; k<=str3.Length; k++)
                    {
                        List<long> condidate = new List<long> { table[j, i - 1,k],
                            table[j - 1, i,k],table[j,i,k-1]};
                        long choise = condidate.Max();
                        if (str1[j - 1] == str2[i - 1] && str3[k - 1] == str2[i - 1])
                        {
                            table[j, i,k] = table[j - 1, i - 1,k-1] + 1;
                        }
                        else
                            table[j, i,k] = choise;
                    }
                    
                }
            }
        }
    }
}
