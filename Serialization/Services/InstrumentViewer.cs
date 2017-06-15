﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
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
