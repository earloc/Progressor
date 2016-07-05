using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progressor.Tests {
    [TestClass]
    public class ProgressorTests {

        [TestMethod]
        public void NonLinearProgressorCalculatesMaximumProgressOf80ForFirstStepWhenRelationIs8To2() {
            var sut = new Progressor(8, 2);

            var step = sut.Steps.First();

            var expected = 80d;
            var actual = step.MaxPercent;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NonLinearProgressorCalculatesMaximumProgressOf20ForSecondStepWhenRelationIs8To2() {
            var sut = new Progressor(8, 2);

            var step = sut.Steps.Last();

            var expected = 20d;
            var actual = step.MaxPercent;

            Assert.AreEqual(expected, actual);
        }
    }
}
