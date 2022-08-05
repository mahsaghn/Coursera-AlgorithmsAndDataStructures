using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A8
{
    public class PacketProcessing : Processor
    {
        public PacketProcessing(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long[]>)Solve);

        public long[] Solve(long bufferSize, 
            long[] arrivalTimes, 
            long[] processingTimes)
        {
            long[] resault = new long[arrivalTimes.Length];
            Queue<Tuple<long, long>> packets = new Queue<Tuple<long, long>>();
            Queue<Tuple<long, long>> buffer = new Queue<Tuple<long, long>>();
            long Time = 0;
            int i = 0,j = 0; ;
            if (arrivalTimes.Length == 0)
                return resault.ToArray();
            MakePackets(arrivalTimes, processingTimes, packets);
            buffer.Enqueue(packets.Dequeue());
            i++;
            while (buffer.Count!=0 || packets.Count!=0)
            {
                while(packets.Count>0)
                {
                    if (buffer.Count < bufferSize)
                    {
                        buffer.Enqueue(packets.Dequeue());
                        i++;
                    }
                    else
                    {
                        if (packets.First().Item1 < buffer.First().Item2+Time)
                        {
                            packets.Dequeue();
                            resault[i] = -1;
                            i++;
                        }
                        else
                            break;
                    }
                }
                Tuple<long, long> processing = buffer.Dequeue();
                if (processing.Item1 > Time)
                    Time = processing.Item1;
                while (resault[j] == -1) j++;
                resault[j] = Time;
                j++;
                Time += processing.Item2;
            }
            return resault.ToArray();
        }

        private void MakePackets(long[] arrivalTimes, long[] processingTimes, Queue<Tuple<long, long>> packets)
        {
            for (int i = 0; i < arrivalTimes.Length; i++)
                packets.Enqueue(new Tuple<long, long>(arrivalTimes[i], processingTimes[i]));
        }
    }

    class Packet
    {
        public List<long> PrsTime;
        public long EntranceTime;
        public Packet(long entranceTime)
        {
            this.EntranceTime = entranceTime;
            PrsTime = new List<long>();
        }

    }

}
