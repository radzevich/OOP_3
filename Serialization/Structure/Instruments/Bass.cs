using System;
using System.Collections.Generic;

namespace Serialization.Structure.Instruments
{
    [Serializable]
    class Bass : Guitar
    {
        public Description StringNumber { get; set; }

        public Bass() : base()
        {
            StringNumber = new Description();
        }
    }
}
