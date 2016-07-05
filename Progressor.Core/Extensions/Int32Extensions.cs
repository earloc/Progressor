using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progressor.Extensions {
    public static class Int32Extensions {
        public static double PercentOf(this int percent, double from) {
            return ((double)percent).PercentOf(from);
        }

        public static double AsPercentOf(this int value, double total) {
            return ((double)value).AsPercentOf(total);
        }
    }
}
