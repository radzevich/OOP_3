using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization.Structure.Instrument
{
    class Synthesizer : KeyboardInstrument
    {
        public Synthesizer(string name) : base(name)
        {
            company.libFile = "E:\\Универ\\2 course\\ООП\\3rd_lab\\Serialization\\Serialization\\Structure\\Descriptions\\Libs\\synthesizer\\Companies.txt";
        }
    }
}
