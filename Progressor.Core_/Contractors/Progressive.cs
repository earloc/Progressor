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
    internal class Progressive<T> : IProgressiveInternal<T> {

        private readonly IEnumerable<T> _Source;
        private readonly int _TotalCount;
        private int? _RoundigPrecision;

        public int Count {
            get {
                return _TotalCount;
            }
        }

        private double _Progress;
        public double Percent {
            get { return _Progress; }
            internal set {
                _Progress = value;
                _Parent?.SetSubProgress(value);
            }
        }

        public Progressive(IEnumerable<T> source, IProgressInfo parent, int? totalCount = null, int? roundingPrecision = null) {
            if (source == null)
                throw new ArgumentNullException(nameof(source), "must not be null");

            _Parent = parent as ISupportSubProgress;

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

        private readonly ISupportSubProgress _Parent;

        public IEnumerator<IProgressInfo<T>> GetEnumerator() {
            return new ProgressiveEnumerator<T>(this, _Source, _TotalCount, _RoundigPrecision, _Parent);
        }

        private void Progress_ProgressChanged(object sender, IProgressChangedEventArgs e) {
            Percent = e.Percent;
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public void Finished() {
            Percent = 100;
        }
    }
}
