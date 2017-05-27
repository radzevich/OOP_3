using System;
using System.Collections.Generic;

namespace Serialization.Structure.Instrument
{
    [Serializable]
    class Acoustic : Guitar
    {
        public Description backMaterial { get; set; }
        public Acoustic()
        {
            Value = "Акустическая гитара";

            backMaterial = new Description("Задняя дека");
            backMaterial.LibPath = "..\\..\\Structure\\Descriptions\\Libs\\guitar\\Materials.txt";
        }

        public override List<Description> getDescription()
        {
            var baseDescriptionList = base.getDescription();

            baseDescriptionList.Add(backMaterial);

            return baseDescriptionList;
        }
    }
}
