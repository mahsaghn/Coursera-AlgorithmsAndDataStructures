using System;
using System.Collections.Generic;
using TestCommon;

namespace A10
{
    public static class method
    {
        public static bool Equals(this string first, string str)
        {
            if (str.Length != first.Length)
                return false;
            for (int i = 0; i < str.Length; i++)
                if (first[i] != str[i])
                    return false;
            return true;
        }
    }


    public class RabinKarp : Processor
    {
        public RabinKarp(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long[]>)Solve);

        public long[] Solve(string pattern, string text)
        {
            long hashPattern = HashingWithChain.PolyHash(pattern, 0,pattern.Length);
            long[] hashesPattern = PreComputeHashes(text, pattern.Length);
            List<long> occurrences = new List<long>();
            for(int i=0 ; i<=text.Length-pattern.Length;i++)
            {
                if (hashPattern != hashesPattern[i])
                    continue;
                if (text.Substring(i,pattern.Length).Equals(pattern))
                    occurrences.Add(i);
            }
            return occurrences.ToArray();
        }


        public static long[] PreComputeHashes(
            string T, 
            int P, 
            long p=HashingWithChain.BigPrimeNumber, 
            long x=HashingWithChain.ChosenX)
        {
            long[] hash = new long[T.Length - P+1];
            hash[T.Length - P] = HashingWithChain.PolyHash(T ,T.Length-P , P, p, x);
            long y = 1;
            y = (long)Math.Pow(x, P);
            for (int i = T.Length - P - 1; i >= 0; i--)
             {
                hash[i] = x*hash[i + 1] + T[i] - (y * T[i + P]);
                hash[i] = (((hash[i]%p)+p)%p)%P;
            }
            return hash;
        }
    }
}
