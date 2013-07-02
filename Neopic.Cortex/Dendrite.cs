using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neopic.Cortex
{
    public class Dendrite
    {
        public Cell Cell { get; set; }
        public IList<Synapse> Synapses { get; set; }
        public bool IsActive { get; set; }
    }
}
