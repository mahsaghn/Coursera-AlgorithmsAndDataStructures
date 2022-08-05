using System;
using System.Collections;
using System.Collections.Generic;
using TestCommon;

namespace A11
{
    public class BinaryTreeTraversals : Processor
    {
        public BinaryTreeTraversals(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
             TestTools.Process(inStr, (Func<long[][], long[][]>)Solve);


        public long[][] Solve(long[][] nodes)
        {
            long[][] result = new long[3][];
            List<long> duringResult = new List<long>();
            Stack<long[]> mystack = new Stack<long[]>();
            mystack.Push(nodes[0]);
            InOrder_Travel(nodes, mystack,duringResult,nodes[0]);
            result[0] = duringResult.ToArray();

            duringResult = new List<long>();
            mystack = new Stack<long[]>();
            mystack.Push(nodes[0]);
            PreOrder_Travel(nodes, mystack,duringResult,nodes[0]);
            result[1] = duringResult.ToArray();

            duringResult = new List<long>();
            mystack = new Stack<long[]>();
            mystack.Push(nodes[0]);
            PostOrder_Travel(nodes, mystack,duringResult,nodes[0]);
            result[2] = duringResult.ToArray();

            return result;
        }

        private void InOrder_Travel(long[][] nodes, Stack<long[]> mystack,List<long> result,long[] node)
        {
            node = mystack.Pop();//khodesh ro be result ezafe mikone
            if (node[1] != -1)//bache chap dasht
            {
                mystack.Push(nodes[node[1]]);
                InOrder_Travel(nodes, mystack, result, mystack.Peek());
            }
            result.Add(node[0]);
            if (node[2] != -1)//bache rast dasht bache rastesh ro check mikone
            {
                mystack.Push(nodes[node[2]]);
                InOrder_Travel(nodes, mystack, result, mystack.Peek());
            }
        }

        private void PreOrder_Travel(long[][] nodes, Stack<long[]> mystack, List<long> result, long[] node)
        {
            node = mystack.Pop();//khodesh ro be result ezafe mikone
            result.Add(node[0]);
            if (node[1] != -1)//bache chap dasht
            {
                mystack.Push(nodes[node[1]]);
                PreOrder_Travel(nodes, mystack, result, mystack.Peek());
            }
            if (node[2] != -1)//bache rast dasht bache rastesh ro check mikone
            {
                mystack.Push(nodes[node[2]]);
                PreOrder_Travel(nodes, mystack, result, mystack.Peek());
            }
        }

        private void PostOrder_Travel(long[][] nodes, Stack<long[]> mystack, List<long> result, long[] node)
        {
            node = mystack.Pop();//khodesh ro be result ezafe mikone
            if (node[1] != -1)//bache chap dasht
            {
                mystack.Push(nodes[node[1]]);
                PostOrder_Travel(nodes, mystack, result, mystack.Peek());
            }
            if (node[2] != -1)//bache rast dasht bache rastesh ro check mikone
            {
                mystack.Push(nodes[node[2]]);
                PostOrder_Travel(nodes, mystack, result, mystack.Peek());
            }
            result.Add(node[0]);
        }
    }
}
