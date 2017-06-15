using System;
using System.Collections.Generic;

namespace Serialization.Structure.Instruments
{
    [Serializable]
    internal class Synthesizer : MusicalInstrument
    {
        public Description KeyNumber { get; set; }

        public Synthesizer()
        {
            KeyNumber = new Description();
        }
    }
}
