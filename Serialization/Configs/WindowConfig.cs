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
        private readonly string _configFilePath = "..\\..\\Configs\\windowConfig.xml";

        public string GetValue(string property)
        {
            var configFile = XDocument.Load(_configFilePath);

            throw new NotImplementedException();   
        }
    }
}
