using Progressor;
using Progressor.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Collections.Generic {

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
            return source.AsProgressive(null, totalCount, roundingPrecision);
        }

        /// <summary>
        /// wraps an Enumerable to gain progress information during enumeration
        /// </summary>
        /// <typeparam name="T">the original type that gets enumerated</typeparam>
        /// <param name="parent">the parent iteration that this progressive descents into</param>
        /// <param name="source">the original source that gets enumerated</param>
        /// <param name="totalCount">optional, the total element count in <paramref name="source"/>. calls "Count()" on source when not specified/></param>
        /// <param name="roundingPrecision">the number of decimals percentage values should be rounded to. If ommitted or null, <see cref="DefaultRoundingPrecision"/> is used</param>
        public static IProgressive<T> AsProgressive<T>(this IEnumerable<T> source, IProgressInfo parent, int? totalCount = null, int? roundingPrecision = null) {
            return new Progressive<T>(source, parent, totalCount, roundingPrecision);
        }

        /// <summary>
        /// registers a polling tasks that periodically gets called to assist in reporting overall progress directly within foreach statements
        /// </summary>
        /// <typeparam name="T">type that gets enumerated</typeparam>
        /// <param name="source">the source progressive that gets polled</param>
        /// <param name="pollAction">tha actual polling action that gets executed</param>
        /// <param name="milliseconds">the interval between polling calls</param>
        /// <param name="cancellationToken">a cancellation token to cancel polling even if the progressive was not enumerated to 100 Percent</param>
        /// <returns></returns>
        public static IProgressive<T> Poll<T>(this IProgressive<T> source, Action<double> pollAction, int milliseconds = 50, CancellationToken? cancellationToken = null) {
            var token = cancellationToken ?? CancellationToken.None;
            Task.Run(() => {
                while (source.Percent < 100 || !token.IsCancellationRequested) {
                    Task.Delay(milliseconds).Wait();
                    pollAction(source.Percent);
                }
                pollAction(source.Percent);
            }, token);

            return source;
        }
    }
}
