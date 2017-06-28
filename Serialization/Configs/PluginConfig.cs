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

        private const string _filePath = "..\\..\\Configs\\pluginConfig.xml";
        private readonly XmlDocument _xDocument;
        private readonly XmlElement _xRoot;

        #endregion

        #region Methods

        public void Add(string type, string name, string path)
        {
            if (_xRoot.SelectSingleNode(type) == null)
            {
                _xRoot.AppendChild(_xDocument.CreateElement(type));
                _xDocument.Save(_filePath);
            }

            var node = _xRoot.SelectSingleNode(type);

            node.AppendChild(CreateElement(name, "path", path));
            _xDocument.Save(_filePath);
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

        public List<string> GetPlugins(string type)
        {
            var nodelist = _xRoot.SelectSingleNode(type)?.ChildNodes;

            if (nodelist != null)
            {
                return (from XmlElement node in nodelist select node.Name).ToList();
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region Constructors

        //Constructor.
        public PluginConfig()
        {
            _xDocument = new XmlDocument();
            _xDocument.Load(_filePath);
            _xRoot = _xDocument.DocumentElement;
        }

        #endregion
    }
}
