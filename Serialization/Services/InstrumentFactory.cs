using System.Collections.Generic;
using System.Linq;
using Serialization.Structure;
using Serialization.Structure.Instruments;

namespace Serialization.Services
{
    public class InstrumentFactory
    {
        private delegate MusicalInstrument CreateInstrumentDelegate();

        private readonly Dictionary<string, CreateInstrumentDelegate> _instrumentDictionary = new Dictionary<string, CreateInstrumentDelegate>();

        public InstrumentFactory()
        {
            CreateInstrumentDictionary();
        }

        protected void CreateFields(MusicalInstrument instrument)
        {

        }

        private void CreateInstrumentDictionary()
        {
            _instrumentDictionary.Add((new Electric()).GetDescription()[0].Value, CreateElectricGuitar);
            _instrumentDictionary.Add((new Acoustic()).GetDescription()[0].Value, CreateAcousticGuitar);
            _instrumentDictionary.Add((new Bass()).GetDescription()[0].Value, CreateBassGuitar);
            _instrumentDictionary.Add((new Synthesizer()).GetDescription()[0].Value, CreateSynthesizer);
        }

        protected virtual MusicalInstrument CreateElectricGuitar()
        {
            return new Electric();
        }

        protected virtual MusicalInstrument CreateAcousticGuitar()
        {
            return new Acoustic();
        }

        protected virtual MusicalInstrument CreateBassGuitar()
        {
            return new Bass();
        }

        protected virtual MusicalInstrument CreateSynthesizer()
        {
            return new Synthesizer();
        }

        public MusicalInstrument Create(string key)
        {
            return _instrumentDictionary[key].Invoke();
        }

        public List<string> GetInstrumentNameCollection()
        {
            return _instrumentDictionary.Keys.ToList();
        }

        public void IniitializeInstrumen()
        {

        }
    }
}
