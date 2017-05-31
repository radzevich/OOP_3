using System.Collections.Generic;
using System;

namespace Serialization.Structure.Instrument
{
    [Serializable]
    abstract class Guitar : MusicalInstrument
    {
        public Description material { get; set; } = new Description();


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
