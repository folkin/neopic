using System;

namespace Neopic.Cortex
{
    public interface ISpatialPooler
    {
        void Initialize(int capacity, Range<int> slice);

        SparseBitArray Process(long timestamp, SparseBitArray input);
    }
}
