using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A8
{
    public class CheckBrackets : Processor
    {
        public CheckBrackets(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long Solve(string str)
        {
            int i = 0;
            int counter=0;
            Stack<char> checkingBrackets = new Stack<char>();
            for( ;i<str.Length;i++)
            {
                if (Opening(str[i]))
                    checkingBrackets.Push(str[i]);
                else if(Closing(str[i]))
                {
                    if (checkingBrackets.Count == 0 || !MatchOpened(checkingBrackets.Pop(), str[i]))
                        return i + 1;
                    else
                    {
                        counter++;
                        if (checkingBrackets.Count == 0)
                            counter = 0;
                    }
                }
            }
            if (checkingBrackets.Count != 0)
                return str.Length-(2*counter);
            return -1;
        }

        private bool Closing(char s)
        {
            switch (s)
            {
                case '}':
                case ']':
                case ')':
                    return true;
            }
            return false;
        }

        private bool MatchOpened(char LastSequnce, char v)
        {
            if ((LastSequnce== '('&& v == ')') || (LastSequnce == '[' && v == ']') 
                || (LastSequnce == '{' && v == '}'))
                return true;
            return false;
        }

        private bool Opening(char s)
        {
            switch (s)
            {
                case '{':
                case '[':
                case '(':
                    return true;
            }
            return false;

        }
    }
}
