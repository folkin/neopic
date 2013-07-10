using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neopic.Cortex.Components
{
    public class LearningSpatialPooler : SpatialPooler
    {
        public override void Process(IList<Column> columns, long timestamp, SparseBitArray input, int threshold)
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
    }
}
