using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
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
                    {Name, "ударные"},
                    {"Company", "производитель"},
                    {"Country", "страна"},
                    {"Configuration", "конфигурация"}
                };
                
                return content;
            }
        }
    }
}