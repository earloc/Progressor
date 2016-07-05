using Progressor.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progressor.Contractors {
    internal class Progress<T> : IProgressInfo<T> {
        public T Item {
            get {
                throw new NotImplementedException();
            }
        }

        public double Percent {
            get {
                throw new NotImplementedException();
            }
        }

        int Contracts.IProgressInfo<T>.Progress {
            get {
                throw new NotImplementedException();
            }
        }
    }
}
