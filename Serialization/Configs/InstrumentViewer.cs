using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Navigation;
using System.Xml;
using System.Xml.Linq;
using Serialization.Structure;
using Serialization.Structure.Instruments;

namespace Serialization.Configs
{
    public class InstrumentViewer
    {
        private const string FilePath = "..\\..\\Configs\\InstrumentList.xml";
        private readonly XmlDocument _xDocument;
        private readonly XmlElement _xRoot;

        //Returns names of all known instruments.
        public virtual List<string> GetInstrumentNameList()
        {
            //Выборка всех дочерних узлов в корневом
            XmlNodeList nodeList = _xRoot.SelectNodes("*");

            return (from XmlNode node in  nodeList select node.Attributes.GetNamedItem("name").Value).ToList();
        }

        public virtual List<string> GetItems(string path)
        {
            XmlNodeList nodeList = _xRoot.SelectNodes(path);

            return (from XmlNode node in nodeList select node.Value).ToList();
        }

        //Returns the name of the field.
        public virtual string GetElementThroughValue(string value)
        {
            return _xRoot.SelectSingleNode(value).Name;
        }

        //Constructor.
        public InstrumentViewer()
        {
            _xDocument = new XmlDocument();
            _xDocument.Load(FilePath);
            _xRoot = _xDocument.DocumentElement;
        }
    }
}
