using System;
using System.Collections.Generic;

namespace Serialization.Structure.Instruments
{
    [Serializable]
    internal class Acoustic : Guitar
    {
        public Description BackMaterial { get; set; } = new Description();

        public override List<Description> GetDescription()
        {
            var baseDescriptionList = base.GetDescription();

            baseDescriptionList.Add(BackMaterial);

            return baseDescriptionList;
        }
    }
}
