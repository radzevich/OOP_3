using System;
using System.Collections.Generic;

namespace Serialization.Structure.Instruments
{
    [Serializable]
    class Electric : Guitar
    {
        public Description Pickups { get; set; } = new Description();


        public override List<Description> GetDescription()
        {
            var baseDescriptionList = base.GetDescription();

            baseDescriptionList.Add(Pickups);

            return baseDescriptionList;
        }
    }
}
