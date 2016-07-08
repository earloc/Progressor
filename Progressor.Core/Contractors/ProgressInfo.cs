using Progressor.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progressor.Extensions;

namespace Progressor.Contractors {
    internal class ProgressInfo<T> : IProgressInfo<T> {

        private readonly int? _Precision;

        public ProgressInfo(T item, int zeroBasedIndex, int total, int? precision = null) {
            Item = item;
            if (total < 0)
                throw new ArgumentOutOfRangeException(nameof(total), total, "must be >= 0");

            if (total == 0) {
                _Percent = 100;
                return;
            }
            Total = total;

            Index = zeroBasedIndex;
            var iteration = Iteration = zeroBasedIndex + 1;

            _Percent = Index.AsPercentOf(total);

            _Precision = precision;
        }

        public T Item { get; }
        public int Iteration { get; }
        public int Index { get; }
        public int Total { get; }

        private double _Percent = 0d;

        public double Percent {
            get {
                var percent = Math.Max(0, Math.Min(100, _Percent + SubProgress.PercentOf(100d / Total)));
                if (_Precision.HasValue)
                    percent = Math.Round(percent, _Precision.Value);
                return percent;
            }
        }

        public int Progress {
            get {
                return Convert.ToInt16(Math.Round(_Percent));
            }
        }

        private double _SubProgress;
        public double SubProgress {
            get {
                return _SubProgress;
            }

            set {
                _SubProgress = value;
                ProgressChanged?.Invoke(this, new ProgressChangedEventArgs() {
                    Percent = Percent
                });
            }
        }

        public event EventHandler<IProgressChangedEventArgs> ProgressChanged;
    }
}
