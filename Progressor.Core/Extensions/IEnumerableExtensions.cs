using Progressor.Contractors;
using Progressor.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progressor.Extensions {
    public static class IEnumerableExtensions {

        public static IProgressive<T> AsProgressive<T> (this IEnumerable<T> source, int? totalCount = null) {
            return new ProgressiveIterator<T>(source, totalCount);
        }

    }
}
