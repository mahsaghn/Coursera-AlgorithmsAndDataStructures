using Microsoft.VisualStudio.TestTools.UnitTesting;
using A3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A3.Tests
{
    [TestClass()]//Grade:A3:100
    public class ProgramTests
    {
        [TestMethod(), Timeout(1000)]
        [DeploymentItem("TestData", "A3_TestData")]
        public void Graded_FibonacciTest()
        {
            TestCommon.TestTools.RunLocalTest("A3", Program.ProcessFibonacci, "TD1");
        }

        [TestMethod(), Timeout(1000)]
        [DeploymentItem("TestData", "A3_TestData")]
        public void Fibonacci_LastDigitTest()
        // پس کجا رفت این
        // Graded_ 😱😱😱😱
        {
            TestCommon.TestTools.RunLocalTest("A3", Program.ProcessFibonacci_LastDigit, "TD2");
        }

        [TestMethod(), Timeout(1000)]
        [DeploymentItem("TestData", "A3_TestData")]
        public void GCDTest()
        {
            TestCommon.TestTools.RunLocalTest("A3", Program.ProcessGCD, "TD3");
        }

        [TestMethod(), Timeout(1000)]
        [DeploymentItem("TestData", "A3_TestData")]
        public void LCMTest()
        {
            TestCommon.TestTools.RunLocalTest("A3", Program.ProcessLCM, "TD4");
        }

        [TestMethod(), Timeout(1000)]
        [DeploymentItem("TestData", "A3_TestData")]
        public void Fibonacci_ModTest()
        {
            TestCommon.TestTools.RunLocalTest("A3", Program.ProcessFibonacci_Mod, "TD5");
        }

        [TestMethod(), Timeout(1000)]
        [DeploymentItem("TestData", "A3_TestData")]
        public void Fibonacci_SumTest()
        {
            TestCommon.TestTools.RunLocalTest("A3", Program.ProcessFibonacci_Sum, "TD6");
        }

        [TestMethod(), Timeout(1000)]
        [DeploymentItem("TestData", "A3_TestData")]
        public void Fibonacci_Partial_SumTest()
        {
            TestCommon.TestTools.RunLocalTest("A3", Program.ProcessFibonacci_Partial_Sum, "TD7");
        }

        [TestMethod(), Timeout(1000)]
        [DeploymentItem("TestData", "A3_TestData")]
        public void Fibonacci_Sum_SquaresTest()
        {
            TestCommon.TestTools.RunLocalTest("A3", Program.ProcessFibonacci_Sum_Squares, "TD8");
        }


        [TestMethod()]
        public void GCDTest1()
        {
            Assert.IsTrue(Program.GCD(17, 5) == 1);
            Assert.IsTrue(Program.GCD(25, 18) == 1);
        }

        [TestMethod()]
        public void Fibonacci_LastDigitTest1()
        {
            Assert.IsTrue(Program.Fibonacci_LastDigit(331) == 9);
            Assert.IsTrue(Program.Fibonacci_LastDigit(327305) == 5);
            Assert.IsTrue(Program.Fibonacci_LastDigit(746) == 3);
            Assert.IsTrue(Program.Fibonacci_LastDigit(10000000) == 5);
            Assert.IsTrue(Program.Fibonacci_LastDigit(123456) == 2);
            Assert.IsTrue(Program.Fibonacci_LastDigit(999999) == 6);
        }

        [TestMethod()]
        public void LCMTest1()
        {
            Assert.IsTrue(Program.LCM(2000000000, 1999999999) == 3999999998000000000);
        }

        [TestMethod()]
        public void Fibonacci_ModTest1()
        {
            Assert.IsTrue(Program.Fibonacci_Mod(950520, 131) == 32);
            Assert.IsTrue(Program.Fibonacci_Mod(239, 1000) == 161);
        }
 
        [TestMethod()]
        public void Fibonacci_SumTest1()
        {
            Assert.IsTrue(Program.Fibonacci_Sum(100) == 5);
            Assert.IsTrue(Program.Fibonacci_Sum(3) == 4);
            Assert.IsTrue(Program.Fibonacci_Sum(150482468097531) == 2);
        }
 
        [TestMethod()]
        public void Fibonacci_Partial_SumTest1()
        {
            Assert.IsTrue(Program.Fibonacci_Partial_Sum(10,10) == 5);
            Assert.IsTrue(Program.Fibonacci_Partial_Sum(10, 200) == 2);

        }

        [TestMethod()]
        public void Fibonacci_Sum_SquaresTest1()
        {
            Assert.IsTrue(Program.Fibonacci_Sum_Squares(73) == 1);
            Assert.IsTrue(Program.Fibonacci_Sum_Squares(1234567890) == 0);
        }
    }
}