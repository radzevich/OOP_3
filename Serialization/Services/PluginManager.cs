using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using PluginInterface;

namespace Serialization.Services
{
    class PluginManager
    {
        private readonly Assembly _asm;

        public void AddContentPlugin(string path)
        {
            Assembly asm = Assembly.LoadFrom(path);

        }

        public void AddToHierarchy()
        {
            var type = _asm.GetTypes().First();
            
            if (type.GetInterfaces().Contains(typeof(IHierarchyPlugin)))
            {
                var plugin = Activator.CreateInstance(type) as IHierarchyPlugin;

                if (IsValid(plugin.PublicKey))
                {
                    AddInstrument(plugin.Content);
                }
            }
        }

        private void AddInstrument(Dictionary<string, string> configuration)
        {
            var instrumentViewer = new InstrumentViewer();
            var instrumentFactory = new InstrumentFactory();

            instrumentViewer.AddInstrument(configuration);
        }

        private bool IsValid(string path)
        {
            return true;
        }

        public PluginManager(string pluginPath)
        {
            _asm = Assembly.LoadFrom(pluginPath);
        }
    }
}
