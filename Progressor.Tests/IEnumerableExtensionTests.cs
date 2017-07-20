using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace Progressor.Tests {
    [TestClass]
    public class IEnumerableExtensionTests {
        private IEnumerable<string> CreateStringSequence(int count, string prefix = "") {
            return Enumerable.Range(1, count).Select(i => prefix + i.ToString());
        }

        [TestMethod]
        public void LinearIteratingOver100ElementsYieldsEachPercent() {
            foreach (var x in CreateStringSequence(100).AsProgressive()) {
                var actual = x.Progress;
                var expected = x.Index;

                Assert.AreEqual(expected, actual);
            }
        }
        
        [TestMethod]
        public void ThreeLevelHierachicalLinearIterationOver200ElementsEachYields25_2525() {
            foreach (var first in CreateStringSequence(200, "A").AsProgressive(roundingPrecision: 4).Skip(50)) {//25 %
                foreach (var second in CreateStringSequence(200, "B").AsProgressive(first).Skip(50)) {//25 %
                    foreach (var third in CreateStringSequence(200, "C").AsProgressive(second).Skip(50)) {//25 %
                        var expected = 25.2525;
                        var actual = first.Percent;
                        Assert.AreEqual(expected, actual);
                        return;
                    }
                }
            }
        }

        [TestMethod]
        public void ThreeLevelHierachicalNonLinearIterationYields50_7910() {
            foreach (var first in CreateStringSequence(200, "A").AsProgressive(roundingPrecision: 5).Skip(100)) { //50 %
                foreach (var second in CreateStringSequence(100, "B").AsProgressive(first).Skip(79)) { //79%
                    foreach (var third in CreateStringSequence(500, "C").AsProgressive(second).Skip(60)) { //12%
                        var expected = 50.7912;
                        var actual = first.Percent;
                        Assert.AreEqual(expected, actual);
                        return;
                    }
                }
            }
        }

        public void ThreeLevelHierachicalNonLinearIterationYields50_7910AndReflectsInTopProgressive() {
            var top = CreateStringSequence(200, "A").AsProgressive(roundingPrecision: 5);

            foreach (var first in top.Skip(100)) {//50 %
                foreach (var second in CreateStringSequence(100, "B").AsProgressive(first).Skip(79)) {//79%
                    foreach (var third in CreateStringSequence(500, "C").AsProgressive(second).Skip(60)) { //12%
                        var expected = 50.7912;
                        var actual = first.Percent;
                        Assert.AreEqual(expected, actual);
                        return;
                    }
                }
            }
        }

        [TestMethod]
        public void ThreeLevelHierachicalNonLinearIterationRoundsTo50_8WhenPrecisionIsOneDigit() {
            foreach (var first in CreateStringSequence(200, "A").AsProgressive(roundingPrecision:1).Skip(100)) //50 %
                foreach (var second in CreateStringSequence(100, "B").AsProgressive(first).Skip(79)) //79%
                    foreach (var third in CreateStringSequence(500, "C").AsProgressive(second).Skip(60)) { //12%
                        var expected = 50.8;
                        var actual = first.Percent;
                        Assert.AreEqual(expected, actual);
                        return;
                    }
        }
    }
}
