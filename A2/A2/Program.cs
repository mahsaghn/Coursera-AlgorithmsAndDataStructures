using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public static string Process(string input)
        {
            var inData = input.Split(new char[] { '\n', '\r', ' ' }
                , StringSplitOptions.RemoveEmptyEntries)
                .Select(s => int.Parse(s))
                .ToList();
            return FastMaxPairwiseProduct(inData).ToString();
        }

        public static long NaiveMaxPairwiseProduct(List<int> numbers)
        {
            int max=0;
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (i != j)
                    {
                        int zarb = numbers[i] * numbers[j];
                        if (zarb > max)
                            max = zarb;
                    }
                }
            }
            return max;
        }

        public static long FastMaxPairwiseProduct(List<int> numbers)
        {
            int index1=0;
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] > numbers[index1])
                    index1 = i;
            }
            int index2;
            if (index1 == 0)
                index2 = 1;
            else
                index2 = 0;
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] > numbers[index2] && i != index1)
                    index2 = i;
            }
            return (numbers[index1] * numbers[index2]);
        }
    }
}
