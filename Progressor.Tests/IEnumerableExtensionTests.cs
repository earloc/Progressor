using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Progressor.Extensions;

namespace Progressor.Tests {
    [TestClass]
    public class IEnumerableExtensionTests {
        [TestMethod]
        public void IteratingOver100ElementsYieldsEachPercent() {
            foreach (var x in Enumerable.Range(1, 100).AsProgressive()) {
                var actual = x.Progress;
                var expected = x.Item;

                Assert.AreEqual(expected, actual);
            }
        }
    }
}
