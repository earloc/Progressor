using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progressor.Contracts {
    public interface IProgressChangedEventArgs {
        int Current { get; }
    }
}
