using System;
using System.Collections.Generic;
using System.Linq;

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

            baseDescriptionList.AddRange(Company.GetDescription());
            baseDescriptionList.AddRange(Model.GetDescription());
            baseDescriptionList.AddRange(Country.GetDescription());

            return baseDescriptionList;
        }
    }
}
