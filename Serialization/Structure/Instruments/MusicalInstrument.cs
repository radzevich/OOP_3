using System.Collections.Generic;
using System;

namespace Serialization.Structure.Instrument
{
    [Serializable]
    public abstract class MusicalInstrument : Description
    {  
        public Description company { get; protected set; }
        public Description country { get; protected set; }
        public Description model { get; set; }


        public override List<Description> getDescription()
        {
            var baseDescriptionList = base.getDescription();

            baseDescriptionList.Add(company);
            baseDescriptionList.Add(model);
            baseDescriptionList.Add(country);

            return baseDescriptionList;
        }
    }
}
