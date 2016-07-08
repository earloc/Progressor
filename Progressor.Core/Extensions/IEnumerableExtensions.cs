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
        private const int cDefaultRoundingPrecision = 2;

        private static int? _DefaultRoundingPrecision = cDefaultRoundingPrecision;
        /// <summary>
        /// spcifies the default rounding precision for percentage calculation. If set to null, no rounding at all will be applied. Defaults to 2.
        /// </summary>
        public static int? DefaultRoundingPrecision {
            get {
                return _DefaultRoundingPrecision;
            }
            set {
                if (value.HasValue && value.Value < 0)
                    throw new ArgumentOutOfRangeException(nameof(DefaultRoundingPrecision), value, "must be null or >= 0");

                _DefaultRoundingPrecision = value;
            }
        }
        /// <summary>
        /// wraps an Enumerable to gain progress information during enumeration
        /// </summary>
        /// <typeparam name="T">the original type that gets enumerated</typeparam>
        /// <param name="source">the original source that gets enumerated</param>
        /// <param name="totalCount">optional, the total element count in <paramref name="source"/>. calls "Count()" on source when not specified/></param>
        /// <param name="roundingPrecision">the number of decimals percentage values should be rounded to. If ommitted or null, <see cref="DefaultRoundingPrecision"/> is used</param>
        /// <returns></returns>
        public static IProgressive<T> AsProgressive<T> (this IEnumerable<T> source, int? totalCount = null, int? roundingPrecision = null) {
            return new ProgressiveIterator<T>(source, null, totalCount, roundingPrecision);
        }

        public static IProgressive<T> AsProgressive<T>(this IEnumerable<T> source, IProgressInfo parent, int? totalCount = null, int? roundingPrecision = null) {
            return new ProgressiveIterator<T>(source, parent, totalCount, roundingPrecision);
        }

        public static IProgressive<T> Poll<T>(this IProgressive<T> source, Action<double> poll) {
            Task.Run(() => {
                while (!source.EnumerationFinished) {
                    Task.Delay(50).Wait();
                    poll(source.Progress);
                }
            });

            return source;
        }
    }
}
