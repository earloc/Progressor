using Progressor.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Progressor.Contractors;
using Progressor.Extensions;

namespace Progressor.Contractors {
    internal class ProgressiveIterator<T> : IProgressive<T> {

        private readonly IEnumerable<T> _Source;
        private readonly int _TotalCount;
        private int? _RoundigPrecision;

        public int Count {
            get {
                return _TotalCount;
            }
        }

        public bool EnumerationFinished {
            get; private set;
        }

        private double _Progress;
        public double Progress {
            get { return _Progress; }
            private set {
                _Progress = value;
                if (_Parent != null)
                    _Parent.SubProgress = Progress;
            }
        }

        private readonly IProgressInfo _Parent;
        public ProgressiveIterator(IEnumerable<T> source, IProgressInfo parent, int? totalCount = null, int? roundingPrecision = null) {
            if (source == null)
                throw new ArgumentNullException(nameof(source), "must not be null");

            _Parent = parent;

            _RoundigPrecision = roundingPrecision ?? IEnumerableExtensions.DefaultRoundingPrecision;

            if (_RoundigPrecision < 0)
                throw new ArgumentOutOfRangeException(nameof(roundingPrecision), _RoundigPrecision, "must be >= 0");

            _Source = source;
            if (totalCount.HasValue) {
                if (totalCount.Value < 0)
                    throw new ArgumentOutOfRangeException(nameof(totalCount), totalCount, "must be >= 0");
                _TotalCount = totalCount.Value;
            }
            else {
                _TotalCount = source.Count();
                if (_TotalCount < 0) {
                    throw new ArgumentOutOfRangeException(nameof(source), _TotalCount, "must contain 0 or more items");
                }
            }
        }

        public IEnumerator<IProgressInfo<T>> GetEnumerator() {
            var index = 0;
            EnumerationFinished = false;
            foreach (var item in _Source) {

                var progress = new ProgressInfo<T>(item, index++, _TotalCount, _RoundigPrecision);
                Progress = progress.Percent;
                progress.ProgressChanged += Progress_ProgressChanged;
                yield return progress;
            }

            Progress = 100;
            EnumerationFinished = true;
        }

        private void Progress_ProgressChanged(object sender, IProgressChangedEventArgs e) {
            Progress = e.Percent;
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

    }
}
