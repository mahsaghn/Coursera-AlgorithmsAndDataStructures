using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public static class CandidateGenerator
    {
        public static readonly char[] Alphabet =
            Enumerable.Range('a', 'z' - 'a' + 1)
                      .Select(c => (char)c)
                      .ToArray();

        public static string[] GetCandidates(string word)
        {
            List<string> candidates = new List<string>();
            for(int i=0;i<word.Length;i++)
            {
                foreach(char alpha in Alphabet)
                {
                    candidates.Add(Insert(word, i, alpha));
                    candidates.Add(Substitute(word, i, alpha));
                }
                candidates.Add(Delete(word, i));
            }
            foreach (char alpha in Alphabet)
            {
                candidates.Add(Insert(word, word.Length, alpha));
            }
            return candidates.ToArray();
        }

        private static string Insert(string word, int pos, char c)
        {
            char[] wordChars = word.ToCharArray();
            char[] newWord = new char[wordChars.Length+1];
            for (int i = 0; i < wordChars.Length +1; i++)
            {
                if (i == pos)
                {
                    newWord[i] = c;
                }
                else if(i> pos)
                    newWord[i] = wordChars[i-1];
                else
                    newWord[i] = wordChars[i];
            }
            return new string(newWord);
        }

        private static string Delete(string word, int pos)
        {
            char[] wordChars = word.ToCharArray();
            char[] newWord = new char[wordChars.Length-1];
            for (int i = 0; i < wordChars.Length-1; i++)
            {
                if (i >= pos)
                    newWord[i] = wordChars[i+1];
                else
                    newWord[i] = wordChars[i];

            }
            return new string(newWord);
        }

        private static string Substitute(string word, int pos, char c)
        {
            char[] wordChars = word.ToCharArray();
            char[] newWord = new char[wordChars.Length];
            for (int i = 0; i < wordChars.Length; i++)
            {
                if (i == pos)
                    newWord[i] = c;
                else
                    newWord[i] = wordChars[i];
            }
            return new string(newWord);
        }

    }
}
