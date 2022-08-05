using Microsoft.VisualStudio.TestTools.UnitTesting;
using A2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;
using System.Diagnostics;

namespace A2.Tests
{
    [TestClass()]//Grade:A2:100
    public class ProgramTests
    {
        [TestMethod()]
        public void NaiveMaxPairwiseProductTest()
        {
            List<int> test1 = new List<int>(3);
            test1.Add(1);
            test1.Add(2);
            test1.Add(3);
            Assert.IsTrue(Program.NaiveMaxPairwiseProduct(test1) == 6);

            List<int> test2 = new List<int>(3);
            test2.Add(10);
            test2.Add(12);
            test2.Add(15);
            test2.Add(20);
            Assert.IsTrue(Program.NaiveMaxPairwiseProduct(test2) == 300);
        }

        [TestMethod(), Timeout(500)]
        [DeploymentItem("TestData", "A2_TestData")]
        public void GradedTest_Performance()
        {
            TestTools.RunLocalTest("A2",Program.Process);
        }

        [TestMethod()]
        [DeploymentItem("TestData", "A2_TestData")]
        public void GradedTest_Conrrectness()
        {
            TestTools.RunLocalTest("A2",Program.Process);
        }

        [TestMethod()]
        public void GradedTest_Stress()
        {
            Stopwatch time = new Stopwatch();
            Random rand = new Random();
            time.Start();
            while (time.ElapsedTicks < 5000)
            {
                int n = rand.Next() % 200+2;
                int[] data = new int[n];
                for (int i = 0; i < n; i++)
                    data[i] = rand.Next() % 1000;
                long naive = Program.NaiveMaxPairwiseProduct(data.ToList());
                long fast = Program.FastMaxPairwiseProduct(data.ToList());
                Assert.IsTrue(naive == fast);
            }
        }

        [TestMethod()]
        public void FastMaxPairwiseProductTest()
        {
            List<int> test1 = new List<int>(3);
            test1.Add(1);
            test1.Add(2);
            test1.Add(3);
            Assert.IsTrue(Program.FastMaxPairwiseProduct(test1) == 6);

            List<int> test2 = new List<int>(3);
            test2.Add(10);
            test2.Add(12);
            test2.Add(15);
            test2.Add(20);
            Assert.IsTrue(Program.FastMaxPairwiseProduct(test2) == 300);
        }
    }
}