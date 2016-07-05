using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progressor.Extensions {
    public static class DoubleExtensions {

        public static double PercentOf(this double percent, double from) {
            return percent * from / 100d;
        }

        public static double AsPercentOf(this double value, double total) {
            return value * 100d / total;
        }
    }
}
