using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neopic.Cortex.Components
{
    public class RandomSpatialPooler : SpatialPooler
    {
        private Random _rand = new Random();

        public override void Process(IList<Column> columns, long timestamp, SparseBitArray input, int threshold)
        {
            foreach (var col in columns)
            {
                col.IsActive = _rand.Next(100) > 50;
            }
        }
    }
}
