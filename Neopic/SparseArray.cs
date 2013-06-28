using System;
using System.Collections;
using System.Collections.Generic;

namespace Neopic
{
    public class SparseArray<T> : ICloneable, IEnumerable<T>
    {
        private readonly Dictionary<int, T> _array;
        private readonly int _length;

        public SparseArray()
        {
            _array = new Dictionary<int, T>();
            _length = 0;
        }

        public SparseArray(int capacity)
        {
            _array = new Dictionary<int, T>();
            _length = capacity;
        }

        public SparseArray(SparseArray<T> copy)
        {
            _array = new Dictionary<int, T>(copy._array);
            _length = copy._length;
        }

        public int Length
        {
            get
            {
                return _length;
            }
        }

        public int Count
        {
            get
            {
                return _array.Count;
            }
        }

        public T this[int index]
        {
            get
            {
                T value;
                _array.TryGetValue(index, out value);
                return value;
            }
            set
            {
                _array[index] = value;
            }
        }

        public IEnumerable<T> Values
        {
            get
            {
                for (int i = 0; i < _length; i++)
                {
                    T value;
                    _array.TryGetValue(i, out value);
                    yield return value;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Values.GetEnumerator();
        }

        public SparseArray<T> Clone()
        {
            return new SparseArray<T>(this);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }
    }
}
