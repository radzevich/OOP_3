using System.Collections.Generic;
using System;

namespace Serialization.Structure.Instrument
{
    [Serializable]
    public abstract class MusicalInstrument : Description
    {  
        public Description company { get; set; } = new Description();
        public Description country { get; set; } = new Description();
        public Description model { get; set; } = new Description();


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
