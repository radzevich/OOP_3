using System.Collections.Generic;
using System;

namespace Serialization.Structure.Instrument
{
    [Serializable]
    abstract class Guitar : MusicalInstrument
    {
        public Description material { get; set; }

        public Guitar() : base()
        {

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
