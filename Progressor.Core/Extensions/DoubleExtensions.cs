using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progressor.Extensions {
    /// <summary>
    /// Extensions for percentage related calculations
    /// </summary>
    public static class DoubleExtensions {

        /// <summary>
        /// calulates the value of <paramref name="percent"/> from <paramref name="from"/>
        /// e.g.: <paramref name="percent"/> = 25, <paramref name="from"/> = 200 -> returns 50
        /// </summary>
        /// <param name="percent"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public static double PercentOf(this double percent, double from) {
            return percent * from / 100d;
        }

        /// <summary>
        /// calculates the percentage of <paramref name="value"/> in respect to <paramref name="from"/>
        /// e.g.: <paramref name="value"/> = 50, <paramref name="from"/> = 200 -> returns 25
        /// </summary>
        /// <param name="value"></param>
        /// <param name="from"></param>
        /// <returns>the percentage of <paramref name="value"/> in respect to <paramref name="from"/></returns>
        public static double AsPercentOf(this double value, double from) {
            return value / from * 100d;
            
        }
    }
}
