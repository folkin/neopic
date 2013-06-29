using System;
using System.Collections.Generic;
using System.Linq;
using Neopic.Utility;

namespace Neopic
{
    public sealed class Dimensions
    {
        private readonly int[] _dimensions;

        public static readonly Dimensions Unspecified = new Dimensions(true, false);
        public static readonly Dimensions DontCare = new Dimensions(false, true);

        private Dimensions(bool unspecified, bool dontCare)
        {
            if (unspecified)
                _dimensions = null;
            
            if (dontCare)
                _dimensions = new int[0];
        }

        public Dimensions(params int[] dimensions)
            : this((IEnumerable<int>)dimensions)
        {
        }

        public Dimensions(IEnumerable<int> dimensions)
        {
            Contract.Requires(() => dimensions != null, () => new ArgumentNullException("dimensions"));
            Contract.Requires(() => dimensions.Count() > 0, () => new ArgumentException("At least one dimension must be specified.", "dimensions"));
            Contract.Requires(() => dimensions.All(d => d > 0), () => new ArgumentException("Dimensions cannot be negative or zero.", "dimensions"));

            _dimensions = dimensions.ToArray();
        }

        public int Length
        {
            get { return _dimensions.Length; }
        }

        public int this[int idx]
        {
            get { return _dimensions[idx]; }
        }

        public override bool Equals(object other)
        {
            return this == other as Dimensions;
        }

        public bool Equals(Dimensions other)
        {
            return this == other;
        }

        public static bool Equals(Dimensions x, Dimensions y)
        {
            return x == y;
        }

        public static bool operator ==(Dimensions x, Dimensions y)
        {
            if (x == null && y == null)
                return true;
            else if (x != null && y != null)
            {
                return (x.GetHashCode() == y.GetHashCode());
            }
            return false;
        }

        public static bool operator !=(Dimensions x, Dimensions y)
        {
            return !(x == y);
        }

        public override int GetHashCode()
        {
            if (_dimensions == null)
                return 0;
            else if (_dimensions.Length == 0)
                return 1;
            else
            {
                return _dimensions.Aggregate((h, d) => h ^ d);
            }
        }

        public override string ToString()
        {
            if (_dimensions == null)
                return "Unspecfied";
            else if (_dimensions.Length == 0)
                return "Don't Care";
            else
                return string.Format("[{0}]", string.Join(",", _dimensions.Select(d => d.ToString())));
        }
    }
}
