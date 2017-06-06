using System;
using System.Collections.Generic;

namespace Serialization.Structure.Instruments
{
    [Serializable]
    class Electric : Guitar
    {
        public Description Pickups { get; set; }

        public Electric() : base()
        {
            Pickups = new Description();
        }
    }
}
