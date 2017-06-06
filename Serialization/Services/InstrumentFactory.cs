using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Serialization.Configs;
using Serialization.Structure;
using Serialization.Structure.Instruments;

namespace Serialization.Services
{
    public class InstrumentFactory
    {
        private readonly Dictionary<string, ConstructorInfo> _instrumentDictionary;
        private InstrumentViewer _instrumentViewer;

        public InstrumentFactory()
        {
            _instrumentViewer = new InstrumentViewer();
            _instrumentDictionary = new Dictionary<string, ConstructorInfo>();

            InitializeDictionary();
        }

        protected void CreateFields(MusicalInstrument instrument)
        {

        }

        private void InitializeDictionary()
        {
            AddToDictionary(typeof(Electric));
            AddToDictionary(typeof(Bass));
            AddToDictionary(typeof(Acoustic));
            AddToDictionary(typeof(Synthesizer));
        }

        private void AddToDictionary(Type type)
        {
            _instrumentDictionary.Add(type.Name, type.GetConstructor(Type.EmptyTypes));   
        }

        public MusicalInstrument initializeInstrument(Dictionary<string, string> fields)
        {
            var instrument = CreateInstrument(_instrumentViewer.GetElementThroughValue(fields.First().Value));

            for (int i = 1; i < fields.Count; i++)
            {
                var item = fields.ElementAt(i);
                InitializeField(instrument, item.Key, item.Value);
            }

            return instrument;
        }

        public void InitializeField(MusicalInstrument instrument, string name, string value)
        {
            var fieldInfo = instrument.GetType().GetField(name);
            fieldInfo.SetValue(instrument, value);
        }

        private MusicalInstrument CreateInstrument(string name)
        {
            var instrument = (MusicalInstrument)_instrumentDictionary["name"].Invoke(new object[] { }) ;

            instrument.Value = name;

            return instrument;
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

        public void IniitializeInstrument()
        {

        }
    }
}
