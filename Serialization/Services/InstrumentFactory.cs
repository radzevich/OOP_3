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
        private readonly InstrumentViewer _instrumentViewer;

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

        #region Factory

        //Initializes instrument object with properties getting from view.
        private void InitializeInstrument(MusicalInstrument instrument, List<ItemInfo> itemInfo)
        {
            for (int i = 1; i < itemInfo.Count; i++)
            {
                var item = itemInfo.ElementAt(i);
                InitializeField(instrument, item.Type, item.Items[0]);
            }
        }

        //Initializes certain field.
        private void InitializeField(MusicalInstrument instrument, string name, string value)
        {
            var fieldInfo = instrument.GetType().GetField(name);
            fieldInfo.SetValue(instrument, value);
        }

        //Creates empty instrument object.
        private MusicalInstrument Create(string name)
        {
            var instrument = (MusicalInstrument)_instrumentDictionary["name"].Invoke(new object[] { });

            instrument.Value = name;

            return instrument;
        }

        public MusicalInstrument Create(List<ItemInfo> itemInfo)
        {
            var instrument = Create(itemInfo[0].Type);

            InitializeInstrument(instrument, itemInfo);

            return instrument;
        }

        #endregion

        #region BasicInstrumentConstructors

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

        #endregion

        public List<string> GetInstrumentNameCollection()
        {
            return _instrumentDictionary.Keys.ToList();
        }

        public void IniitializeInstrument()
        {

        }
    }
}
