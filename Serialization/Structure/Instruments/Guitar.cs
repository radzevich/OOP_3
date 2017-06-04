using System;
using System.Collections.Generic;

namespace Serialization.Structure.Instruments
{
    [Serializable]
    internal abstract class Guitar : MusicalInstrument
    {
        public Description Material { get; set; } = new Description();


        public override List<Description> GetDescription()
        {
            {
                var baseDescriptionList = base.GetDescription();
 
                baseDescriptionList.AddRange(Material.GetDescription());

                return baseDescriptionList;
            }
        }
    }
}
