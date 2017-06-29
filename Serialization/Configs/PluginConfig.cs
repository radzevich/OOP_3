using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

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

        public void Add(string type, string typeName, string path, string name)
        {
            if (_xRoot.SelectSingleNode(type) == null)
            {
                _xRoot.AppendChild(_xDocument.CreateElement(type));
                _xDocument.Save(_filePath);
            }

            var node = _xRoot.SelectSingleNode(type);

            node.AppendChild(CreateElement(typeName, new Dictionary<string, string>
                                            {
                                                { path, "path" },
                                                { name, "name" }
                                            }));
            _xDocument.Save(_filePath);
        }

        private XmlElement CreateElement(string typeName, Dictionary<string, string> values)
        {
            var item = _xDocument.CreateElement(typeName);

            foreach (KeyValuePair<string, string> pair in values)
            {
                var itemAttribute = _xDocument.CreateAttribute(pair.Value);
                var attributeText = _xDocument.CreateTextNode(pair.Key);

                itemAttribute.AppendChild(attributeText);
                item.Attributes.Append(itemAttribute);
            }

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

        public List<string> GetPaths(string type)
        {
            var nodelist = _xRoot.SelectSingleNode(type)?.ChildNodes;

            if (nodelist != null)
            {
                return (from XmlElement node in nodelist select node.Attributes.GetNamedItem("path").Value).ToList();
            }
            else
            {
                return null;
            }
        }

        public List<string> GetNames(string type)
        {
            var nodelist = _xRoot.SelectSingleNode(type)?.ChildNodes;

            if (nodelist != null)
            {
                return (from XmlElement node in nodelist select node.Attributes.GetNamedItem("name").Value).ToList();
            }
            else
            {
                return null;
            }
        }

        public string GetPathThroughName(string type, string name)
        {
            var root = _xRoot.SelectSingleNode(type);

            return (from XElement node in root where (string)node.Attribute("path") == name select node).FirstOrDefault().Attribute("name").Value;
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
