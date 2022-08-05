using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A8
{
    public class TreeHeight : Processor
    {
        public TreeHeight(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long nodeCount, long[] tree)
        {
            Node root=null;
            Node[] myNodes = new Node[nodeCount];
            for (int i = 0; i < nodeCount; i++)
                myNodes[i] = new Node(i,tree[i]);
            for(int i=0;i<nodeCount;i++)
            {
                if (myNodes[i].Parent == -1)
                    root = myNodes[i];
                else
                    myNodes[myNodes[i].Parent].Children.Add(myNodes[i]);
            }
            return DepthTree(root);
        }

        private long DepthTree(Node root)
        {
            long maxD = 0;
            Queue<Node> myQueue = new Queue<Node>();
            root.Depth = 1;
            myQueue.Enqueue(root);
            while (myQueue.Count > 0)
            {
                Node parent = myQueue.Dequeue();
                if (parent.Children.Count == 0)
                {
                    if (parent.Depth > maxD)
                        maxD = parent.Depth;
                    continue;
                }
                for(int i=0;i<parent.Children.Count;i++)
                {
                    parent.Children[i].Depth = parent.Depth+1;
                    myQueue.Enqueue(parent.Children[i]);
                }
            }
            return maxD;
        }
    }

    class Node
    {
        public long Index;
        public long Parent;
        public long Depth;
        public List<Node> Children;
        public Node(long i,long parent)
        {
            this.Children = new List<Node>();
            this.Index = i;
            this.Parent = parent;
        }
    }

}
