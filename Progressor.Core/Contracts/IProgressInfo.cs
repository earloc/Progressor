using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progressor.Contracts {
    /// <summary>
    /// provides progress information during enumeration of an <see cref="Progressor.Contracts.IProgressive{T}"/>
    /// </summary>
    /// <typeparam name="T">the original type which gets enumerated</typeparam>
    public interface IProgressInfo<T> {
        /// <summary>
        /// the original item that is enumerated
        /// </summary>
        T Item { get; }

        int Index { get; }

        /// <summary>
        /// current (rounded) progress between 0 and 100
        /// </summary>
        int Progress { get; }
        /// <summary>
        /// the raw (unrounded) percentage, can reach values above 100
        /// </summary>
        double Percent { get; }
    }
}
