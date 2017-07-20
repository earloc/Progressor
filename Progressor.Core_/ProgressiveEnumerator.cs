using Progressor.Contractors;
using Progressor.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progressor {
    internal class ProgressiveEnumerator<T> : IEnumerator<IProgressInfo<T>> {
        
        public ProgressiveEnumerator(Progressive<T> owner, IEnumerable<T> source, int total, int? roundingPrecision, ISupportSubProgress parent) {
            _Owner = owner;

            var wrapped = source.Select((item, index) => new ProgressInfo<T>(item, index, total, roundingPrecision));

            _Enumerator = wrapped.GetEnumerator();
            _Parent = parent;
        }

        
        private IEnumerator<ProgressInfo<T>> _Enumerator;
        private readonly Progressive<T> _Owner;
        private readonly ISupportSubProgress _Parent;

        private ProgressInfo<T> _Current;
        public IProgressInfo<T> Current {
            get {
                return _Current;
            }
        }

        object IEnumerator.Current {
            get {
                return Current;
            }
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing) {
            if (disposing) {
                DetachCurrent();
                _Enumerator.Dispose();
                _Current = null;
                _Enumerator = null;
                _Owner.Finished();
            }
        }

        public bool MoveNext() {
            DetachCurrent();

            var ok = _Enumerator.MoveNext();
            if (!ok)
                return false;

            _Current = _Enumerator.Current;
            _Owner.Percent = _Current.Percent;
            _Parent?.SetSubProgress(_Current.Percent);
            _Current.ProgressChanged += _Current_ProgressChanged;

            return ok;
        }

        private void DetachCurrent() {
            if (_Current != null)
                _Current.ProgressChanged -= _Current_ProgressChanged;
        }

        private void _Current_ProgressChanged(object sender, IProgressChangedEventArgs e) {
            _Owner.Percent = e.Percent;
            _Parent?.SetSubProgress(_Current.Percent);
        }

        public void Reset() {
            _Enumerator.Reset();
        }
    }
}
