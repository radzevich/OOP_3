using System;
using System.Collections.Generic;

namespace Serialization.Structure.Instruments
{
    [Serializable]
    internal abstract class Guitar : MusicalInstrument
    {
        public Description Material { get; set; }

        protected Guitar() : base()
        {
            Material = new Description();
        }
    }
}
