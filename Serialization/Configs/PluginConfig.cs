using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Serialization.Configs
{
    internal class PluginConfig
    {
        #region Properties

        private const string FilePath = "..\\..\\Configs\\pluginConfig.xml";
        private readonly XmlDocument _xDocument;
        private readonly XmlElement _xRoot;

        #endregion

        #region Methods

        public void Add(string name, string path)
        {
            _xRoot.AppendChild(CreateElement(name, "path", path));
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

        public List<string> GetPlugins()
        {
            var nodeList = _xRoot.SelectNodes("*");

            return (from XmlElement node in nodeList select node.Name).ToList();
        }

        #endregion

        #region Constructors

        //Constructor.
        public PluginConfig()
        {
            _xDocument = new XmlDocument();
            _xDocument.Load(FilePath);
            _xRoot = _xDocument.DocumentElement;
        }

        #endregion
    }
}
