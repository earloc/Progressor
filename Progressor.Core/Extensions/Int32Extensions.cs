using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progressor.Extensions {
    /// <summary>
    /// Extensions for percentage related calculations
    /// </summary>
    public static class Int32Extensions {
        /// <summary>
        /// calulates the value of <paramref name="percent"/> from <paramref name="from"/>
        /// e.g.: <paramref name="percent"/> = 25, <paramref name="from"/> = 200 -> returns 50
        /// </summary>
        /// <param name="percent"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public static double PercentOf(this int percent, double from) {
            return ((double)percent).PercentOf(from);
        }

        /// <summary>
        /// calculates the percentage of <paramref name="value"/> in respect to <paramref name="total"/>
        /// e.g.: <paramref name="value"/> = 50, <paramref name="total"/> = 200 -> returns 25
        /// </summary>
        /// <param name="value"></param>
        /// <param name="total"></param>
        /// <returns>the percentage of <paramref name="value"/> in respect to <paramref name="total"/></returns>
        public static double AsPercentOf(this int value, double total) {
            return ((double)value).AsPercentOf(total);
        }
    }
}
