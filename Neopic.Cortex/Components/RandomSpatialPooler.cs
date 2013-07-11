using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neopic.Cortex.Components
{
    public class RandomSpatialPooler : ISpatialPooler
    {
        private Range<int> _slice;
        private readonly Random _random;
        private int _maxActive;

        public RandomSpatialPooler()
        {

        }

        public void Initialize(int capacity, Range<int> slice)
        {
            throw new NotImplementedException();
        }

        SparseBitArray ISpatialPooler.Process(long timestamp, SparseBitArray input)
        {
            throw new NotImplementedException();
        }
    }
}
