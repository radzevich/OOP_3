using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Serialization.Configs;
using Serialization.Structure;
using Serialization.Structure.Instruments;

namespace Serialization.Services
{
    public class InstrumentFactory
    {
        #region Fields
        //Dictionary of constructors <class name, constructor info (reflection)>
        private readonly Dictionary<string, ConstructorInfo> _instrumentDictionary;

        #endregion

        #region FactoryConstrutor

        public InstrumentFactory()
        {
            _instrumentDictionary = new Dictionary<string, ConstructorInfo>();

            InitializeDictionary();
        }

        private void InitializeDictionary()
        {
            AddToDictionary(typeof(Electric));
            AddToDictionary(typeof(Bass));
            AddToDictionary(typeof(Acoustic));
            AddToDictionary(typeof(Synthesizer));
        }

        #endregion

        #region Factory

        //Initializes instrument object with properties getting from view.
        private void InitializeInstrument(MusicalInstrument instrument, List<ItemInfo> itemInfo)
        {
            for (int i = 1; i < itemInfo.Count; i++)
            {
                var item = itemInfo.ElementAt(i);
                InitializeField(instrument, item.Type, item.Value);
            }
        }

        //Initializes certain field.
        private void InitializeField(MusicalInstrument instrument, string name, string value)
        {
            var fieldInfo = instrument.GetType().GetProperty(name);
            fieldInfo.SetValue(instrument, new Description() { Value = value });
        }

        //Creates empty instrument object.
        private MusicalInstrument Create(string name)
        {
            var instrument = (MusicalInstrument)_instrumentDictionary[name].Invoke(new object[] { });

            return instrument;
        }

        //Creating new instrument using it's description.
        public MusicalInstrument Create(List<ItemInfo> itemInfo)
        {
            var instrument = Create(itemInfo[0].Type);

            instrument.Value = itemInfo.First().Value;

            InitializeInstrument(instrument, itemInfo);

            return instrument;
        }

        //Initializing instrument description from already created instrument object.
        public void Initialize(List<ItemInfo> itemInfo, MusicalInstrument instrument)
        {
            foreach (ItemInfo item in itemInfo)
            {
                if (item == itemInfo.First()) continue;
                
                PropertyInfo fieldInfo = instrument.GetType().GetProperty(item.Type);
                string value = (fieldInfo.GetValue(instrument) as Description).Value;

                if (value != null)
                {
                    item.Value = value;
                }
            }
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

        #region ExtensionInterface

        //Allows to add new classes
        public void AddToDictionary(Type type)
        {
            _instrumentDictionary.Add(type.Name, type.GetConstructor(Type.EmptyTypes));
        }

        public void AddExtendedClass(List<string> info)
        {
            var builder = new ClassBuilder();

            builder.Create(info);
            
        }



        #endregion

    }
}
