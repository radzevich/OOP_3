using System;

namespace Serialization.Structure.Instrument
{
    [Serializable]
    abstract class KeyboardInstrument : MusicalInstrument
    {
        public KeyboardInstrument()
        {
            company.LibPath = "..\\..\\Structure\\Descriptions\\Libs\\synthesizer\\Companies.txt";
        }
    }
}
