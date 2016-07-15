using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progressor.Contracts {
    /// <summary>
    /// EventArg-abstraction for <see cref="IProgressive{T}"/>
    /// </summary>
    public interface IProgressChangedEventArgs {
        /// <summary>
        /// returns the current percentage of a progressive enumeration
        /// </summary>
        double Percent { get; }
    }
}
