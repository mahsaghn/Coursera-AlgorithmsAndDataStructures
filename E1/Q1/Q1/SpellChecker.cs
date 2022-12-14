using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public class SpellChecker
    {
        public readonly FastLM LanguageModel;

        public SpellChecker(FastLM lm)
        {
            this.LanguageModel = lm;
        }

        public string[] Check(string misspelling)
        {
            ulong count;
            List<WordCount> candidates = 
                new List<WordCount>();
            Dictionary<string, ulong> myResult = new Dictionary<string, ulong>();
            string[] words = CandidateGenerator.GetCandidates(misspelling);
            for(int i=0;i<words.Length;i++)
            {
                count = 0;
                if(LanguageModel.GetCount(words[i],out count))
                {
                    string me = words[i];
                    if (!myResult.ContainsKey(words[i]))
                        myResult.Add(words[i], count);
                        //candidates.Add(new WordCount(words[i], count));
                }
                foreach (var t in myResult)
                    candidates.Add(new WordCount(t.Key, t.Value));
            }

            return candidates
                    .OrderByDescending(x => x.Count)
                    .Select(x => x.Word)
                    .Distinct()
                    .ToArray();
        }

        public string[] SlowCheck(string misspelling)
        {
            List<WordCount> candidates =
                new List<WordCount>();

            // TODO

            return candidates
                    .OrderByDescending(x => x.Count)
                    .Select(x => x.Word)
                    .Distinct()
                    .ToArray();
        }

        public int EditDistance(string str1, string str2)
        {
            int n = str1.Length;
            int m = str2.Length;

            int[,] Distance = new int[n + 1, m + 1];
            for (int i = 0; i < n + 1; i++)
            {
                Distance[i, 0] = i;
            }

            for (int j = 0; j < m + 1; j++)
            {
                Distance[0, j] = j;
            }

            for (int j = 1; j <= m; j++)
            {
                for (int i = 1; i <= n; i++)
                {
                    
                }
            }
            return Distance[n, m];
        }
    }
}
