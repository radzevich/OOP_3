using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Serialization.Configs
{
    class WindowConfig
    {
        private readonly string configFilePath = "..\\..\\Configs\\windowConfig.xml";

        public string getValue(string property)
        {
            var configFile = XDocument.Load(configFilePath);

            throw new NotImplementedException();   
        }
    }
}
