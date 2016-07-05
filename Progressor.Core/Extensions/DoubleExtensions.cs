﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progressor.Extensions {
    public static class DoubleExtensions {

        public static double PercentOf(this double percentile, double total) {
            return percentile * total / 100d;
        }

        public static double AsPercentOf(this double value, double total) {
            return value * 100d / total;
        }

    }
}
