﻿using Progressor.Contracts;
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
            return _Source.Select((x, i) => new ProgressInfo<T>(x, i + 1, _TotalCount)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}