using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neopic.Contracts;

namespace Neopic.Cortex
{
    [Export(typeof(IModel))]
    public class CortexModel : IModel
    {
        public NodeHierarchy Hierarchy { get; set; }


    }
}
