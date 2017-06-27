using System.Collections.Generic;
using PluginInterface;

namespace Drums
{   
    public class Drums : IHierarchyPlugin
    {
        public string Name => "Drums";
        public string PublicKey => null;

        public Dictionary<string, string> Content
        {
            get
            {
                var content = new Dictionary<string, string>
                {
                    {Name, "Ударные"},
                    {"Company", "Производитель"},
                    {"Country", "Страна"},
                    {"Configuration", "Конфигурация"}
                };
                
                return content;
            }
        }
    }
}