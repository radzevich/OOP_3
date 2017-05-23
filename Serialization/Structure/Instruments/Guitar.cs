using System.Collections.Generic;
using Serialization.Structure.Descriptions;

namespace Serialization.Structure.Instrument
{
    abstract class Guitar : StringedInstrument
    {
        public Material material { get; set; }

        public Guitar(string name) : base(name)
        {
            company.libFile = "E:\\Универ\\2 course\\ООП\\3rd_lab\\Serialization\\Serialization\\Structure\\Descriptions\\Libs\\guitar\\Companies.txt";
            material.libFile = "E:\\Универ\\2 course\\ООП\\3rd_lab\\Serialization\\Serialization\\Structure\\Descriptions\\Libs\\guitar\\Material.txt";
            model.libFile = "E:\\Универ\\2 course\\ООП\\3rd_lab\\Serialization\\Serialization\\Structure\\Descriptions\\Libs\\guitar\\Models.txt";
        }

        public override List<Description> description
        {
            get
            {
                var baseDescriptionList = base.description;

                baseDescriptionList.Add(material);

                return baseDescriptionList;
            }
        }
    }
}
