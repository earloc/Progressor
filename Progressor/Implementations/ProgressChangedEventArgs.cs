using Progressor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progressor.Implementations {
    internal class ProgressChangedEventArgs : IProgressChangedEventArgs {
        public double Percent{
            get; internal set;
        }
    }
}
