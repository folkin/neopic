using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neopic.Cortex
{
    public class Dendrite
    {
        public Cell Cell { get; set; }
        public bool IsActive { get; set; }

        IDictionary<int, byte> Permanance { get; set; }
        SparseBitArray Synapses { get; set; }
    }
}
