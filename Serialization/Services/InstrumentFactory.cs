using System.Collections.Generic;
using System.Linq;
using Serialization.Structure.Instrument;
using Serialization.Structure;

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

        protected void createFields(MusicalInstrument instrument)
        {

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

        public void iniitializeInstrumen()
        {

        }
    }
}
