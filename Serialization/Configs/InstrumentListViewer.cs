using System.Collections.Generic;
using System.Xml.Linq;

namespace Serialization.Configs
{
    class InstrumentListViewer
    {
        private readonly string instrumentFilePath = "..\\..\\Configs\\InstrumentList.xml";

        public List<string> getNames()
        {
            var nameList = new List<string>();

            var instrumentFile = XDocument.Load(instrumentFilePath);

            foreach (XElement instrument in instrumentFile.Element("Instruments").Elements("Instrument"))
            {
                nameList.Add(instrument.Attribute("name").Value);
            }

            return nameList;
        }
    }
}
