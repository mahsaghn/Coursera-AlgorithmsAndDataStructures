using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace E2
{
    public class Q3BloomFilter
    {
        public const long BigPrimeNumber = 1000000007;
        BitArray Filter;
        Func<string, int>[] HashFunctions;

        public Q3BloomFilter(int filterSize, int hashFnCount)
        {
            // زحمت بکشید پیاده سازی کنید
            Random rnd = new Random();
            List<int> rand = new List<int>();
            for (int i = 0; i <hashFnCount; i++)
                rand.Add(rnd.Next());
            Filter = new BitArray(filterSize);
            HashFunctions = new Func<string, int>[hashFnCount];

            for (int i = 0; i < hashFnCount; i++)
            {
                int h = rand[i];
                HashFunctions[i] = str => MyHashFunction(str, h,filterSize);
            }
        }

        public int MyHashFunction(string str, int x,int filterSize)
        {
            long hashValue = 0;

            for(int i=str.Length-1;i>=0;i--)
            {
                hashValue += (str[i] +(hashValue* x))%BigPrimeNumber;
            }
            return (int)(((hashValue%BigPrimeNumber)%filterSize));
        }

        private long PowX(int x, long bigPrimeNumber,int num)
        {
            long result = 1;
            for (int i = 0; i < num; i++)
            {
                result *= x;
                result %= bigPrimeNumber;
            }
            return result;
        }

        public void Add(string str)
        {
            for(int i=0;i<HashFunctions.Length;i++)
            {
                int h = HashFunctions[i](str);
                Filter[h] = true;
            }
            // زحمت بکشید پیاده سازی کنید
        }

        public bool Test(string str)
        {
            // زحمت بکشید پیاده سازی کنید
            for(int i=0;i<HashFunctions.Length;i++)
            {
                bool h = Filter[HashFunctions[i](str)];
                if (h == false)
                    return false;
            }
            return true;
        }
    }
}