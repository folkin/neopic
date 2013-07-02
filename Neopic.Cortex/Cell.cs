using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neopic.Cortex
{
    public class Cell
    {
        public Column Column { get; set; }
        public List<Dendrite> Dendrites { get; set; }
        public CellState State { get; set; }
    }
}
