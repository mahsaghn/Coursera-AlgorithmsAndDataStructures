using System;
using System.Collections.Generic;
using TestCommon;

namespace A11
{
    public class SetWithRageSums : Processor
    {
        public SetWithRageSums(string testDataName) : base(testDataName)
        {
            CommandDict =
                        new Dictionary<char, Func<string, long[]>>()
                        {
                            ['+'] = Add,
                            ['-'] = Del,
                            ['?'] = Find,
                        };
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string[], string[]>)Solve);

        public readonly Dictionary<char, Func<string, long[]>> CommandDict;

        protected const long M = 1_000_000_001;

        protected long X = 0;

        protected List<long[]> nodes;

        public string[] Solve(string[] lines)
        {
            X = 0;
            nodes = new List<long[]>();
            List<string> result = new List<string>();
            foreach(var line in lines)
            {
                char cmd = line[0];
                string args = line.Substring(1).Trim();
                var output = CommandDict[cmd](args);
                if (null != output)
                    result.Add(output.ToString());
            }
            return result.ToArray();
        }      

        private long[] Add(string arg)
        {
            long i = long.Parse(arg);
            long[] position = Find(arg);
            if (position[0] != i)
            {
                nodes.Add(new long[] { i, -1, -1,position[0] });
                if (i < position[0])//be chap ezafe she
                    position[1] = nodes.Count - 1;
                else
                    position[2] = nodes.Count - 1;
            }
            return position;
        }

        private long[] Del(string arg)
        {
            long i = long.Parse(arg);
            long[] position = Find(arg);
            if (position[0] == i)
                ;
            return null;
        }

        private long[] Splay(long[] node)
        {
            /*if((nodes[2][1] == node[3] && nodes[2][2] == nodes[2][0])
                || (nodes[2][2] == node[0] && nodes[2][2] == nodes[2][0]))*/
            return new long[] { };
        }

        private long[] Find(string arg)
            => ReturnFindedPosition(int.Parse(arg),nodes[0]);

        private long[] ReturnFindedPosition(int value,long[] node)
        {
            if (node[1]!=-1 && value < node[1])
                return ReturnFindedPosition(value, nodes[(int)node[1]]);
            if (node[2] != -1 && node[2] < value)
                return ReturnFindedPosition(value, nodes[(int)node[2]]);
            return node;
        }
    }
}
