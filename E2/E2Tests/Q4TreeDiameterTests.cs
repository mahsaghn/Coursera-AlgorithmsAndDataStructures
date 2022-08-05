using Microsoft.VisualStudio.TestTools.UnitTesting;
using E2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2.Tests
{
    [TestClass()]
    public class Q4TreeDiameterTests//Grade:E2.4:30
    {
        [TestMethod()]
        public void Q4TreeDiameterTest()
        {

            Q4TreeDiameter td = new Q4TreeDiameter(10, 0);
        }

        [TestMethod()]
        public void TreeHeightTest()
        {
            Q4TreeDiameter td = new Q4TreeDiameter(1, 0);
            int result = td.TreeHeight();
            Assert.IsTrue(result == 1);

            Q4TreeDiameter td1 = new Q4TreeDiameter(2, 0);
            int result1 = td1.TreeHeight();
            Assert.IsTrue(result1 == 2);

            Q4TreeDiameter td2 = new Q4TreeDiameter(3, 0);
            td2.Nodes
                = new List<int>[3] { new List<int> { 1, 2 }, new List<int> { }, new List<int> { } };
            int result2 = td2.TreeHeight();
            Assert.IsTrue(result2 == 2);

            Q4TreeDiameter td3 = new Q4TreeDiameter(5, 0);
            td3.Nodes
                = new List<int>[5] { new List<int> { 1, 2 }, new List<int> { 3, 4 }, new List<int> { }, new List<int> { }, new List<int> { } };
            int result3 = td3.TreeHeight();
            Assert.IsTrue(result3 == 3);

            Q4TreeDiameter td4 = new Q4TreeDiameter(6, 0);
            td4.Nodes
               = new List<int>[6] { new List<int> { 1, 2 }, new List<int> { 3, 4 }, new List<int> { }, new List<int> { }, new List<int> { 5 }, new List<int> { } };
            int result4 = td4.TreeHeight();
            Assert.IsTrue(result4 == 4);
        }

        [TestMethod()]
        public void TreeHeightFromNodeTest()
        {
            Q4TreeDiameter td1 = new Q4TreeDiameter(2, 0);
            td1.Nodes
                = new List<int>[2] { new List<int> { 1 }, new List<int> { },};
            int result1 = td1.TreeHeightFromNode(1);
            Assert.IsTrue(result1 == 2);

            Q4TreeDiameter td2 = new Q4TreeDiameter(3, 0);
            td2.Nodes
                = new List<int>[3] { new List<int> { 1, 2 }, new List<int> { }, new List<int> { } };
            int result2 = td2.TreeHeightFromNode(2);
            Assert.IsTrue(result2 == 3);

            Q4TreeDiameter td3 = new Q4TreeDiameter(5, 0);
            td3.Nodes
                = new List<int>[5] { new List<int> { 1, 2 }, new List<int> { 3, 4 }, new List<int> { }, new List<int> { }, new List<int> { } };
            int result3 = td3.TreeHeightFromNode(4);
            Assert.IsTrue(result3 == 4);

            Q4TreeDiameter td4 = new Q4TreeDiameter(6, 0);
            td4.Nodes
               = new List<int>[6] { new List<int> { 1, 2 }, new List<int> { 3, 4 }, new List<int> { }, new List<int> { }, new List<int> { 5 }, new List<int> { } };
            int result4 = td4.TreeHeightFromNode(5);
            Assert.IsTrue(result4 == 5);
        }

        [TestMethod()]
        public void TreeDiameterN2Test()
        {
            Q4TreeDiameter td1 = new Q4TreeDiameter(2, 0);
            td1.Nodes
                = new List<int>[2] { new List<int> { 1 }, new List<int> { }, };
            int result1 = td1.TreeDiameterN2();
            Assert.IsTrue(result1 == 2);

            Q4TreeDiameter td2 = new Q4TreeDiameter(3, 0);
            td2.Nodes
                = new List<int>[3] { new List<int> { 1, 2 }, new List<int> { }, new List<int> { } };
            int result2 = td2.TreeDiameterN2();
            Assert.IsTrue(result2 == 3);

            Q4TreeDiameter td3 = new Q4TreeDiameter(5, 0);
            td3.Nodes
                = new List<int>[5] { new List<int> { 1, 2 }, new List<int> { 3, 4 }, new List<int> { }, new List<int> { }, new List<int> { } };
            int result3 = td3.TreeDiameterN2();
            Assert.IsTrue(result3 == 4);

            Q4TreeDiameter td4 = new Q4TreeDiameter(6, 0);
            td4.Nodes
               = new List<int>[6] { new List<int> { 1, 2 }, new List<int> { 3, 4 }, new List<int> { }, new List<int> { }, new List<int> { 5 }, new List<int> { } };
            int result4 = td4.TreeDiameterN2();
            Assert.IsTrue(result4 == 5);
        }

        [TestMethod()]
        public void TreeDiameterNTest()
        {
            Assert.Inconclusive();
        }
    }
}