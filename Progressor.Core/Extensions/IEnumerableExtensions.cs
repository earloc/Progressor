using Progressor.Contractors;
using Progressor.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progressor.Extensions {
    /// <summary>
    /// IEnumerable Extensions for progress aware enumerations
    /// </summary>
    public static class IEnumerableExtensions {

        /// <summary>
        /// wraps an Enumerable to gain progress information during enumeration
        /// </summary>
        /// <typeparam name="T">the original type that gets enumerated</typeparam>
        /// <param name="source">the original source that gets enumerated</param>
        /// <param name="totalCount">optional, the total element count in <paramref name="source"/>. calls "Count()" on source when not specified/></param>
        /// <returns></returns>
        public static IProgressive<T> AsProgressive<T> (this IEnumerable<T> source, int? totalCount = null) {
            return new ProgressiveIterator<T>(source, totalCount);
        }

        public static IProgressive<T> AsProgressive<T>(this IEnumerable<T> source, IProgressInfo<T> parent, int? totalCount = null) {
            return new ProgressiveIterator<T>(source, totalCount);
        }

    }
}
