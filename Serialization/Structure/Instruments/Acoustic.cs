using System;
using System.Collections.Generic;

namespace Serialization.Structure.Instrument
{
    [Serializable]
    class Acoustic : Guitar
    {
        public Description backMaterial { get; set; } = new Description();

        public override List<Description> getDescription()
        {
            var baseDescriptionList = base.getDescription();

            baseDescriptionList.Add(backMaterial);

            return baseDescriptionList;
        }
    }
}
