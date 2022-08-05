using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public class FastLM
    {
        public readonly WordCount[] WordCounts;


        public FastLM(WordCount[] wordCounts)
        {
            this.WordCounts = wordCounts.OrderBy(wc => wc.Word).ToArray();
        }

        public bool GetCount(string word, out ulong count)
        {
            count = 0;
            long first=0, last=WordCounts.Length-1;
            GetCount((int) first,(int)last, word,ref count);
            if (count>0)
                return true;
            return false;
        }

        public void GetCount(int first,int last,string word,ref ulong count)
        {
            int index =(first + last) / 2;
            int result = string.Compare(word, WordCounts[index].Word);
            if (result==0)
            {
                count = WordCounts[index].Count;
                return;
            }
            if (first >= last)
                return;
            else if (result < 0)
                GetCount(first, index - 1, word, ref count);
            else
                GetCount(index + 1, last, word, ref count);

        }
        ///private iterator Count()
    }
}
