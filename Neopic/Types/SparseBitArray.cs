using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neopic
{
    public class SparseBitArray : IEnumerable<bool>, ICloneable
    {
        private readonly SortedSet<int> _set;
        private readonly int _length;
        private readonly int _offset;

        private SparseBitArray(SortedSet<int> set, int length)
        {
            _set = set;
            _length = length;
        }

        public SparseBitArray()
            : this (int.MaxValue)
        {
        }

        public SparseBitArray(int length)
        {
            Check.ArgumentIsGreaterThan(length, 0, "length");
            _set = new SortedSet<int>();
            _length = length;

        }

        public SparseBitArray(IEnumerable<bool> dense)
        {
            Check.ArgumentIsNotNull(dense, "dense");
            _set = new SortedSet<int>();
            int index = 0;
            foreach (var bit in dense)
            {
                if (bit)
                    _set.Add(index);
                index++;
            }
            _length = index;
        }

        public SparseBitArray(IEnumerable<int> indices, int length)
        {
            Check.ArgumentIsNotNull(indices, "indices");
            _set = new SortedSet<int>(indices);
            _length = length;
        }

        public bool this[int index]
        {
            get
            {
                Check.IndexIsInRange(index, 0, _length);
                return _set.Contains(index);
            }
            set
            {
                if (value)
                    _set.Add(index);
                else
                    _set.Remove(index);
            }
        }

        public int Length 
        {
            get { return _length; } 
        }

        public int Min
        {
            get
            {
                return _set.Min;
            }
        }

        public int Max
        {
            get
            {
                return _set.Max;
            }
        }

        public IEnumerable<bool> Values
        {
            get
            {
                for (int i = 0; i < _length; i++)
                {
                    yield return _set.Contains(i);
                }
            }
        }

        public decimal Density
        {
            get { return _set.Count / _length; }
        }

        public int Center
        {
            get { return (int)_set.Average(); }
        }

        public void Clear()
        {
            _set.Clear();
        }

        public void CopyTo(BitArray bits, int arrayIndex)
        {
            Check.ArgumentIsNotNull(bits, "array");
            Check.ArgumentIsGreaterThanOrEqual(arrayIndex, 0, "arrayIndex");
            Check.ArgumentIsGreaterThanOrEqual(bits.Length, arrayIndex + _length, "array.Length");
            int offset = 0;
            foreach (var index in _set)
            {
                offset = arrayIndex + index;
                if (bits.Length > offset)
                    bits[offset] = true;
                else
                    break;
            }
        }

        public void CopyTo(bool[] array, int arrayIndex)
        {
            Check.ArgumentIsNotNull(array, "array");
            Check.ArgumentIsGreaterThanOrEqual(arrayIndex, 0, "arrayIndex");
            Check.ArgumentIsGreaterThanOrEqual(array.Length, arrayIndex + _length, "array.Length");
            int offset = 0;
            foreach (var index in _set)
            {
                offset = arrayIndex + index;
                if (array.Length > offset)
                    array[offset] = true;
                else
                    break;
            }
        }
        
        public void UnionWith(SparseBitArray other)
        {
            Check.ArgumentIsLessThanOrEqual(other._length, _length, "other.Length");
            _set.UnionWith(other._set);
        }

        public void IntersectWith(SparseBitArray other)
        {
            Check.ArgumentIsLessThanOrEqual(other._length, _length, "other.Length");
            _set.IntersectWith(other._set);
        }

        public int Intersect(SparseBitArray other)
        {
            int overlap = 0;
            int max = this.Max;
            int min = this.Min;

            var e1 = _set.GetEnumerator();
            var e2 = other._set.GetEnumerator();
            bool end1 = !e1.MoveNext();
            bool end2 = !e2.MoveNext();
            while (!end1 && !end2 && e2.Current <= max)
            {
                int c = e1.Current.CompareTo(e2.Current);
                if (c < 0)
                    end1 = !e1.MoveNext();
                else if (c > 0)
                    end2 = !e2.MoveNext();
                else
                {
                    overlap++;
                    end1 = !e1.MoveNext();
                    end2 = !e2.MoveNext();
                }
            }
            return overlap;
        }

        public SparseBitArray And(SparseBitArray other)
        {
            var result = new SparseBitArray(Math.Max(_length, other._length));
            result.UnionWith(this);
            result.IntersectWith(other);
            return result;
        }

        public SparseBitArray Or(SparseBitArray other)
        {
            var result = new SparseBitArray(Math.Max(_length, other._length));
            result.UnionWith(this);
            result.UnionWith(other);
            return result;
        }

        public SparseBitArray Slice(int lower, int upper)
        {
            Check.IndexIsInRange(lower, 0, upper);
            Check.IndexIsInRange(upper, lower, _length);
            return new SparseBitArray(_set.GetViewBetween(lower, upper), upper - lower);
        }

        public SparseBitArray Concact(IEnumerable<SparseBitArray> bits)
        {
            int length = 0;
            SortedSet<int> set = new SortedSet<int>();
            foreach (var array in bits)
            {
                foreach (var index in array._set)
                {
                    set.Add(index + length);
                }
                length += array._length;
            }
            return new SparseBitArray(set, length);
        }


        public IEnumerator<bool> GetEnumerator()
        {
            return Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Values.GetEnumerator();
        }

        public SparseBitArray Clone()
        {
            var set = new SortedSet<int>();
            foreach (var index in _set)
                set.Add(index);
            return new SparseBitArray(set, _length);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public static implicit operator BitArray(SparseBitArray sparse)
        {
            var dense = new BitArray(sparse._length);
            foreach (var bit in sparse._set)
                dense[bit] = true;
            return dense;
        }

        public static implicit operator SparseBitArray(BitArray dense)
        {
            var sparse = new SparseBitArray(dense.Length);
            for (int i = 0; i < dense.Length; i++)
                if (dense[i])
                    sparse._set.Add(i);
            return sparse;
        }
    }
}
