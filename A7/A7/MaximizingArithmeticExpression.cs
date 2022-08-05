using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A7
{
    public class MaximizingArithmeticExpression : Processor
    {
        public MaximizingArithmeticExpression(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long Solve(string expression)
        {
            List<long> numbers = new List<long>();
            List<char> operations=new List<char>();
            GetNumbers(expression, ref numbers, ref operations);
            long[,] maxTable = new long[numbers.Count(), numbers.Count()];
            long[,] minTable = new long[numbers.Count(), numbers.Count()];
            for(int i=0;i<numbers.Count();i++)
            {
                minTable[i, i] = numbers[i];
                maxTable[i, i] = numbers[i];
            }
            for (int i = 2; i <= numbers.Count(); i++)
            {
                for (int j = 0; j < numbers.Count() - i+1; j++)
                {
                    int k = i + j - 1;
                    long min, max;
                    GetMaxAndMin(j, k, maxTable, minTable, operations,out min,out max);
                    minTable[j,k] = min;
                    maxTable[j,k] = max;
                }
            }
            return maxTable[0,numbers.Count()-1];
        }
         private void GetNumbers(string expression,ref List<long> numbers, ref List<char> op)
        {
            string[] splited = expression.Split(new char[] { '+', '-', '*' });
            foreach(string c in splited)
                    numbers.Add(long.Parse(c));
            foreach(char c in expression)
                if (c == '+' || c == '-' || c == '*')
                    op.Add(c);
        }

        private void GetMaxAndMin(int first,int last,long[,]maxTable,
            long[,]minTable,List<char> operations,out long min,out long max)
        {
            max = 0;
            min = 0;
            if(first<last)
            {
                max = Execute(maxTable[first, first], operations[first], maxTable[first + 1, last]);
                min = Execute(maxTable[first, first], operations[first], maxTable[first + 1, last]);
            }
            //max = -1000000000000;
            //min = 1000000000000;
            for (int i = first; i < last; i++)
            {
                List<long> chandidate = new List<long>
                {Execute(maxTable[first,i],operations[i],maxTable[i+1,last]),
                Execute(maxTable[first,i],operations[i],minTable[i+1,last]),
                Execute(minTable[first,i],operations[i],maxTable[i+1,last]),
                Execute(minTable[first,i],operations[i],minTable[i+1,last]),
                max};
                max = chandidate.Max();
                chandidate = new List<long>
                {Execute(maxTable[first,i],operations[i],maxTable[i+1,last]),
                Execute(maxTable[first,i],operations[i],minTable[i+1,last]),
                Execute(minTable[first,i],operations[i],maxTable[i+1,last]),
                Execute(minTable[first,i],operations[i],minTable[i+1,last]),
                min};
                min = chandidate.Min();
            }
        }

        private long Execute(long a, char op, long b)
        {
            long result=0;
            switch (op)
            {
                case '+':
                    result = a + b;
                    break;
                case '-':
                    result = a - b;
                    break;
                case '*':
                    result = a * b;
                    break;
            }
            return result;
        }
    }
}
