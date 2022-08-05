using System;
using System.Collections.Generic;
using TestCommon;

namespace A11
{
    public class IsItBST : Processor
    {
        public IsItBST(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);


        public bool Solve(long[][] nodes)
        {
            Stack<long[]> mystack = new Stack<long[]>();
            long[] node = nodes[0];
            mystack.Push(node);
            long maxLeft, minRight,minLeft,maxRight;
            return CheckBst_PostOrder_Travel(nodes, mystack, node,
                out maxRight,out minLeft,out maxLeft, out minRight);
        }

        private bool CheckBst_PostOrder_Travel(long[][] nodes, Stack<long[]> mystack,
            long[] node, out long maxRight, out long minLeft
            , out long minRight, out long maxLeft)
        {
            bool IsBt = true;
            maxRight = long.MinValue;
            maxLeft = long.MinValue;
            minLeft = long.MaxValue;
            minRight = long.MaxValue;
            node = mystack.Pop();//khodesh ro be result ezafe mikone
            if (node[1] != -1)//bache chap dasht
            {
                long minR=0,minL=0,maxR=0, maxL=0;
                mystack.Push(nodes[node[1]]);
                IsBt=IsBt && CheckBst_PostOrder_Travel(nodes, mystack, mystack.Peek(),
                    out maxR, out minL,out minR,out maxL);
                maxLeft = maxL;
                minLeft = minL;
            }
            if (node[2] != -1)//bache rast dasht bache rastesh ro check mikone
            {
                long minR=0, minL=0, maxR=0, maxL=0;
                mystack.Push(nodes[node[2]]);
                IsBt =IsBt && CheckBst_PostOrder_Travel(nodes, mystack, mystack.Peek(),
                    out maxR, out minL, out minR, out maxL);
                minRight = minR;
                maxRight = maxR;
            }
            if ((maxLeft!=long.MinValue && maxLeft >= node[0]) 
                || (minRight!=long.MaxValue && minRight <= node[0]))
            {
                IsBt = false;
            }
            maxRight = Max(node[0], maxRight);
            minRight = Min(node[0], minLeft);
            maxLeft = maxRight;
            minLeft = minRight;
            return IsBt;
        }

        private long Max(long v, long minRight)
        {
            if (v > minRight)
                return v;
            return minRight;
        }

        private long Min(long v, long maxLeft)
        {
            if (v < maxLeft)
                return v;
            return maxLeft;
        }
    }    
}
