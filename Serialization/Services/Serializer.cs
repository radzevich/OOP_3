using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Serialization.Structure;
using Serialization.Structure.Instruments;

namespace Serialization.Services
{
    class Serializer
    {
        private readonly BinaryFormatter _formatter;

        public void Serialize(List<MusicalInstrument> instrumentList, string path)
        {
            var serializableList = new List<List<ItemInfo>>();

            foreach (MusicalInstrument instrument in instrumentList)
            {
                serializableList.Add(ToSerializable(instrument));
            }

            if (path.Length > 0)
            {
                // получаем поток, куда будем записывать сериализованный объект
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    _formatter.Serialize(fs, serializableList);
                }
            }
        }

        public List<MusicalInstrument> Deserialize(string path)
        {
            List<List<ItemInfo>> serializableList = null;
            if (path.Length > 0)
            {
                // десериализация из файла people.dat
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    serializableList = (List<List<ItemInfo>>)_formatter.Deserialize(fs);
                }
            }

            var deserialized = new List<MusicalInstrument>();

            foreach (List<ItemInfo> item in serializableList)
            {
                deserialized.Add(FromSerializable(item));
            }

            return deserialized;
        }

        public Serializer()
        {
            _formatter = new BinaryFormatter();
        }

        public List<ItemInfo> ToSerializable(MusicalInstrument instrument)
        {
            var itemList = new List<ItemInfo>();
            Type type = instrument.GetType();

            itemList.Add (new ItemInfo
            {
                Type = type.Name,
                Value = instrument.Value
            });

            foreach (PropertyInfo property in type.GetProperties())
            {
                itemList.Add (new ItemInfo
                {
                    Type = property.Name,
                    Value = ((Description)property.GetValue(instrument, null)).Value
                });
            }

            return itemList;
        }

        public MusicalInstrument FromSerializable(List<ItemInfo> itemList)
        {
            return new InstrumentFactory().Create(itemList);
        }
    }
}
