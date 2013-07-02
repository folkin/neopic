using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neopic
{
    public class SparseBitArray : IEnumerable<bool>
    {
        private readonly SortedSet<int> _set;
        private readonly int _length;

        public SparseBitArray()
            : this (int.MaxValue)
        {
        }

        public SparseBitArray(int length)
        {
            Check.IsTrue(length > 0);

            _set = new SortedSet<int>();
            _length = length;

        }

        public bool this[int index]
        {
            get
            {
                return _set.Contains(index);
            }
            set
            {
                _set.Add(index);
            }
        }

        public int Length 
        {
            get { return _length; } 
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
            get
            {
                return _set.Count / _length;
            }
        }

        public void Clear()
        {
            _set.Clear();
        }

        public void CopyTo(bool[] array, int arrayIndex)
        {
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
            _set.UnionWith(other._set);
        }

        public IEnumerator<bool> GetEnumerator()
        {
            return Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Values.GetEnumerator();
        }
    }
}
