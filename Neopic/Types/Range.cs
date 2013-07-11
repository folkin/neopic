using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neopic
{
    public struct Range<T> where T : IComparable
    {
        private readonly T _start;
        private readonly T _end;

        public Range(T end)
            : this(default(T), end)
        {
        }

        public Range(T start, T end)
        {
            if (start.CompareTo(end) <= 0)
            {
                _start = start;
                _end = end;
            }
            else{
                _start = end;
                _end = start;
            }
        }

        public Range(Range<T> range)
            : this(range._start, range._end)
        {
        }

        public T Start { get { return _start; } }
        public T End { get { return _end; } }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == this.GetType())
            {
                return Range<T>.Equals(this, (Range<T>)obj);
            }
            return false;
        }

        public static bool Equals(Range<T> a, Range<T> b)
        {
            return a._start.CompareTo(b._start) == 0 && a._end.CompareTo(b._end) == 0;
        }

        public override int GetHashCode()
        {
            return _start.GetHashCode() ^ _end.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}]", _start, _end);
        }
    }
}
