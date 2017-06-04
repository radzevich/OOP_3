using System;
using System.Collections.Generic;

namespace Serialization.Structure.Instruments
{
    [Serializable]
    class Bass : Guitar
    {
        public Description StringNumber { get; set; } = new Description();


        public override List<Description> GetDescription()
        {
            var baseDescriptionList = base.GetDescription();

            baseDescriptionList.AddRange(StringNumber.GetDescription());

            return baseDescriptionList;
        }
    }
}
