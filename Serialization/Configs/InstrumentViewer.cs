using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Navigation;
using System.Xml.Linq;
using Serialization.Structure;
using Serialization.Structure.Instruments;

namespace Serialization.Configs
{
    public class InstrumentViewer
    {
        private const string FilePath = "..\\..\\Configs\\InstrumentList.xml";
        private readonly XDocument _instrumentListFile;

        public virtual List<string> GetInstrumentList()
        {
            var instrumentList = new List<string>();

            var xElements = _instrumentListFile.Element("Instruments")?.Elements("Instrument");
            if (xElements == null) return instrumentList;
            instrumentList.AddRange(xElements.Select(element => element.Attribute("name")?.Value));

            return instrumentList;
        }

        public string GetName(string instrumentType)
        {
            var items = from xElement in _instrumentListFile.Element("Instruments")?.Elements("Instrument")
                where xElement.Attribute("type")?.Value == instrumentType
                select new Description()
                {
                    Name = xElement.Attribute("name")?.Value
                };
            return items.FirstOrDefault()?.Name;
        }

        public InstrumentViewer()
        {
            _instrumentListFile = XDocument.Load(FilePath);
        }
    }
}
