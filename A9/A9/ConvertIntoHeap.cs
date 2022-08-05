using TestCommon;
using System;
using System.Collections.Generic;

namespace A9
{
    public class ConvertIntoHeap : Processor
    {
        public ConvertIntoHeap(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], Tuple<long, long>[]>)Solve);

        public Tuple<long, long>[] Solve(
           long[] array)
        {
            List<Tuple<long, long>> resault = new List<Tuple<long, long>>();
            for (int i = array.Length/2 - 1; i >= 0; i--)
            {
                heapify(array, array.Length, i, resault);
            }

            return resault.ToArray();
        }

        private void heapify(long[] array, int n, int i,List<Tuple<long,long>> resault)
        {
            int min = i; 

            if (2 * i + 1 < n && array[2 * i + 1] < array[min])
                min = 2 * i + 1;

            if (2 * i + 2 < n && array[2 * i + 2] < array[min])
                min = 2 * i + 2;

            if (min != i)
            {
                resault.Add(new Tuple<long, long>(i, min));
                swap(ref array[min],ref array[i]);
                heapify(array, n, min,resault);
            }
        }

        private void swap(ref long v1, ref long v2)
        {
            long h = v1;
            v1 = v2;
            v2 = h;
        }


    }

}