using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progressor {
    /// <summary>
    /// provides information of a single progressive iteration
    /// </summary>
    public interface IProgressInfo {
        /// <summary>
        /// returns the zero based index of the current iteration
        /// </summary>
        int Index { get; }
        /// <summary>
        /// current (rounded) progress between 0 and 100
        /// </summary>
        int Progress { get; }
        /// <summary>
        /// the raw (unrounded) percentage, can reach values above 100
        /// </summary>
        double Percent { get; }
        /// <summary>
        /// returns the total count of items in this IProgresive
        /// </summary>
        int Total { get; }
        /// <summary>
        /// returns the one-based index of the current iteration
        /// </summary>
        int Iteration { get; }
    }

    /// <summary>
    /// provides progress information during enumeration of an <see cref="IProgressive{T}"/>
    /// </summary>
    /// <typeparam name="T">the original type which gets enumerated</typeparam>
    public interface IProgressInfo<T> : IProgressInfo {
        /// <summary>
        /// the original item that is enumerated
        /// </summary>
        T Item { get; }
    }

    internal interface ISupportSubProgress {
        double SubProgress { get; }
        void SetSubProgress(double value);
    }
}
