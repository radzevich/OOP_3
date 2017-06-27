using System.Collections.Generic;

namespace PluginInterface
{
    public interface IContentPlugin : IPlugin
    {
        List<string> Content { get; }
    }
}
