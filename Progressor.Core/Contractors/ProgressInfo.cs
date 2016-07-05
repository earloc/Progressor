using Progressor.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progressor.Contractors {
    internal class ProgressInfo<T> : IProgressInfo<T> {
        public ProgressInfo(T item, int current, int total) {
            
        }

        public T Item { get; }

        public double Percent { get; }

        public int Progress { get; }
    }
}
