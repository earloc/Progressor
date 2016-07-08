using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progressor.Contracts {
    /// <summary>
    /// EventArg-abstraction for <see cref="IProgressive{T}.ProgressChanged"/>
    /// </summary>
    public interface IProgressChangedEventArgs {
        double Percent { get; }
    }
}
