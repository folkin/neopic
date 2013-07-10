using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neopic.Cortex
{
    public partial class Column
    {
        public Node Node { get; set; }
        public int Index { get; set; }
        public bool IsActive { get; set; }
    }


    public partial class Column
    {
        public IDictionary<int, byte> SpatialPermanance { get; set; }
        public SparseBitArray SpatialSynapses { get; set; }
        public float SpatialDutyCycle { get; set; }
        public float SpatialMinDutyCycle { get; set; }

        public int SpatialCenter
        {
            get
            {
                return SpatialSynapses.Center;
            }
        }

        public int SpatialRadius
        {
            get
            {
                int center = SpatialCenter;
                return Math.Max(Math.Abs(center - SpatialSynapses.Min), Math.Abs(center - SpatialSynapses.Max));
            }
        }

        public void UpdateSpatialDutyCycle(int period)
        {
            int inc = IsActive ? 1 : 0;
            SpatialDutyCycle = (((period - 1) * SpatialDutyCycle) + inc) / period;
        }
    }


    public partial class Column
    {
    }
}
