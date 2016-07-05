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

        [TestMethod]
        public void PercentOfReturns0For0PercentOf100() {

            var actual = 0d.PercentOf(100);
            var expected = 0d;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PercentOfReturns10For100PercentOf10() {

            var actual = 100d.PercentOf(10);
            var expected = 10d;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PercentOfReturns50For200PercentOf25() {

            var actual = 200d.PercentOf(25);
            var expected = 50d;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PercentOfReturnsMinus50ForMinus25PercentOf200() {

            var actual = -25d.PercentOf(200);
            var expected = -50d;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PercentOfReturnsMinus50For25PercentOfMinus200() {

            var actual = 25d.PercentOf(-200);
            var expected = -50d;

            Assert.AreEqual(expected, actual);
        }
    }
}
