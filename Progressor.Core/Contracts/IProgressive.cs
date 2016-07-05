using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progressor.Contracts {
    /// <summary>
    /// wrapping interface supporting progress information during enumerations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IProgressive<T> : IEnumerable<IProgressInfo<T>> {
        /// <summary>
        /// indicates that the overall progress has changed, e.g.: from 41 to 42.
        /// </summary>
        event EventHandler<IProgressChangedEventArgs> ProgressChanged;

        int Count { get; }
    }
}
