using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serialization.Structure.Instrument;

namespace Serialization.Services
{
    class InstrumentFactory
    {
        private delegate MusicalInstrument createInstrumentDelegate();

        private readonly Dictionary<string, createInstrumentDelegate> instrumentDictionary;

        public InstrumentFactory()
        {
            createInstrumentDictionary();
        }

        private void createInstrumentDictionary()
        {
            instrumentDictionary.Add((new Electric()).description[0].Value, createElectricGuitar);
            instrumentDictionary.Add((new Acoustic()).description[0].Value, createAcousticGuitar);
            instrumentDictionary.Add((new Bass()).description[0].Value, createBassGuitar);
            instrumentDictionary.Add((new Synthesizer()).description[0].Value, createSynthesizer);
        }

        private MusicalInstrument createElectricGuitar()
        {
            return new Electric();
        }

        private MusicalInstrument createAcousticGuitar()
        {
            return new Acoustic();
        }

        private MusicalInstrument createBassGuitar()
        {
            return new Bass();
        }

        private MusicalInstrument createSynthesizer()
        {
            return new Synthesizer();
        }

        public MusicalInstrument create(string key)
        {
            return instrumentDictionary[key].Invoke();
        }

        public string[] getInstrumentNameCollection()
        {
            return instrumentDictionary.Keys.ToArray<string>();
        }
    }
}
