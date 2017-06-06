using System;
using System.Collections.Generic;

namespace Serialization.Structure.Instruments
{
    [Serializable]
    internal class Synthesizer : MusicalInstrument
    {
        public Description KeynNumber { get; set; }

        public Synthesizer()
        {
            KeynNumber = new Description();
        }
    }
}
