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

        public byte[] Serialize(List<MusicalInstrument> instrumentList)
        {
            var serializableList = new List<List<ItemInfo>>();

            foreach (MusicalInstrument instrument in instrumentList)
            {
                serializableList.Add(ToSerializable(instrument));
            }

            // получаем поток, куда будем записывать сериализованный объект
            using (var stream = new MemoryStream())
            {
                _formatter.Serialize(stream, serializableList);
                return stream.ToArray();
            }
        }

        public List<MusicalInstrument> Deserialize(byte[] stream)
        {
            List<List<ItemInfo>> serializableList = null;

            // десериализация из файла people.dat
            using (var content = new MemoryStream(stream))
            {
                serializableList = (List<List<ItemInfo>>)_formatter.Deserialize(content);
            }
        

            var deserialized = new List<MusicalInstrument>();

            foreach (List<ItemInfo> item in serializableList)
            {
                deserialized.Add(FromSerializable(item));
            }

            return deserialized;
        }

        public List<ItemInfo> ToSerializable(MusicalInstrument instrument)
        {
            var itemList = new List<ItemInfo>();
            Type type = instrument.GetType();

            itemList.Add(new ItemInfo
            {
                Type = type.Name,
                Value = instrument.Value
            });

            foreach (PropertyInfo property in type.GetProperties())
            {
                if (property.Name != "Value")
                {

                    itemList.Add(new ItemInfo
                    {
                        Type = property.Name,
                        Value = ((Description) property.GetValue(instrument, null))?.Value
                    });
                }
            }

            return itemList;
        }

        public MusicalInstrument FromSerializable(List<ItemInfo> itemList)
        {
            return new InstrumentFactory().Create(itemList);
        }

        public Serializer()
        {
            _formatter = new BinaryFormatter();
        }
    }
}
