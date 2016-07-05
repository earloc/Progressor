using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Progressor.Extensions;

namespace Progressor.Tests {
    [TestClass]
    public class DobuleExtensionTests {
        [TestMethod]
        public void PercentOfReturns50For50PercentOf100() {

            var actual = 50d.PercentOf(100);
            var expected = 50d;

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void PercentOfReturns500For50PercentOf1000() {

            var actual = 50d.PercentOf(1000);
            var expected = 500d;

            Assert.AreEqual(expected, actual);

        }


    }
}
