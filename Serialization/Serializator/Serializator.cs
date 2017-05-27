using Microsoft.Win32;
using Serialization.Structure;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;

namespace Serialization.Serializator
{
    class Serializator
    {
        private BinaryFormatter formatter;

        public void Serialize(object obj, string path)
        {           
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }
        }

        public object Deserialize(string path)
        {
            object deserialized;
            // десериализация из файла people.dat
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                deserialized = formatter.Deserialize(fs);
            }
            return deserialized;
        }

        public Serializator()
        {
            formatter = new BinaryFormatter();
        }
    }
}
