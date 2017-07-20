using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progressor {

    /// <summary>
    /// abstraction for progressive enumeration
    /// </summary>
    public interface IProgressive {
        /// <summary>
        /// returns the total count of elements of this instance
        /// </summary>
        int Count { get; }

        /// <summary>
        /// returns the percentage of this isntance
        /// </summary>
        double Percent { get; }
    }

    /// <summary>
    /// typed abstraction for progressive enumeration
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IProgressive<T> : IEnumerable<IProgressInfo<T>>, IProgressive {
        
    }

    internal interface IProgressiveInternal<T> : IProgressive<T> {
        void Finished();
    }
}
