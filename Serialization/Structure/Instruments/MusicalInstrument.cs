using System;
using System.Collections.Generic;
using System.Linq;

namespace Serialization.Structure.Instruments
{
    [Serializable]
    public abstract class MusicalInstrument : Description
    {
        public Description Company { get; set; }
        public Description Country { get; set; }
        public Description Model { get; set; }

        protected MusicalInstrument() : base()
        {
            Company = new Description();
            Country = new Description();
            Model = new Description();
        }
    }
}
