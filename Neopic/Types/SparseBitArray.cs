using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neopic.Types
{
    public class SparseBitArray : IEnumerable<bool>
    {
        private readonly SortedSet<int> _set;

        public SparseBitArray()
        {
            _set = new SortedSet<int>();
        }

        public SparseBitArray(int capacity)
        {
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

        public void Clear()
        {
            _set.Clear();
        }

        public bool Contains(int index)
        {
            return _set.Contains(index);
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
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
