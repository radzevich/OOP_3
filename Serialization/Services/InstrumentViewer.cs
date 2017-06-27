using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Markup;
using System.Windows.Navigation;
using System.Xml;
using System.Xml.Linq;
using Serialization.Structure;
using Serialization.Structure.Instruments;

namespace Serialization.Services
{
    public class InstrumentViewer
    {
        #region Properties

        private const string FilePath = "..\\..\\Entities\\InstrimentList.xml";
        private readonly XmlDocument _xDocument;
        private readonly XmlElement _xRoot;

        #endregion

        #region Methods

        //Returns names of all known instruments.
        public virtual List<string> GetNameList()
        {
            var nodeList = _xRoot.SelectNodes("*");

            return (from XmlElement node in nodeList select node.Attributes.GetNamedItem("value").Value).ToList();
        }

        //Returns the name of the first class in document.
        public virtual string GetFirstTypeName()
        {
            return _xRoot.SelectSingleNode("*").Name;
        }

        //Returns class name through it's "name" attribute.
        public virtual string GetTypeThrowName(string name)
        {
            var type = from XmlElement node in _xRoot.ChildNodes
                where node.Attributes.GetNamedItem("value").Value == name
                select node.Name;

            return type.First();
        }

        public virtual string GetNameThroughPath(List<string> path)
        {
            XmlNode xNode = GetNodeThroughPath(path);

            return xNode.Attributes.GetNamedItem("name").Value;
        }

        //Returns info about class strucure, names of it's properties.
        public virtual List<ItemInfo> GetInstrumentInfo(string instrumentType)
        {
            var instrumentInfo = new List<ItemInfo> { GetItemInfo(_xRoot) };

            instrumentInfo.First().Type = instrumentType;

            var child = _xRoot.SelectSingleNode(instrumentType);

            var list = (from XmlElement node in child.ChildNodes
                select GetItemInfo(node)).ToList();


            instrumentInfo.AddRange(list);

            return instrumentInfo;
        }

        protected virtual ItemInfo GetItemInfo(XmlNode xNode)
        {
            return new ItemInfo
            {
                Name = xNode.Attributes.GetNamedItem("name").Value,
                Type = xNode.Name,
                Value = null,
                Items = (from XmlElement node in xNode.ChildNodes select node.Attributes.GetNamedItem("value").Value).ToList()
            };
        }

        public virtual List<string> GetItems(List<string> path)
        {
            XmlNode root = GetNodeThroughPath(path);
            var nodeList = root.SelectNodes("*");

            return (from XmlElement node in nodeList select node.Attributes.GetNamedItem("item").Value).ToList();
        }

        public virtual void AddItem(List<string> path, string value)
        {
            XmlNode xNode = GetNodeThroughPath(path);

            xNode.AppendChild(CreateElement("item", "value", value));

            _xDocument.Save(FilePath);
        }

        public virtual void AddInstrument(Dictionary<string, string> config)
        {
            var xNode = CreateElement(config.Keys.First(), "value", config.Values.First());

            for (int i = 1; i < config.Count; i++)
            {
                xNode.AppendChild(CreateElement(config.Keys.ElementAt(i), "name", config.Values.ElementAt(i)));
            }

            _xRoot.AppendChild(xNode);
            _xDocument.Save(FilePath);
        }

        private XmlElement CreateElement(string name, string attributeName, string value)
        {
            var item = _xDocument.CreateElement(name);
            var itemAttribute = _xDocument.CreateAttribute(attributeName);
            var attributeText = _xDocument.CreateTextNode(value);

            itemAttribute.AppendChild(attributeText);
            item.Attributes.Append(itemAttribute);


            return item;
        }

        private XmlNode GetNodeThroughPath(List<string> path)
        {
            XmlNode xNode = _xRoot;

            foreach (var node in path)
            {
                xNode = xNode.SelectSingleNode(node);
            }

            return xNode;
        }

        #endregion

        #region Constructors

        //Constructor.
        public InstrumentViewer()
        {
            _xDocument = new XmlDocument();
            _xDocument.Load(FilePath);
            _xRoot = _xDocument.DocumentElement;
        }

        #endregion
    }
}
