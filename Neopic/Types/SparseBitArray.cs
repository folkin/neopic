using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neopic
{
    public class SparseBitArray<TIndex> : ICloneable
        where TIndex : struct
    {
        private readonly HashSet<TIndex> _indices;

        public SparseBitArray()
        {
            _indices = new HashSet<TIndex>();
        }

        private SparseBitArray(HashSet<TIndex> indices)
        {
            _indices = indices;
        }

        public bool this[TIndex index]
        {
            get
            {
                return _indices.Contains(index);
            }
            set
            {
                if (value)
                    _indices.Add(index);
                else
                    _indices.Remove(index);
            }
        }

        public int Count
        {
            get
            {
                return _indices.Count;
            }
        }

        public void Clear()
        {
            _indices.Clear();
        }

        public void UnionWith(SparseBitArray<TIndex> other)
        {
            _indices.UnionWith(other._indices);
        }

        public void IntersectWith(SparseBitArray<TIndex> other)
        {
            _indices.IntersectWith(other._indices);
        }

        public SparseBitArray<TIndex> And(SparseBitArray<TIndex> other)
        {
            var result = new SparseBitArray<TIndex>(new HashSet<TIndex>(_indices));
            result._indices.IntersectWith(other._indices);
            return result;
        }

        public SparseBitArray<TIndex> Or(SparseBitArray<TIndex> other)
        {
            var result = new SparseBitArray<TIndex>(new HashSet<TIndex>(_indices));
            result.UnionWith(other);
            return result;
        }

        public SparseBitArray<TIndex> Clone()
        {
            return new SparseBitArray<TIndex>(new HashSet<TIndex>(_indices));
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public IEnumerable<bool> Enumerate(IEnumerator<TIndex> enumerator)
        {
            while (enumerator.MoveNext())
                yield return _indices.Contains(enumerator.Current);
        }
    }
}
