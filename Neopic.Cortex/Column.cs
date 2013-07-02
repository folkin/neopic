using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neopic.Cortex
{
    public class Column
    {
        public Node Node { get; set; }
        public Cell Spatial { get; set; }
        public IList<Cell> Temporal { get; set; }
        bool IsActive { get; set; }
    }
}
