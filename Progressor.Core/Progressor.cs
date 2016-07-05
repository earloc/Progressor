﻿using Progressor.Contractors;
using Progressor.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progressor.Extensions;

namespace Progressor {
    public class Progressor {
        private int _A;
        public Progressor(params int[] distribution) {
            if (distribution == null)
                throw new ArgumentNullException(nameof(distribution), "must not be null");

            if (distribution.Length <= 0)
                throw new ArgumentOutOfRangeException(nameof(distribution), "must contain mor than 0 elements");

            var sum = distribution.Sum();


            Steps = distribution.Select(x => new Step(x.AsPercentOf(sum)));
        }

        public IEnumerable<IStep> Steps { get; set; }

    }
}