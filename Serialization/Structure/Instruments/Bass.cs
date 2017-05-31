using System;
using System.Collections.Generic;

namespace Serialization.Structure.Instrument
{
    [Serializable]
    class Bass : Guitar
    {
        public Description stringNumber { get; set; } = new Description();


        public override List<Description> getDescription()
        {
            var baseDescriptionList = base.getDescription();

            baseDescriptionList.Add(stringNumber);

            return baseDescriptionList;
        }
    }
}
