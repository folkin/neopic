using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neopic.Types
{
    public class SparseBitArray : ICollection<bool>, IDictionary<int, bool>
    {
        private readonly SortedSet<int> _set;



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
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(bool item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<bool> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Add(int key, bool value)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(int key)
        {
            throw new NotImplementedException();
        }

        public ICollection<int> Keys
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(int key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(int key, out bool value)
        {
            throw new NotImplementedException();
        }

        public ICollection<bool> Values
        {
            get { throw new NotImplementedException(); }
        }

        public void Add(KeyValuePair<int, bool> item)
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<int, bool> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<int, bool>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<int, bool> item)
        {
            throw new NotImplementedException();
        }

        IEnumerator<KeyValuePair<int, bool>> IEnumerable<KeyValuePair<int, bool>>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
