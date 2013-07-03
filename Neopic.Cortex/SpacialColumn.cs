using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neopic.Cortex
{
    public class SpacialColumn
    {
        public IDictionary<int, byte> Permanance { get; set; }
        public SortedSet<int> Synapses { get; set; }
        public float DutyCycle { get; set; }

        public int Center
        {
            get
            {
                return (int)Synapses.Average();
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
