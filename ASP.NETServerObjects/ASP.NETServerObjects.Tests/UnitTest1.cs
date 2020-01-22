using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASP.NETServerObjects.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddNumbersTestMethod1()
        {
            ServerObjects sb = new ServerObjects();
            Assert.AreEqual(sb.AddNumbers(2,2),4);
        }

        [TestMethod]
        public void AddNumbersTestMethod2()
        {
            ServerObjects sb = new ServerObjects();
            Assert.AreEqual(sb.AddNumbers(2, 2), 5);
        }
    }
}
