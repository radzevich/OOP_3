using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginInterface
{
    public interface IHierarchyPlugin : IPlugin
    {
        Dictionary<string, string> Content { get; }
    }
}
