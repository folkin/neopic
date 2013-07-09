using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neopic.Types;

namespace Neopic.Cortex
{
    internal class SpatialPooler
    {
        public List<SpatialColumn> Columns { get; set; }
        public int InhibitionRadius
        {
            get
            {
                return (int)Columns.Average(c => c.Radius);
            }
        }
        
        public void UpdateMinDutyCycles(int inhibitionRadius, float percentOfMax)
        {
            if (inhibitionRadius >= Columns.Count / 2)
            {
                var max = Columns.Max(c => c.DutyCycle);
                Columns.ForEach(c => c.MinDutyCycle = max * percentOfMax);
            }
            else
            {
                for (int i = 0; i < Columns.Count; i++)
                {
                    Columns[i].MinDutyCycle = Columns.RadialSlice(i, inhibitionRadius).Max(c => c.DutyCycle) * percentOfMax;
                }
            }
        }

        public void Process(SparseBitArray input, int threshold)
        {

            SparseBitArray active = new SparseBitArray(Columns.Count);

        }
    }
}
