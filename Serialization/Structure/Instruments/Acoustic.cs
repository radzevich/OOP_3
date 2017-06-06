using System;
using System.Collections.Generic;

namespace Serialization.Structure.Instruments
{
    [Serializable]
    internal class Acoustic : Guitar
    {
        public Description BackMaterial { get; set; }

        public Acoustic() : base()
        {
            BackMaterial = new Description();
        }
    }
}
