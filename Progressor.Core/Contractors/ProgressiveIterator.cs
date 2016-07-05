using Progressor.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Progressor.Contractors;

namespace Progressor.Contractors {
    internal class ProgressiveIterator<T> : IProgressive<T> {

        private readonly IEnumerable<T> _Source;
        private readonly int _TotalCount;

        public ProgressiveIterator(IEnumerable<T> source, int? totalCount = null) {
            if (source == null)
                throw new ArgumentNullException(nameof(source), "must not be null");

            _Source = source;

            _TotalCount = totalCount ?? source.Count();
        }

        public IEnumerator<IProgressInfo<T>> GetEnumerator() {
            return _Source.Select((x, i) => new ProgressInfo<T>(x, 0, 0)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
