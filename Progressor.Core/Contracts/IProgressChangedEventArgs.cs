using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progressor.Contracts {
    /// <summary>
    /// EventArg-abstraction for <see cref="Progressor.Contracts.IProgressive{T}.ProgressChanged"/>
    /// </summary>
    public interface IProgressChangedEventArgs {
        /// <summary>
        /// the current overall progress
        /// </summary>
        int Current { get; }
    }
}
