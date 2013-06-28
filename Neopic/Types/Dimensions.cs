using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neopic
{
    public class Dimensions
    {
        private readonly int?[] _dimensions;

        public static readonly Dimensions Unspecified = new Dimensions();

        private Dimensions()
        {
            _dimensions = new int?[0];
        }

        public Dimensions(params int?[] dimensions)
        {
            _dimensions = dimensions.ToArray();
        }

        public Dimensions(IEnumerable<int?> dimensions)
        {
            _dimensions = dimensions.ToArray();
        }

        public int Length
        {
            get { return _dimensions.Length; }
        }

        public int this[int idx]
        {
            get { return (int)_dimensions[idx]; }
        }
    }
}
