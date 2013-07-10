using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neopic.Cortex
{
    public class SpatialColumn
    {
        public int Index { get; set; }
        public IDictionary<int, byte> Permanance { get; set; }
        public SparseBitArray Synapses { get; set; }
        public float DutyCycle { get; set; }
        public float MinDutyCycle { get; set; }

        public int Center
        {
            get
            {
                return Synapses.Center;
            }
        }

        public int Radius
        {
            get
            {
                int center = Center;
                return Math.Max(Math.Abs(center - Synapses.Min), Math.Abs(center - Synapses.Max));
            }
        }
    }
}
