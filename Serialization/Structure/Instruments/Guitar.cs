using System.Collections.Generic;
using Serialization.Structure.Descriptions;
using System;

namespace Serialization.Structure.Instrument
{
    [Serializable]
    abstract class Guitar : MusicalInstrument
    {
        public Material material { get; set; }

        public Guitar() : base()
        {
            material = new Material();

            company.LibPath = "..\\..\\\\Structure\\Descriptions\\Libs\\guitar\\Companies.txt";
            material.LibPath = "..\\..\\Structure\\Descriptions\\Libs\\guitar\\Materials.txt";
            model.LibPath = "..\\..\\\\Structure\\Descriptions\\Libs\\guitar\\Models.txt";
        }

        public override List<Description> getDescription()
        {
            {
                var baseDescriptionList = base.getDescription();

                baseDescriptionList.Add(material);

                return baseDescriptionList;
            }
        }
    }
}
