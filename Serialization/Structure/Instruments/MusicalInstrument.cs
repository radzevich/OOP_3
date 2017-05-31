using System;
using System.Collections.Generic;

namespace Serialization.Structure.Instruments
{
    [Serializable]
    public abstract class MusicalInstrument : Description
    {  
        public Description Company { get; set; } = new Description();
        public Description Country { get; set; } = new Description();
        public Description Model { get; set; } = new Description();

        public override List<Description> GetDescription()
        {
            var baseDescriptionList = base.GetDescription();

            baseDescriptionList.Add(Company);
            baseDescriptionList.Add(Model);
            baseDescriptionList.Add(Country);

            return baseDescriptionList;
        }
    }
}
