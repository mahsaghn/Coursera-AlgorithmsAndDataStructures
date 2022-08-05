using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A9
{
    public class ParallelProcessing : Processor
    {

        public ParallelProcessing(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], Tuple<long, long>[]>)Solve);

        public Tuple<long, long>[] Solve(long threadCount, long[] jobDuration)
        {
            //Write your code here
            List<Tuple<long, long>> resault = new List<Tuple<long, long>>();
            List<long> threads = new List<long>((int)threadCount);
            for (int i = 0; i < threadCount; i++)
                threads.Add(0);
            long jobNumber=0;
            long time = 0;
            while (jobNumber != jobDuration.Length)
            {
                int index = threads.IndexOf(0);
                threads[index] = jobDuration[jobNumber];
                resault.Add(new Tuple<long, long>(index, time));
                jobNumber++;
                long minTh = threads.Min();
                time += minTh;
                for (int j = 0; j < threads.Count; j++)
                    threads[j] -= minTh;
            }
            return resault.ToArray();
        }
    }
}
