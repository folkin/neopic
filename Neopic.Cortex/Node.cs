﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neopic.Cortex
{
    public class Node
    {
        public long Timestamp { get; set; }
        public IList<Column> Columns { get; set; }
    }
}
