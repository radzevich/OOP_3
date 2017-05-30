using System;
using System.Collections.Generic;

namespace Serialization.Structure.Instrument
{
    [Serializable]
    class Synthesizer : MusicalInstrument
    {
        public Description buttonNum { get; set; }

        
        public override List<Description> getDescription()
        {
            {
                var baseDescriptionList = base.getDescription();

                baseDescriptionList.Add(buttonNum);

                return baseDescriptionList;
            }
        }
    }
}
