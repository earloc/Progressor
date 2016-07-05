using Progressor.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progressor.Contractors {
    internal class Step : IStep {

        internal Step(double maxPercent) {
            MaxPercent = maxPercent;
        }

        public double MaxPercent { get; }

    }
}
