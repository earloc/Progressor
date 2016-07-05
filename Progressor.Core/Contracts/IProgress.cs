using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progressor.Contracts {
    public interface IProgressInfo<T> {
        T Item { get; }
        int Progress { get; }
        double Percent { get; }
    }
}
