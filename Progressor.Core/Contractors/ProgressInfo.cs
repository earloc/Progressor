using Progressor.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progressor.Extensions;

namespace Progressor.Contractors {
    internal class ProgressInfo<T> : IProgressInfo<T> {
        public ProgressInfo(IProgressConsumer consumer, T item, int current, int total, int? precision = null) {
            Item = item;

            if (total < 0)
                throw new ArgumentOutOfRangeException(nameof(total), total, "must be >= 0");

            if (total == 0) {
                Percent = Progress = 100;
                return;
            }

            var percent = Math.Max(0, Math.Min(100, current.AsPercentOf(total)));

            if (precision.HasValue)
                percent = Math.Round(percent, precision.Value);

            Percent = percent;

            var progress = Convert.ToInt16(Math.Round(percent));

            consumer.ReportProgress(Progress = progress);
        }

        public T Item { get; }

        public double Percent { get; }

        public int Progress { get; }
    }
}
