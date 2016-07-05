using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Progressor.Tests {
    [TestClass]
    public class DobuleExtensionTests {
        [TestMethod]
        public void PercentOfReturns50For50PercentOf100() {

            var actual = 50.PercentOf(100);
            var expected = 50;

            Assert.AreEqual(expected, actual);

        }
    }
}
