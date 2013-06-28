using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using Neopic.Prediction;

namespace Neopic.Console
{
    public class Program
    {
        private readonly CompositionContainer _container;

        public Program()
        {
            var options = CompositionOptions.DisableSilentRejection;
            var catalog = new DirectoryCatalog(".");
            _container = new CompositionContainer(catalog, options);
        }


        
        
        
        
        
        
        
        [STAThread]
        static void Main(string[] args)
        {
            Instance = new Program();

        }

        public static Program Instance { get; private set; }
    }
}
