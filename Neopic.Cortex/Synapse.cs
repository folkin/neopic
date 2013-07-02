using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neopic.Cortex
{
    public class Synapse
    {
        public Dendrite Dendrite { get; set; }
        public Cell Target { get; set; }
        public byte Permanance { get; set; }
    }
}
