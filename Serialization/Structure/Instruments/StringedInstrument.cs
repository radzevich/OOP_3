using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Serialization.Structure;

namespace Serialization.Structure.Instrument
{
    abstract class StringedInstrument : MusicalInstrument
    {
        public StringedInstrument(string name) : base(name) { }

    }
}