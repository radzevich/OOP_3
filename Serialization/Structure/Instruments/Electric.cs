using System;
using System.Collections.Generic;

namespace Serialization.Structure.Instrument
{
    [Serializable]
    class Electric : Guitar
    {
        public Description pickups { get; set; } = new Description();


        public override List<Description> getDescription()
        {
            var baseDescriptionList = base.getDescription();

            baseDescriptionList.Add(pickups);

            return baseDescriptionList;
        }
    }
}
