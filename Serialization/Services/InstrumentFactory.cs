using System.Collections.Generic;
using System.Linq;
using Serialization.Structure.Instrument;

namespace Serialization.Services
{
    class InstrumentFactory
    {
        private delegate MusicalInstrument createInstrumentDelegate();

        private readonly Dictionary<string, createInstrumentDelegate> instrumentDictionary = new Dictionary<string, createInstrumentDelegate>();

        public InstrumentFactory()
        {
            createInstrumentDictionary();
        }

        private void createInstrumentDictionary()
        {
            instrumentDictionary.Add((new Electric()).getDescription()[0].Value, createElectricGuitar);
            instrumentDictionary.Add((new Acoustic()).getDescription()[0].Value, createAcousticGuitar);
            instrumentDictionary.Add((new Bass()).getDescription()[0].Value, createBassGuitar);
            instrumentDictionary.Add((new Synthesizer()).getDescription()[0].Value, createSynthesizer);
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

        public List<string> getInstrumentNameCollection()
        {
            return instrumentDictionary.Keys.ToList();
        }
    }
}
