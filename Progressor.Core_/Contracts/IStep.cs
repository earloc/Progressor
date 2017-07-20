using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progressor.Contracts {
    /// <summary>
    /// abstraction for a single step during a <see cref="Progressor"/> calculation
    /// </summary>
    public interface IStep {
        /// <summary>
        /// returns the maximum absolut percentage for this step
        /// </summary>
        double MaxPercent { get; }
    }
}
