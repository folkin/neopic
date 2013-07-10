using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neopic.Types;

namespace Neopic.Cortex
{
    public abstract class SpatialPooler
    {
        public int CalculateInhibitionRadius(IEnumerable<Column> columns)
        {
            return (int)columns.Average(c => c.SpatialRadius);
        }
        
        public void UpdateMinDutyCycles(IList<Column> columns, int inhibitionRadius, float percentOfMax)
        {
            if (inhibitionRadius >= columns.Count / 2)
            {
                var max = columns.Max(c => c.SpatialDutyCycle);
                foreach (var c in columns)
                {
                    c.SpatialMinDutyCycle = max * percentOfMax;
                }
            }
            else
            {
                for (int i = 0; i < columns.Count; i++)
                {
                    columns[i].SpatialMinDutyCycle = columns.RadialSlice(i, inhibitionRadius).Max(c => c.SpatialDutyCycle) * percentOfMax;
                }
            }
        }

        public abstract void Process(IList<Column> columns, long timestamp, SparseBitArray input, int threshold);
        
    }
}
