﻿using Progressor.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progressor.Contractors {
    internal class ProgressChangedEventArgs : IProgressChangedEventArgs {
        public double Percent{
            get; internal set;
        }
    }
}
