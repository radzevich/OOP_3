using System;
using System.Collections.Generic;

namespace Serialization.Structure.Instruments
{
    [Serializable]
    internal class Synthesizer : MusicalInstrument
    {
        public Description KeynNumber { get; set; } = new Description();


        public override List<Description> GetDescription()
        {
            {
                var baseDescriptionList = base.GetDescription();

                baseDescriptionList.Add(KeynNumber);

                return baseDescriptionList;
            }
        }
    }
}
