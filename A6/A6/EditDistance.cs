using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class EditDistance: Processor
    {
        public EditDistance(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long>)Solve);

        public long Solve(string str1, string str2)
        {
            if(str1.Length>str2.Length)
            {
                string h = str1;
                str1 = str2;
                str2 = h;
            }
            long[,] table = new long[str1.Length+1, str2.Length+1];
            FillTable(str1, str2, ref table);
            long min = table[0, str2.Length];
            for (int i = 1; i <= str1.Length; i++)
                if (table[i,str2.Length]<min)
                    min = table[i,str2.Length];
            return table[str1.Length,str2.Length];
        }

        private void FillTable(string str1, string str2, ref long[,] table)
        {
            for (int i = 0; i <= str1.Length; i++)
                table[i, 0] = i;
            for (int i = 0; i <= str2.Length; i++)
                table[0, i] = i;

            for (int i = 1; i <= str2.Length; i++)
            {
                for (int j = 1; j <= str1.Length; j++)
                {
                    List<long> condidate = new List<long> { table[j,i-1], table[j-1,i], table[j-1,i-1] };
                    long choise = condidate.Min();
                    if (str1[j - 1] == str2[i - 1])
                    {
                        table[j, i] = table[j - 1, i - 1];
                    }
                    else
                        table[j, i] = choise + 1;
                }
            }
        }
    }
}
