using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serialization.Structure.Descriptions;

namespace Serialization.Structure.Instrument
{
    abstract class KeyboardInstrument : MusicalInstrument
    {
        public KeyboardInstrument(string name) : base(name)
        {
        }
    }
}
