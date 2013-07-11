using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neopic.Linq;

namespace Neopic.Cortex.Components
{
    public class LearningSpatialPooler : ISpatialPooler
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

        public void Process(IList<Column> columns, long timestamp, SparseBitArray input, int threshold)
        {
            var dutyPeriod = (int)Math.Min(timestamp + 1, 1000);

            SparseBitArray active = new SparseBitArray(columns.Count);
            foreach (var col in columns)
            {
                int overlap = col.SpatialSynapses.Intersect(input);
                col.IsActive = overlap > threshold;
                if (col.IsActive)
                    active[col.Index] = true;
                col.UpdateSpatialDutyCycle(dutyPeriod);
            }
        }

        public void Initialize(int capacity, Range<int> slice)
        {
            throw new NotImplementedException();
        }

        public SparseBitArray Process(long timestamp, SparseBitArray input)
        {
            throw new NotImplementedException();
        }
    }
}
