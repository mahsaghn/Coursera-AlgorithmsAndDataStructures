using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A10
{
    public class HashingWithChain : Processor
    {
        public HashingWithChain(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, string[], string[]>)Solve);


        public string[] Solve(long bucketCount, string[] commands)
        {
            List<string>[] hashTable = new List<string>[bucketCount];
            for (int i = 0; i < bucketCount; i++)
                hashTable[i] = new List<string>();
            List<string> result = new List<string>();
            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var arg = toks[1];

                switch (cmdType)
                {
                    case "add":
                        Add(arg,hashTable);
                        break;
                    case "del":
                        Delete(arg,hashTable);
                        break;
                    case "find":
                        result.Add(Find(arg, hashTable));
                        break;
                    case "check":
                        result.Add(Check(int.Parse(arg), hashTable));
                        break;
                }
            }
            return result.ToArray();
        }

        public const long BigPrimeNumber = 1000000007;
        public const long ChosenX = 263;

        public static long PolyHash(
            string str, int start, int count,
            long p = BigPrimeNumber, long x = ChosenX)
        {
            long hash = 0;
            for(int i=start;i<str.Length;i++)
            {
                hash += str[i] * pow(x, i,p)  ;
            }
            return (hash%p)% count;
        }

        public static long pow(long x, int j,long p)
        {
            long result = 1;
            for(int i=0;i<j;i++)
            {
                result *= x;
                result %= p;
            }
            return result;
        }

        public void Add(string str,List<string>[] hashTable)
        {
            long hash = PolyHash(str, 0, hashTable.Length);
            if(!hashTable[hash].Contains(str))
                hashTable[hash].Add(str);
        }

        public string Find(string str, List<string>[] hashTable)
        {
            List<string> chain = hashTable[PolyHash(str, 0, hashTable.Length)];
            if (chain.Contains(str))
                 return "yes";
            return "no";
        }

        public void Delete(string str, List<string>[] hashTable)
        {
            long hash = PolyHash(str, 0, hashTable.Length );
            for (int j = 0; j < hashTable[hash].Count; j++)
            {
                if(hashTable[hash][j]==str)
                {
                    hashTable[hash].RemoveAt(j);
                    return;
                }
            }
        }

        public string Check(int i, List<string>[] hashTable)
        {
            if (hashTable[i].Count == 0)
                return "-";
            string result = null;
            for (int j= hashTable[i].Count-1; j>=0;j--)
            {
                result += hashTable[i][j];
                if(j!=0)
                result += " ";
            }
            return result;
        }
    }
}
